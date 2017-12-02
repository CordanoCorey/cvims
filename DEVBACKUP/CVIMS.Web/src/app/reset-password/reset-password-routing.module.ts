import { NgModule } from '@angular/core';
import { Routes, RouterModule, Route } from '@angular/router';
import { ResetPasswordComponent } from './reset-password.component';

const ResetPasswordRoute: Route = {
  path: '',
  component: ResetPasswordComponent,
  data: { routeName: 'reset-password', routeLabel: 'Reset Password' }
};

const ROUTES: Routes = [ResetPasswordRoute];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
  providers: []
})
export class ResetPasswordRoutingModule { }
