import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AdminComponent } from './admin.component';

const ROUTES: Routes = [
  {
    path: '',
    component: AdminComponent,
    data: { routeName: 'admin', routeLabel: 'Admin' },
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'settings' },
      { path: 'settings', loadChildren: 'app/admin/settings/settings.module#SettingsModule' },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
