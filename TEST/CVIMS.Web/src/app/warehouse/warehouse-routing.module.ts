import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WarehouseComponent } from './warehouse.component';

const ROUTES: Routes = [
  {
    path: '',
    component: WarehouseComponent,
    data: { routeName: 'warehouse', routeLabel: 'Warehouse' },
    children: [
      { path: '', redirectTo: 'categories', pathMatch: 'full' },
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
export class WarehouseRoutingModule { }
