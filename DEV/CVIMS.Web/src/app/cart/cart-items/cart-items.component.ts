import { Component, OnInit, Input } from '@angular/core';
import { Grid, GridColumn, SortDescriptor } from '@caiu/common';

import { CartItem, CartItemRow } from '../cart.model';

@Component({
  selector: 'cv-cart-items',
  templateUrl: './cart-items.component.html',
  styleUrls: ['./cart-items.component.scss']
})
export class CartItemsComponent implements OnInit {

  @Input() cartItems: CartItem[] = [];
  @Input() siteLocation = 'school-store';
  private _sort: SortDescriptor[] = [
    Grid.BuildSort('lastModifiedDate', 'desc')
  ];

  constructor() { }

  get grid(): Grid<CartItemRow> {
    return Grid.Build<CartItemRow>(this.rows);
  }

  get rows(): CartItemRow[] {
    return this.cartItems.map(cartItem => new CartItemRow(cartItem));
  }

  get lastModifiedDateColumn(): GridColumn<Date> {
    return new GridColumn<Date>('lastModifiedDate', 'Last Modified');
  }

  get productNameColumn(): GridColumn<string> {
    return new GridColumn<string>('productName', 'Item');
  }

  get quantityColumn(): GridColumn<string> {
    return new GridColumn<string>('quantity', 'Quantity');
  }

  get sort(): SortDescriptor[] {
    return this._sort;
  }

  set sort(value: SortDescriptor[]) {
    this._sort = value;
  }

  ngOnInit() {
  }

  getProductLink(productId: number): string {
    return `/${this.siteLocation}/products${productId}`;
  }

}
