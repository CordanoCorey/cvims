import { Component, OnInit } from '@angular/core';
import { HttpActions } from '@caiu/http';
import { SmartComponent, Store, Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { CartActions } from '../cart/cart.reducer';
import { Category } from '../categories/categories.model';
import { supplyStoreCategoriesSelector } from '../categories/categories.reducer';
import { productsQueryItemsSelector } from '../products/products.reducer';
import { SiteLocationActions } from '../shared/actions';
import { QueryItem } from '../shared/models';
import { currentUserIdSelector } from '../shared/selectors';

@Component({
  selector: 'cv-supply-store',
  templateUrl: './supply-store.component.html',
  styleUrls: ['./supply-store.component.scss']
})
export class SupplyStoreComponent extends SmartComponent implements OnInit {

  categories$: Observable<Category[]>;
  query$: Observable<QueryItem[]>;
  userId = '';
  userId$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
    this.categories$ = supplyStoreCategoriesSelector(this.store);
    this.query$ = productsQueryItemsSelector(this.store);
    this.userId$ = currentUserIdSelector(this.store);
  }

  get userIdChanges(): Subscription {
    return this.userId$.subscribe(id => {
      this.userId = id;
    });
  }

  ngOnInit() {
    this.subscribe([this.userIdChanges]);
    this.dispatch(SiteLocationActions.activate(2));
  }

}
