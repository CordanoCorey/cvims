import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard.component';

const ROUTES: Routes = [
  {
    path: '',
    component: DashboardComponent,
    data: { routeName: 'dashboard', routeLabel: 'Dashboard' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
