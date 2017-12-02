import { NgModule } from '@angular/core';

import { CategoriesComponent } from './categories.component';
import { CategoriesMenuComponent } from './categories-menu/categories-menu.component';
import { CategoriesRoutingModule } from './categories-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    SharedModule,
    CategoriesRoutingModule,
  ],
  declarations: [
    CategoriesComponent,
    CategoriesMenuComponent
  ],
  exports: [
    CategoriesMenuComponent
  ]
})
export class CategoriesModule { }
