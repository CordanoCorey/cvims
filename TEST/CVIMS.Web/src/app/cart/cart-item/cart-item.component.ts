import { Component, OnInit, Input } from '@angular/core';

import { CartItem } from '../cart.model';
import { Product } from '../../products/products.model';

@Component({
  selector: 'cv-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.scss']
})
export class CartItemComponent implements OnInit {
  outOfStock= true;
  foods = [
    {value: 'xs', viewValue: 'xs'},
    {value: 'sm', viewValue: 'sm'},
    {value: 'md', viewValue: 'md'},
    {value: 'lg', viewValue: 'lg'},
    {value: 'xl', viewValue: 'xl'}
  ];
 // @Input() product: Product = new Product();

  @Input() cartItem: CartItem = new CartItem();
  @Input() siteLocation = 'school-store';

  constructor() { }

  get product(): Product {
    return this.cartItem.product;
  }

  get hasProductDescription(): boolean {
    return this.productDescription && this.productDescription !== this.productName;
  }

  get hasSize(): boolean {
    return !!this.size;
  }

  get inStock(): boolean {
    return this.outOfStock;
  }

  get price(): number {
    return this.product.retailPrice;
  }

  get productDescription(): string {
    return this.product.productDescription;
  }

  get productImageSrc(): string {
    return 'assets/images/easy.jpg';
  }

  get productName(): string {
    return this.product.productName;
  }

  get quantityInStock(): number {
    return this.product.quantityInStock;
  }

  get size(): string {
    return this.product.sizeName;
  }

  get sku(): string {
    return this.product.sku;
  }

  get productId(): number {
    return this.cartItem.productId;
  }

  get productLink(): string {
    return `/${this.siteLocation}/products/${this.productId}`;
  }

  ngOnInit() {
  }

}
