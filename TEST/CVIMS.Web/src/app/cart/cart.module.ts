import { NgModule } from '@angular/core';

import { CartRoutingModule } from './cart-routing.module';
import { CartComponent } from './cart.component';
import { CartDetailsComponent } from './cart-details/cart-details.component';
import { CartItemComponent } from './cart-item/cart-item.component';
import { CartWidgetComponent } from './cart-widget/cart-widget.component';
import { ChargeComponent } from './charge/charge.component';
import { PaymentComponent } from './payment/payment.component';
import { ShippingComponent } from './shipping/shipping.component';
import { SharedModule } from '../shared/shared.module';
import { CartItemsComponent } from './cart-items/cart-items.component';
import {CartPreviewComponent} from './cart-preview/cart-preview.component';


@NgModule({
  imports: [
    SharedModule,
    CartRoutingModule
  ],
  declarations: [
    CartComponent,
    CartDetailsComponent,
    CartItemComponent,
    CartItemsComponent,
    CartPreviewComponent,
    CartWidgetComponent,
    ChargeComponent,
    PaymentComponent,
    ShippingComponent,
  ],
  exports: [
    CartItemsComponent,
    CartWidgetComponent,
  ]
})
export class CartModule { }
