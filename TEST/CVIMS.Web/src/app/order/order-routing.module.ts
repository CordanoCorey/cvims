import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrderComponent } from './order.component';

const ROUTES: Routes = [
  {
    path: '',
    component: OrderComponent,
    data: { routeName: 'order', routeLabel: 'Order' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class OrderRoutingModule { }
