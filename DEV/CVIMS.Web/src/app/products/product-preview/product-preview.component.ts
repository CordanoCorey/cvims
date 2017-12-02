import { Component, OnInit, Input } from '@angular/core';
import { DumbComponent } from '@caiu/common';

import { Product } from '../products.model';

@Component({
  selector: 'cv-product-preview',
  templateUrl: './product-preview.component.html',
  styleUrls: ['./product-preview.component.scss']
})
export class ProductPreviewComponent extends DumbComponent implements OnInit {
  @Input() product: Product = new Product();

  constructor() {
    super();
  }

  get productDescription(): string {
    return this.product.productDescription;
  }

  get productName(): string {
    return this.product.productName;
  }

  get retailPrice(): number {
    return this.product.retailPrice;
  }

  get sku(): string {
    return this.product.sku;
  }

  get quantityAvailable(): number {
    return this.product.quantityAvailable;
  }

  get productId(): number {
    return this.product.id;
  }

  get productImageSrc(): string {
    return 'assets/images/easy.jpg';
  }

  get productLink(): string {
    return `/${this.siteLocation}/products/${this.productId}`;
  }

  get siteLocation(): string {
    return this.product.siteLocationName;
  }
  get isSchoolStore(): boolean {
    return this.product.siteLocationName === 'school-store';
  }
  get isSupplyStore(): boolean {
    return this.product.siteLocationName === 'supply-store';
  }

  ngOnInit() {
  }

}
