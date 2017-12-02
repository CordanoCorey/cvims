import { NgModule, Injectable } from '@angular/core';
import { Routes, RouterModule, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, PreloadAllModules } from '@angular/router';
import { Observable, Store } from '@caiu/store';

import { authenticatedSelector } from './shared/selectors';

@Injectable()
export class AuthenticatedGuard implements CanActivate {

  constructor(public store: Store<any>) { }

  get authenticated$(): Observable<boolean> {
    return authenticatedSelector(this.store);
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
    return this.authenticated$;
  }

}

const ROUTES: Routes = [
  {
    path: '',
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'login' },
      { path: 'admin', loadChildren: 'app/admin/admin.module#AdminModule' },
      { path: 'dashboard', loadChildren: 'app/dashboard/dashboard.module#DashboardModule', canActivate: [AuthenticatedGuard] },
      { path: 'login', loadChildren: 'app/login/login.module#LoginModule' },
      { path: 'reset-password', loadChildren: 'app/reset-password/reset-password.module#ResetPasswordModule' },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(ROUTES, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule],
  providers: [
    AuthenticatedGuard,
  ]
})
export class AppRoutingModule { }
