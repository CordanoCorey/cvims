import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { build, getValue, guid } from '@caiu/core';
import { Control, ArrayControl, FormArray } from '@caiu/forms';
import { HttpActions, LookupValue } from '@caiu/http';
import { SmartComponent, Store, Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { ChargeInfo, PaymentInfo, CartItem, CartCost } from './cart.model';
import { CartActions, cartItemsSelector, cartCostSelector, CartItemActions } from './cart.reducer';
import { SidenavActions } from '../shared/actions';
import { Address, ShippingInfo } from '../shared/models';
import { siteLocationSelector, currentUserIdSelector, lookupShippingOptions, lookupStates } from '../shared/selectors';
import { environment } from '../../environments/environment';
import { Order } from '../orders/orders.model';
import { OrdersActions } from '../orders/orders.reducer';

@Component({
  selector: 'cv-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent extends SmartComponent implements OnInit, OnDestroy {

  @ArrayControl(CartItem) orderForm: FormArray;
  @Control(PaymentInfo) paymentForm: FormGroup;
  @Control(ShippingInfo) shippingForm: FormGroup;
  cartItems$: Observable<CartItem[]>;
  idempotencyKey = guid();
  isLinear = true;
  lkpShippingOptions$: Observable<LookupValue[]>;
  lkpStates$: Observable<LookupValue[]>;
  siteLocation = 'school-store';
  siteLocation$: Observable<string>;
  cost = new CartCost();
  cost$: Observable<CartCost>;
  userId = '';
  userId$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
    this.cartItems$ = cartItemsSelector(this.store);
    this.cost$ = cartCostSelector(this.store);
    this.lkpShippingOptions$ = lookupShippingOptions(this.store);
    this.lkpStates$ = lookupStates(this.store);
    this.siteLocation$ = siteLocationSelector(this.store);
    this.userId$ = currentUserIdSelector(this.store);
  }

  get billingAddress(): Address {
    return getValue(PaymentInfo.Address(this.paymentInfo));
  }

  get chargeInfo(): ChargeInfo {
    return build(ChargeInfo, {
      nonce: this.nonce,
      idempotencyKey: this.idempotencyKey,
      amount: this.totalPennies,
      userId: this.userId,
      shippingAddress: this.shippingAddress,
      billingAddress: this.billingAddress
    });
  }

  get costChanges(): Subscription {
    return this.cost$.subscribe(x => {
      this.cost = x;
    });
  }

  get inSchoolStore(): boolean {
    return this.siteLocation === 'school-store';
  }

  get inSupplyStore(): boolean {
    return this.siteLocation === 'supply-store';
  }

  get nonce(): string {
    return localStorage.getItem('CVIMS_SQUARE_NONCE');
  }

  get paymentInfo(): PaymentInfo {
    return this.paymentForm.value;
  }

  get siteLocationChanges(): Subscription {
    return this.siteLocation$.subscribe(x => {
      this.siteLocation = x;
    });
  }

  get shippingInfo(): ShippingInfo {
    return this.shippingForm.value;
  }

  get shippingAddress(): Address {
    return getValue(ShippingInfo.Address(this.shippingInfo));
  }

  get shippingCost(): number {
    return this.cost.shippingCost;
  }

  get subtotal(): number {
    return this.cost.subtotal;
  }

  get tax(): number {
    return this.cost.tax;
  }

  get total(): number {
    return this.cost.total;
  }

  get totalPennies(): number {
    return Math.ceil(this.total * 100);
  }

  get userIdChanges(): Subscription {
    return this.userId$.subscribe(id => {
      this.userId = id;
      this.getCartItems();
    });
  }

  ngOnInit() {
    this.subscribe([this.costChanges, this.siteLocationChanges, this.userIdChanges]);
    this.dispatch(SidenavActions.close());
  }

  ngOnDestroy() {
    localStorage.setItem('CVIMS_SQUARE_NONCE', '');
  }

  changeNonce(nonce: string) {
    (<FormGroup>this.paymentForm.controls['cardInfo']).controls['nonce'].setValue(nonce);
  }

  changeShippingOption(optionId: number) {
    this.dispatch(CartActions.setShippingOption(optionId));
  }

  getCartItems() {
    this.dispatch(HttpActions.get(`cartitems`, CartActions.GET));
  }

  removeFromCart(cartItemId: number) {
    const action = HttpActions.delete(`cartitems/${cartItemId}`, cartItemId, CartItemActions.REMOVE);
    this.dispatchAndSubscribe(action);
  }

  submitCharge(order: Order) {
    console.dir(this.chargeInfo);
    const action1 = HttpActions.post('Payments/Charge', this.chargeInfo, CartActions.CHARGE);
    const onSuccess = e => {
      const order = build(Order, {
        userId: this.userId,
        firstName: this.
      });
      const action2 = HttpActions.post(`orders`, order, OrdersActions.POST);
      this.dispatch(action2);
    };
    this.dispatchAndSubscribe(action1);
  }

  updateCartItem(cartItem: CartItem) {
    const action = HttpActions.put(`cartitems/${cartItem.id}`, cartItem, CartItemActions.UPDATE);
    this.dispatchAndSubscribe(action);
  }

}
