import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material';
import { Store, SmartComponent, Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { SidenavActions, CurrentUserActions } from '../actions';
import { sidenavOpenedSelector } from '../selectors';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.scss']
})
export class ContainerComponent extends SmartComponent implements OnInit {

  @ViewChild(MatSidenav) sidenav;
  sidenavOpened = true;
  sidenavOpened$: Observable<boolean>;

  constructor(public store: Store<any>) {
    super(store);
    this.sidenavOpened$ = sidenavOpenedSelector(this.store);
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
