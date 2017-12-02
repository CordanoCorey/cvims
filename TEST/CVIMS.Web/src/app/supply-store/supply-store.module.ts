import { NgModule } from '@angular/core';

import { SupplyStoreRoutingModule } from './supply-store-routing.module';
import { SupplyStoreComponent } from './supply-store.component';
import { CartModule } from '../cart/cart.module';
import { CategoriesModule } from '../categories/categories.module';
import { SharedModule } from '../shared/shared.module';
@NgModule({
  imports: [
    SharedModule,
    SupplyStoreRoutingModule,
    CartModule,
    CategoriesModule,
  ],
  declarations: [SupplyStoreComponent]
})
export class SupplyStoreModule { }
