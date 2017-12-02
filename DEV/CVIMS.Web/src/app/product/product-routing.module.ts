import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductComponent } from './product.component';

const ROUTES: Routes = [
  {
    path: '',
    component: ProductComponent,
    data: { routeName: 'product', routeLabel: 'Product' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
