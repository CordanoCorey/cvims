import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductsComponent } from './products.component';

const ROUTES: Routes = [
  {
    path: '',
    children: [
      { path: '', pathMatch: 'full', component: ProductsComponent, data: { routeName: 'products', routeLabel: 'Products' } },
      { path: ':productId', loadChildren: 'app/product/product.module#ProductModule' },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
