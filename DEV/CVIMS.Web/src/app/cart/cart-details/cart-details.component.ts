import { Component, OnInit, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { build, equals } from '@caiu/core';
import { FormArray, FormArrayComponent } from '@caiu/forms';

import { CartItem } from '../cart.model';

@Component({
  selector: 'cv-cart-details',
  templateUrl: './cart-details.component.html',
  styleUrls: ['./cart-details.component.scss']
})
export class CartDetailsComponent extends FormArrayComponent implements OnChanges, OnInit {

  @Input() cartItems: CartItem[] = [];
  @Input() preview = false;
  @Input() formArray: FormArray;
  @Input() siteLocation = 'school-store';
  @Output() removeFromCart = new EventEmitter<number>();
  @Output() updateCartItem = new EventEmitter<CartItem>();
  totalCartItems = 0;

  constructor() {
    super();
  }

  get cartLink(): string {
    return `/${this.siteLocation}/cart`;
  }

  get controls(): AbstractControl[] {
    return this.formArray && this.formArray.controls ? this.formArray.controls : [];
  }

  get hasChanged(): boolean {
    return !equals(FormArray.GetValue(this.cartItems, CartItem), this.formArray.value);
  }

  ngOnChanges() {
    if (this.formArray && this.hasChanged) {
      this.totalCartItems = this.cartItems.length;
      this.formArray.setValue(this.cartItems);
    }
  }

  ngOnInit() {
  }

  findCartItem(control: AbstractControl): CartItem {
    const id = control.value['id'];
    return build(CartItem, this.cartItems.find(x => x.id === id));
  }

  getProductLink(productId: number): string {
    return `/${this.siteLocation}/products/${productId}`;
  }

}
