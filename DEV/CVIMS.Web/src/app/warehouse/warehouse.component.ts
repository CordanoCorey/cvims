import { Component, OnInit } from '@angular/core';
import { SmartComponent, Store, Observable } from '@caiu/store';

import { Category } from '../categories/categories.model';
import { allCategoriesSelector } from '../categories/categories.reducer';
import { productsQueryItemsSelector } from '../products/products.reducer';
import { SiteLocationActions } from '../shared/actions';
import { QueryItem } from '../shared/models';
import { currentUserIdSelector } from '../shared/selectors';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'cv-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.scss']
})
export class WarehouseComponent extends SmartComponent implements OnInit {

  categories$: Observable<Category[]>;
  query$: Observable<QueryItem[]>;
  userId = '';
  userId$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
    this.categories$ = allCategoriesSelector(this.store);
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
    this.dispatch(SiteLocationActions.activate(3));
  }

}
