import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatSidenav } from '@angular/material';
import { Store, SmartComponent, Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { SidenavActions, CurrentUserActions } from '../actions';
import { QueryItem } from '../models';
import { sidenavOpenedSelector, siteLocationSelector } from '../selectors';

@Component({
  selector: 'cv-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.scss']
})
export class ContainerComponent extends SmartComponent implements OnInit {

  @Input() query: QueryItem[] = [];
  @ViewChild(MatSidenav) sidenav;
  sidenavOpened = true;
  sidenavOpened$: Observable<boolean>;
  siteLocation$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
    this.sidenavOpened$ = sidenavOpenedSelector(this.store);
    this.siteLocation$ = siteLocationSelector(this.store);
  }

  get sidenavOpenedChanges(): Subscription {
    return this.sidenavOpened$.subscribe(x => {
      this.sidenavOpened = x;
    });
  }

  ngOnInit() {
    this.subscribe([this.sidenavOpenedChanges]);
  }

  logout() {
    this.dispatch(CurrentUserActions.logout());
  }

  toggleSidebar() {
    this.dispatch(SidenavActions.toggle());
  }

}
