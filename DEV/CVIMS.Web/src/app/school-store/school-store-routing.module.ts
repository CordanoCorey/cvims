import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SchoolStoreComponent } from './school-store.component';

const ROUTES: Routes = [
  {
    path: '',
    component: SchoolStoreComponent,
    data: { routeName: 'school-store', routeLabel: 'School Store' },
    children: [
      { path: '', redirectTo: 'products', pathMatch: 'full' },
      { path: 'cart', loadChildren: 'app/cart/cart.module#CartModule' },
      { path: 'categories', loadChildren: 'app/categories/categories.module#CategoriesModule' },
      { path: 'orders', loadChildren: 'app/orders/orders.module#OrdersModule' },
      { path: 'products', loadChildren: 'app/products/products.module#ProductsModule' },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class SchoolStoreRoutingModule { }
