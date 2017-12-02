import { NgModule } from '@angular/core';

import { WarehouseRoutingModule } from './warehouse-routing.module';
import { WarehouseComponent } from './warehouse.component';
import { CategoriesModule } from '../categories/categories.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    SharedModule,
    WarehouseRoutingModule,
    CategoriesModule,
  ],
  declarations: [WarehouseComponent]
})
export class WarehouseModule { }
