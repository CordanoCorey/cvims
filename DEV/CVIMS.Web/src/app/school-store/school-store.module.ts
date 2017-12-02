import { NgModule } from '@angular/core';

import { SchoolStoreRoutingModule } from './school-store-routing.module';
import { SchoolStoreComponent } from './school-store.component';
import { CartModule } from '../cart/cart.module';
import { CategoriesModule } from '../categories/categories.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    SharedModule,
    SchoolStoreRoutingModule,
    CartModule,
    CategoriesModule,
  ],
  declarations: [SchoolStoreComponent]
})
export class SchoolStoreModule { }
