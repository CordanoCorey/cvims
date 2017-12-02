import { Component, OnInit, Input, EventEmitter, Output, OnDestroy, OnChanges } from '@angular/core';
import { FormGroup, AbstractControl } from '@angular/forms';
import { build, DumbComponent } from '@caiu/core';
import { Control, FormComponent } from '@caiu/forms';
import { Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { CartItem } from '../cart.model';
import { Product } from '../../products/products.model';

@Component({
  selector: 'cv-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.scss']
})
export class CartItemComponent extends DumbComponent implements OnChanges, OnInit, OnDestroy {

  @Input() cartItem: CartItem = new CartItem();
  @Input() form: FormGroup;
  @Input() preview = false;
  @Input() siteLocation = 'school-store';
  @Output() removeFromCart = new EventEmitter<number>();
  @Output() updateCartItem = new EventEmitter<CartItem>();
  id = 0;
  deleted = false;
  modelChanges = ['id', 'quantity'];
  modelKey = 'cartItem';
  quantity = 0;
  quantity$: Observable<number>;

  constructor() {
    super();
  }

  get isSchoolStore(): boolean {
    return this.product.siteLocationName === 'school-store';
  }
  get isSupplyStore(): boolean {
    return this.product.siteLocationName === 'supply-store';
  }

  get product(): Product {
    return this.cartItem.product;
  }

  get cartItemId(): number {
    return this.cartItem.id;
  }

  get description(): string {
    return this.product.productDescription;
  }

  get formValue(): CartItem {
    return this.form ? this.form.value : new CartItem();
  }

  get hasChanged(): boolean {
    return this.quantityChanged;
  }

  get hasDescription(): boolean {
    return this.description && this.description !== this.productName;
  }

  get hasSize(): boolean {
    return !!this.size;
  }

  get idChanged(): boolean {
    return this.cartItemId !== this.id;
  }

  get inStock(): boolean {
    return !this.outOfStock;
  }

  get maxQuantity(): number {
    return Math.max(1, this.quantityInStock);
  }

  get outOfStock(): boolean {
    return this.quantityInStock === 0;
  }

  get productId(): number {
    return this.cartItem.productId;
  }

  get productImageSrc(): string {
    return 'assets/images/easy.jpg';
  }

  get productLink(): string {
    return this.product.link;
  }

  get productName(): string {
    return this.product.productName;
  }

  get quantityChanged(): boolean {
    return this.quantityInCart !== this.quantity;
  }

  get quantityControl(): AbstractControl {
    return this.form && this.form.controls ? this.form.controls['quantity'] : null;
  }

  get quantityInCart(): number {
    return this.cartItem.quantity;
  }

  get quantityInStock(): number {
    return this.product.quantityInStock;
  }

  get showDescription(): boolean {
    return this.hasDescription && !this.preview;
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

  get tax(): number {
    return this.cartItem.tax;
  }

  get totalPrice(): number {
    return this.quantityInCart * this.unitPrice + this.tax;
  }

  get unitPrice(): number {
    return this.product.retailPrice;
  }

  get userId(): string {
    return this.cartItem.userId;
  }

  get valueOut(): CartItem {
    return build(CartItem, this.cartItem, {
      id: this.cartItemId,
      quantity: this.quantity
    });
  }

  ngOnChanges() {
    if (this.cartItemId !== 0 && this.hasChanged) {
      this.id = this.cartItemId;
      this.quantity = this.quantityInCart;
    }
  }

  ngOnInit() {
  }

  clickQuantity(e: any) {
    this.quantity = this.quantityControl.value;
    if (this.quantityChanged && this.quantityControl.valid && !this.deleted) {
      this.onUpdateCartItem();
    }
  }

  onRemoveFromCart() {
    this.removeFromCart.emit(this.cartItemId);
  }

  onUpdateCartItem() {
    this.updateCartItem.emit(this.valueOut);
  }

}
