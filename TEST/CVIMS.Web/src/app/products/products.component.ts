import { Component, OnInit } from '@angular/core';
import { HttpActions } from '@caiu/http';
import { routeParamIdSelector } from '@caiu/router';
import { SmartComponent, Store, Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { Product } from './products.model';
import { productsSearchSelector, ProductsActions, productsQueryStringSelector } from './products.reducer';
import { Category } from '../categories/categories.model';
import { CategoriesActions, sectionCategoriesSelector } from '../categories/categories.reducer';
import { siteLocationSelector } from '../shared/selectors';

@Component({
  selector: 'cv-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent extends SmartComponent implements OnInit {

  categories$: Observable<Category[]>;
  categoryId = 0;
  categoryId$: Observable<number>;
  products$: Observable<Product[]>;
  queryString = '';
  queryString$: Observable<string>;
  siteLocation = 'school-store';
  siteLocation$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
    this.categoryId$ = routeParamIdSelector(this.store, 'categoryId');
    this.products$ = productsSearchSelector(this.store);
    this.queryString$ = productsQueryStringSelector(this.store);
    this.siteLocation$ = siteLocationSelector(this.store);
    this.categories$ = sectionCategoriesSelector(this.store);
  }

  get categoryIdChanges(): Subscription {
    return this.categoryId$.subscribe(id => {
      setTimeout(() => {
        this.categoryId = id;
        this.dispatch(CategoriesActions.activate(id));
      }, 0);
    });
  }

  get queryStringChanges(): Subscription {
    return this.queryString$.subscribe(x => {
      this.queryString = x;
      this.getProducts(this.queryString);
    });
  }

  get siteLocationChanges(): Subscription {
    return this.siteLocation$.subscribe(x => {
      this.siteLocation = x;
    });
  }

  ngOnInit() {
    this.subscribe([this.categoryIdChanges, this.queryStringChanges, this.siteLocationChanges]);
  }

  getProducts(queryString: string) {
    this.dispatch(HttpActions.get(`products${queryString}`, ProductsActions.FIND));
  }

}
