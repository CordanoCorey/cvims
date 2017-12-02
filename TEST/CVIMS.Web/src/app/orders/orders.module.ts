import { NgModule } from '@angular/core';

import { OrdersRoutingModule } from './orders-routing.module';
import { OrdersComponent } from './orders.component';
import { SharedModule } from '../shared/shared.module';
import { OrdersGridComponent } from './orders-grid/orders-grid.component';

@NgModule({
  imports: [
    SharedModule,
    OrdersRoutingModule
  ],
  declarations: [OrdersComponent, OrdersGridComponent]
})
export class OrdersModule { }
