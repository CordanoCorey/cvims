import { Component, OnInit, Input } from '@angular/core';
import { Grid, GridColumn, SortDescriptor } from '@caiu/common';

import { Order, OrderRow } from '../orders.model';

@Component({
  selector: 'cv-orders-grid',
  templateUrl: './orders-grid.component.html',
  styleUrls: ['./orders-grid.component.scss']
})
export class OrdersGridComponent implements OnInit {

  @Input() orders: Order[] = [];
  @Input() siteLocation = 'school-store';
  private _sort: SortDescriptor[] = [
    Grid.BuildSort('orderDate', 'desc')
  ];

  constructor() { }

  get grid(): Grid<OrderRow> {
    return Grid.Build<OrderRow>(this.rows);
  }

  get rows(): OrderRow[] {
    return this.orders.map(order => new OrderRow(order));
  }

  get orderDateColumn(): GridColumn<Date> {
    return new GridColumn<Date>('orderDate', 'Order Date');
  }

  get customerNameColumn(): GridColumn<string> {
    return new GridColumn<string>('customerName', 'Customer Name');
  }

  get orderNumberColumn(): GridColumn<string> {
    return new GridColumn<string>('orderNumber', 'Order Number');
  }

  get sort(): SortDescriptor[] {
    return this._sort;
  }

  set sort(value: SortDescriptor[]) {
    this._sort = value;
  }

  ngOnInit() {
  }

  getProductLink(orderId: number): string {
    return `/${this.siteLocation}/orders${orderId}`;
  }

}
