import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Control, ArrayControl } from '@caiu/forms';
import { HttpActions, LookupValue } from '@caiu/http';
import { SmartComponent, Store, Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { ChargeInfo, PaymentInfo, CartItem } from './cart.model';
import { CartActions, cartItemsSelector, cartSubtotalSelector, cartTaxSelector, cartTotalSelector } from './cart.reducer';
import { SidenavActions } from '../shared/actions';
import { ShippingInfo } from '../shared/models';
import { siteLocationSelector, currentUserIdSelector, lookupShippingOptions, lookupStates } from '../shared/selectors';
import { environment } from '../../environments/environment';

@Component({
  selector: 'cv-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent extends SmartComponent implements OnInit, OnDestroy {

  @ArrayControl(CartItem) orderForm: FormGroup;
  @Control(PaymentInfo) paymentForm: FormGroup;
  @Control(ShippingInfo) shippingForm: FormGroup;
  cartItems$: Observable<CartItem[]>;
  isLinear = true;
  lkpShippingOptions$: Observable<LookupValue[]>;
  lkpStates$: Observable<LookupValue[]>;
  siteLocation = 'school-store';
  siteLocation$: Observable<string>;
  subtotal = 0;
  subtotal$: Observable<number>;
  tax = 0;
  tax$: Observable<number>;
  total = 0;
  total$: Observable<number>;
  userId = '';
  userId$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
    this.cartItems$ = cartItemsSelector(this.store);
    this.lkpShippingOptions$ = lookupShippingOptions(this.store);
    this.lkpStates$ = lookupStates(this.store);
    this.siteLocation$ = siteLocationSelector(this.store);
    this.subtotal$ = cartSubtotalSelector(this.store);
    this.tax$ = cartTaxSelector(this.store);
    this.total$ = cartTotalSelector(this.store);
    this.userId$ = currentUserIdSelector(this.store);
  }

  get nonce(): string {
    return localStorage.getItem('CVIMS_SQUARE_NONCE');
  }

  get siteLocationChanges(): Subscription {
    return this.siteLocation$.subscribe(x => {
      this.siteLocation = x;
    });
  }

  get subtotalChanges(): Subscription {
    return this.subtotal$.subscribe(x => {
      this.subtotal = x;
    });
  }

  get taxChanges(): Subscription {
    return this.tax$.subscribe(x => {
      this.tax = x;
    });
  }

  get totalChanges(): Subscription {
    return this.total$.subscribe(x => {
      this.total = x;
    });
  }

  get userIdChanges(): Subscription {
    return this.userId$.subscribe(id => {
      this.userId = id;
      this.getCartItems();
    });
  }

  ngOnInit() {
    this.subscribe([this.siteLocationChanges, this.subtotalChanges, this.taxChanges, this.totalChanges, this.userIdChanges]);
    this.dispatch(SidenavActions.close());
  }

  ngOnDestroy() {
    localStorage.setItem('CVIMS_SQUARE_NONCE', '');
  }

  changeNonce(nonce: string) {
    console.log(nonce);
  }

  getCartItems() {
    this.dispatch(HttpActions.get(`cartitems`, CartActions.GET));
  }

  submitCharge(e: any) {
    console.log('Charge card', e);
    const model = new ChargeInfo();
    model.nonce = this.nonce;
    model.idempotencyKey = 'kljhxcljdhcldjkfhcdjklfdhfld';
    model.amount = 350;

    this.dispatch(HttpActions.post('Payments/Charge', model, CartActions.CHARGE));
  }

}
