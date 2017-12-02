import { Component, Input, OnInit } from '@angular/core';
import { SmartComponent, Store, Observable } from '@caiu/store';

import { CartItem, CartCost } from '../cart.model';
import { cartItemsSelector, CartActions, CartItemActions, cartCostSelector } from '../cart.reducer';
import { siteLocationSelector, currentUserIdSelector } from '../../shared/selectors';
import { Subscription } from 'rxjs/Subscription';
import { HttpActions } from '@caiu/http';
import { ArrayControl, FormArray } from '@caiu/forms';

@Component({
  selector: 'cv-cart-widget',
  templateUrl: './cart-widget.component.html',
  styleUrls: ['./cart-widget.component.scss']
})
export class CartWidgetComponent extends SmartComponent implements OnInit {

  @ArrayControl(CartItem) formArray: FormArray;
  @Input() cartPreview = true;
  cartItems$: Observable<CartItem[]>;
  cost = new CartCost();
  cost$: Observable<CartCost>;
  siteLocation = 'school-store';
  siteLocation$: Observable<string>;
  userId = '';
  userId$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
    this.cartItems$ = cartItemsSelector(this.store);
    this.cost$ = cartCostSelector(this.store);
    this.siteLocation$ = siteLocationSelector(this.store);
    this.userId$ = currentUserIdSelector(this.store);
  }

  get cartLink(): string {
    return `/${this.siteLocation}/cart`;
  }

  get costChanges(): Subscription {
    return this.cost$.subscribe(x => {
      this.cost = x;
    });
  }

  get siteLocationChanges(): Subscription {
    return this.siteLocation$.subscribe(x => {
      this.siteLocation = x;
    });
  }

  get userIdChanges(): Subscription {
    return this.userId$.subscribe(id => {
      this.userId = id;
      this.getCartItems();
    });
  }

  ngOnInit() {
    this.subscribe([this.costChanges, this.siteLocationChanges, this.userIdChanges]);
  }

  getCartItems() {
    this.dispatch(HttpActions.get(`cartitems`, CartActions.GET));
  }

  removeFromCart(cartItemId: number) {
    const action = HttpActions.delete(`cartitems/${cartItemId}`, cartItemId, CartItemActions.REMOVE);
    this.dispatchAndSubscribe(action);
  }

  updateCartItem(cartItem: CartItem) {
    const action = HttpActions.put(`cartitems/${cartItem.id}`, cartItem, CartItemActions.UPDATE);
    this.dispatchAndSubscribe(action);
  }

}
