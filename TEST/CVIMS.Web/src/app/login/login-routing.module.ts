import { NgModule } from '@angular/core';
import { Routes, RouterModule, Route } from '@angular/router';

import { LoginComponent } from './login.component';

const LoginRoute: Route = {
  path: '',
  component: LoginComponent,
  data: { routeName: 'login', routeLabel: 'Login' }
};

const ROUTES: Routes = [LoginRoute];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
  providers: []
})
export class LoginRoutingModule { }
