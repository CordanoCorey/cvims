import {Component, Input, OnInit} from '@angular/core';
import { SmartComponent, Store, Observable } from '@caiu/store';

import { CartItem } from '../cart.model';
import { cartItemsSelector, CartActions } from '../cart.reducer';
import { siteLocationSelector, currentUserIdSelector } from '../../shared/selectors';
import { Subscription } from 'rxjs/Subscription';
import { HttpActions } from '@caiu/http';

@Component({
  selector: 'cv-cart-widget',
  templateUrl: './cart-widget.component.html',
  styleUrls: ['./cart-widget.component.scss']
})
export class CartWidgetComponent extends SmartComponent implements OnInit {
  @Input() cartPreview = true;
  cartItems$: Observable<CartItem[]>;
  siteLocation = 'school-store';
  siteLocation$: Observable<string>;
  userId = '';
  userId$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
    this.cartItems$ = cartItemsSelector(this.store);
    this.siteLocation$ = siteLocationSelector(this.store);
    this.userId$ = currentUserIdSelector(this.store);
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
    this.subscribe([this.siteLocationChanges, this.userIdChanges]);
  }

  getCartItems() {
    this.dispatch(HttpActions.get(`cartitems`, CartActions.GET));
  }

}
