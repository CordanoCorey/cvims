import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { Order } from '../../orders/orders.model';
import { OrderComponent } from '../../order/order.component';

@Component({
  selector: 'cv-charge',
  templateUrl: './charge.component.html',
  styleUrls: ['./charge.component.scss']
})
export class ChargeComponent implements OnInit {

  @Input() order: Order = new Order();
  @Output() submitCharge = new EventEmitter<Order>();

  constructor() { }

  ngOnInit() {
  }

  submitOrder() {
    this.submitCharge.emit(this.order);
  }

}
