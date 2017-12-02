import { Component, OnInit } from '@angular/core';
import { build, toInt } from '@caiu/core';
import { EventsService } from '@caiu/events';
import { HttpActions } from '@caiu/http';
import { routeParamIdSelector } from '@caiu/router';
import { SmartComponent, Store, Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { Product } from '../products/products.model';
import { productSelector, ProductsActions, ProductActions, productCartItemIdSelector } from '../products/products.reducer';
import { CartItem } from '../cart/cart.model';
import { CartActions, CartItemActions } from '../cart/cart.reducer';
import { SidenavActions } from '../shared/actions';
import { currentUserIdSelector } from '../shared/selectors';

@Component({
  selector: 'cv-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent extends SmartComponent implements OnInit {

  product$: Observable<Product>;
  productId = 0;
  productId$: Observable<number>;
  userId = '';
  userId$: Observable<string>;

  constructor(public store: Store<any>, public events: EventsService) {
    super(store);
    this.product$ = productSelector(this.store);
    this.productId$ = routeParamIdSelector(this.store, 'productId');
    this.userId$ = currentUserIdSelector(this.store);
  }

  get productIdChanges(): Subscription {
    return this.productId$.subscribe(id => {
      this.productId = id;
      this.dispatch(ProductsActions.activate(this.productId));
      if (this.productId) {
        this.getProduct(this.productId);
      }
    });
  }

  get userIdChanges(): Subscription {
    return this.userId$.subscribe(id => {
      this.userId = id;
    });
  }

  ngOnInit() {
    this.subscribe([this.productIdChanges, this.userIdChanges]);
    this.dispatch(SidenavActions.open());
  }

  addToCart(cartItem: CartItem) {
    const action = HttpActions.post(`cartitems`, cartItem, CartActions.ADD);
    const onSuccess = e => { this.dispatch(SidenavActions.open()); };
    this.dispatchAndSubscribe(action, onSuccess);
  }

  getProduct(productId: number) {
    this.dispatch(HttpActions.get(`products/${productId}`, ProductActions.GET));
  }

  onAddToCart(cartItemDetails = {}) {
    const cartItem = build(CartItem, cartItemDetails, {
      userId: this.userId.toString(),
      productId: this.productId
    });
    this.addToCart(cartItem);
  }

  onRemoveFromCart(cartItemId: number) {
    this.removeFromCart(cartItemId);
  }

  onUpdateCartItem(cartItemDetails = {}) {
    const cartItem = build(CartItem, cartItemDetails, {
      userId: this.userId.toString(),
      productId: this.productId
    });
    this.updateCartItem(cartItem);
  }

  removeFromCart(cartItemId: number) {
    const action = HttpActions.delete(`cartitems/${cartItemId}`, cartItemId, CartItemActions.REMOVE);
    const onSuccess = e => { this.flashSuccessMessage(); };
    this.dispatchAndSubscribe(action, onSuccess);
  }

  updateCartItem(cartItem: CartItem) {
    const action = HttpActions.put(`cartitems/${cartItem.id}`, cartItem, CartItemActions.UPDATE);
    const onSuccess = e => { this.dispatch(SidenavActions.open()); };
    this.dispatchAndSubscribe(action, onSuccess);
  }

}
