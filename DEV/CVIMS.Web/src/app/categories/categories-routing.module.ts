import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CategoriesComponent } from './categories.component';

const ROUTES: Routes = [
  {
    path: '',
    children: [
      { path: '', pathMatch: 'full', component: CategoriesComponent, data: { routeName: 'categories', routeLabel: 'Categories' } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class CategoriesRoutingModule { }
