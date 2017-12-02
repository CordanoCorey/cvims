import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CartComponent } from './cart.component';

const ROUTES: Routes = [
  {
    path: '',
    component: CartComponent,
    data: { routeName: 'cart', routeLabel: 'Cart' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class CartRoutingModule { }
