import { Component, OnInit } from '@angular/core';
import { routeNameSelector, urlSelector } from '@caiu/router';
import { SmartComponent, Store, Observable } from '@caiu/store';
import { Subscription } from 'rxjs/Subscription';

import { SidenavActions } from '../actions';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent extends SmartComponent implements OnInit {

  url = '/';
  url$: Observable<string>;

  constructor(public store: Store<any>) {
    super(store);
    this.url$ = urlSelector(this.store);
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
    }, 0);
  }

  toggleSidenav() {
    this.dispatch(SidenavActions.open());
  }

}
