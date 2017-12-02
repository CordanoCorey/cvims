import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SupplyStoreComponent } from './supply-store.component';

const ROUTES: Routes = [
  {
    path: '',
    component: SupplyStoreComponent,
    data: { routeName: 'supply-store', routeLabel: 'Supplies Store' },
    children: [
      { path: '', redirectTo: 'categories', pathMatch: 'full' },
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
export class SupplyStoreRoutingModule { }
