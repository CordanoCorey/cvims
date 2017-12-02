import { NgModule } from '@angular/core';

import { OrderRoutingModule } from './order-routing.module';
import { OrderComponent } from './order.component';
import { SharedModule } from '../shared/shared.module';
import { OrderViewComponent } from './order-view/order-view.component';

@NgModule({
  imports: [
    SharedModule,
    OrderRoutingModule
  ],
  declarations: [OrderComponent, OrderViewComponent]
})
export class OrderModule { }
