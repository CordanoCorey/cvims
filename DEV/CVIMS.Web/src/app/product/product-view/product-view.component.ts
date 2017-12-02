import { Component, OnInit, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { FormGroup, AbstractControl } from '@angular/forms';
import { DumbComponent } from '@caiu/common';
import { Control } from '@caiu/forms';
import { Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { Product, ProductDetails } from '../../products/products.model';

@Component({
  selector: 'cv-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.scss']
})
export class ProductViewComponent extends DumbComponent implements OnChanges, OnInit {
  foods = [
    { value: 'xs', viewValue: 'xs' },
    { value: 'sm', viewValue: 'sm' },
    { value: 'md', viewValue: 'md' },
    { value: 'lg', viewValue: 'lg' },
    { value: 'xl', viewValue: 'xl' }
  ];
  @Input() product: Product = new Product();
  @Output() addToCart = new EventEmitter<ProductDetails>();
  @Output() removeFromCart = new EventEmitter<number>();
  @Output() updateCartItem = new EventEmitter<ProductDetails>();
  @Control(ProductDetails) form: FormGroup;
  message1 = 'Quantity added to cart cannot exceed quantity in stock.';
  message2 = 'This item is out of stock.';
  quantity = 0;
  quantity$: Observable<number>;

  constructor() {
    super();
    this.quantity$ = this.quantityControl.valueChanges.distinctUntilChanged();
  }

  get canAddToCart(): boolean {
    return !this.isInCart && this.quantityInStock > 0;
  }

  get canRemoveFromCart(): boolean {
    return this.isInCart;
  }

  get cartItemId(): number {
    return this.product.cartItemId;
  }

  get formValue(): ProductDetails {
    return this.form ? this.form.value : new ProductDetails();
  }

  get hasProductDescription(): boolean {
    return this.productDescription && this.productDescription !== this.productName;
  }

  get hasSize(): boolean {
    return this.size ? true : false;
  }

  get isInCart(): boolean {
    return this.product.isInCart;
  }

  get isOutOfStock(): boolean {
    return this.quantityInStock === 0;
  }

  get maxQuantity(): number {
    return Math.max(1, this.quantityInStock);
  }

  get message(): string {
    return 'An error occurred. Please try agin later.';
  }

  get price(): number {
    return this.product.retailPrice;
  }

  get productDescription(): string {
    return this.product.productDescription;
  }

  get productDetails(): ProductDetails {
    return Object.assign({}, this.form.value, { id: this.cartItemId, quantity: this.quantity });
  }

  get productImageSrc(): string {
    return 'assets/images/easy.jpg';
  }

  get productName(): string {
    return this.product.productName;
  }

  get quantityChanged(): boolean {
    return this.quantityInCart !== this.quantity;
  }

  get quantityChanges(): Subscription {
    return this.quantity$.subscribe(x => {
      this.quantity = x;
      if (this.isInCart && this.quantityChanged && this.quantityControl.valid) {
        this.onUpdateCartItem();
      }
    });
  }

  get quantityControl(): AbstractControl {
    return this.form.controls['quantity'];
  }

  get quantityInCart(): number {
    return this.product.quantityInCart;
  }

  get quantityInStock(): number {
    return this.product.quantityInStock;
  }

  get size(): string {
    return this.product.sizeName;
  }

  get sizeId(): number {
    return this.product.sizeId;
  }

  get sku(): string {
    return this.product.sku;
  }

  ngOnChanges() {
    if (ProductDetails.HasChanged(this.product, this.formValue)) {
      this.form.setValue({
        quantity: Math.max(1, this.quantityInCart),
        size: this.sizeId
      });
    }
  }

  ngOnInit() {
    this.subscribe([this.quantityChanges]);
  }

  onAddToCart() {
    this.addToCart.emit(this.productDetails);
  }

  onRemoveFromCart() {
    this.removeFromCart.emit(this.cartItemId);
  }

  onUpdateCartItem() {
    this.updateCartItem.emit(this.productDetails);
  }

}
