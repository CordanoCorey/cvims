import { Component, OnInit, Input } from '@angular/core';
import { FormArray } from '@caiu/forms';

import { CartItem } from '../cart.model';

@Component({
  selector: 'cv-cart-details',
  templateUrl: './cart-details.component.html',
  styleUrls: ['./cart-details.component.scss']
})
export class CartDetailsComponent implements OnInit {

  @Input() cartItems: CartItem[] = [];
  @Input() cartPreview = false;
  @Input() form: FormArray;
  @Input() siteLocation = 'school-store';

  constructor() { }

  get cartLink(): string {
    return `/${this.siteLocation}/cart`;
  }

  get preview(): boolean {
    return this.cartPreview;
  }

  ngOnInit() {
  }

  getProductLink(productId: number): string {
    return `/${this.siteLocation}/products/${productId}`;
  }

}
