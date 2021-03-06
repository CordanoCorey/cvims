import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SettingsComponent } from './settings.component';

const ROUTES: Routes = [
  {
    path: '',
    component: SettingsComponent,
    data: { routeName: 'settings', routeLabel: 'Settings' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class SettingsRoutingModule { }
