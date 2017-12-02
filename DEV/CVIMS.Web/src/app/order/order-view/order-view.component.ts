import { Component, OnInit, Input } from '@angular/core';

import { Order } from '../../orders/orders.model';

@Component({
  selector: 'cv-order-view',
  templateUrl: './order-view.component.html',
  styleUrls: ['./order-view.component.scss']
})
export class OrderViewComponent implements OnInit {

  @Input() order: Order = new Order();

  constructor() { }

  get orderDate(): Date {
    return this.order.orderDate;
  }

  ngOnInit() {
  }

}
