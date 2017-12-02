import { Component, OnInit } from '@angular/core';
import { SmartComponent, Store, Observable } from '@caiu/store';

import { ordersSearchSelector } from './orders.reducer';
import { Order } from '../orders/orders.model';
import { siteLocationSelector } from '../shared/selectors';

@Component({
  selector: 'cv-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent extends SmartComponent implements OnInit {

  orders$: Observable<Order[]>;
  siteLocation$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
    this.orders$ = ordersSearchSelector(this.store);
    this.siteLocation$ = siteLocationSelector(this.store);
  }

  ngOnInit() {
  }

}
