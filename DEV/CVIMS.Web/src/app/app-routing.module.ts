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
  { path: '', pathMatch: 'full', redirectTo: 'dashboard' },
  { path: 'admin', loadChildren: 'app/admin/admin.module#AdminModule' },
  { path: 'dashboard', loadChildren: 'app/dashboard/dashboard.module#DashboardModule' },
  { path: 'login', loadChildren: 'app/login/login.module#LoginModule' },
  { path: 'school-store', loadChildren: 'app/school-store/school-store.module#SchoolStoreModule' },
  { path: 'supply-store', loadChildren: 'app/supply-store/supply-store.module#SupplyStoreModule' },
  { path: 'warehouse', loadChildren: 'app/warehouse/warehouse.module#WarehouseModule' },
];

@NgModule({
  imports: [RouterModule.forRoot(ROUTES, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule],
  providers: [
    AuthenticatedGuard,
  ]
})
export class AppRoutingModule { }
