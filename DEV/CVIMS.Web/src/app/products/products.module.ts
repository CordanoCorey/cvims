import { NgModule } from '@angular/core';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductsComponent } from './products.component';
import { ProductPreviewComponent } from './product-preview/product-preview.component';
import { CategoriesModule } from '../categories/categories.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    SharedModule,
    ProductsRoutingModule,
    CategoriesModule,
  ],
  declarations: [
    ProductsComponent,
    ProductPreviewComponent,
  ]
})
export class ProductsModule { }
