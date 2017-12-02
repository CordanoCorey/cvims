import { NgModule } from '@angular/core';

import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';
import { SharedModule } from '../shared/shared.module';
import { ProductViewComponent } from './product-view/product-view.component';

@NgModule({
  imports: [
    SharedModule,
    ProductRoutingModule
  ],
  declarations: [ProductComponent, ProductViewComponent]
})
export class ProductModule { }
