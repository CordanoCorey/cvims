import { Component, OnInit, Input } from '@angular/core';
import { routeNameSelector, urlSelector } from '@caiu/router';
import { SmartComponent, Store, Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { SidenavActions } from '../actions';

@Component({
  selector: 'cv-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent extends SmartComponent implements OnInit {

  @Input() siteLocation = 'school-store';
  dashboardUrl = '/dashboard';
  schoolStoreUrl = '/school-store';
  supplyStoreUrl = '/supply-store';
  url = '/';
  url$: Observable<string>;
  warehouseUrl = '/warehouse';

  constructor(public store: Store<any>) {
    super(store);
    this.url$ = urlSelector(this.store);
  }

  get categoriesLink(): string {
    return `/${this.siteLocation}/categories`;
  }

  get inOrders(): boolean {
    return this.url.startsWith(this.ordersLink);
  }

  get inProducts(): boolean {
    return this.url.startsWith(this.productsLink);
  }

  get inSchoolStore(): boolean {
    return this.url.startsWith(this.schoolStoreUrl);
  }

  get inSupplyStore(): boolean {
    return this.url.startsWith(this.supplyStoreUrl);
  }

  get inWarehouse(): boolean {
    return this.url.startsWith(this.warehouseUrl);
  }

  get onDashboard(): boolean {
    return this.url.startsWith(this.dashboardUrl);
  }

  get onOrders(): boolean {
    return this.url === this.ordersLink;
  }

  get onProduct(): boolean {
    return this.inProducts && !this.onProducts;
  }

  get onProducts(): boolean {
    return this.url === this.productsLink;
  }

  get onSectionHome(): boolean {
    return this.onDashboard || this.onSchoolStoreHome || this.onSupplyStoreHome || this.onWarehouseHome;
  }

  get onSchoolStoreHome(): boolean {
    return this.url === this.schoolStoreUrl;
  }

  get onSupplyStoreHome(): boolean {
    return this.url === this.supplyStoreUrl;
  }

  get onWarehouseHome(): boolean {
    return this.url === this.warehouseUrl;
  }

  get ordersLink(): string {
    return `/${this.siteLocation}/orders`;
  }

  get productsLink(): string {
    return `/${this.siteLocation}/products`;
  }

  get urlChanges(): Subscription {
    return this.url$.subscribe(url => {
      this.url = url;
      this.refresh();
    });
  }

  ngOnInit() {
    this.subscribe([this.urlChanges]);
  }

  refresh() {
    setTimeout(() => {
      if (this.onDashboard) {
        this.openSidenav();
      } else if (this.onProducts || this.inOrders) {
        this.closeSidenav();
      }
    }, 0);
  }

  closeSidenav() {
    this.dispatch(SidenavActions.close());
  }

  openSidenav() {
    this.dispatch(SidenavActions.open());
  }

  toggleSidenav() {
    this.dispatch(SidenavActions.toggle());
  }

}
