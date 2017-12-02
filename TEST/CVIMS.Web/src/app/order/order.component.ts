import { Component, OnInit } from '@angular/core';
import { SmartComponent, Store, Observable } from '@caiu/store';

import { Order } from '../orders/orders.model';

@Component({
  selector: 'cv-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent extends SmartComponent implements OnInit {

  order$: Observable<Order>;

  constructor(public store: Store<any>) {
    super(store);
  }

  ngOnInit() {
  }

}
