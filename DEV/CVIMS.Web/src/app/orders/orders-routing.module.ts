import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrdersComponent } from './orders.component';

const ROUTES: Routes = [
  {
    path: '',
    children: [
      { path: '', pathMatch: 'full', component: OrdersComponent, data: { routeName: 'orders', routeLabel: 'Orders' } },
      { path: ':orderId', loadChildren: 'app/order/order.module#OrderModule' },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
