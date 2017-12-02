import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { build } from '@caiu/core';
import { HttpActions, LookupService, Lookup } from '@caiu/http';
import { RouterService, routeNameSelector } from '@caiu/router';
import { StorageService, StorageActions } from '@caiu/storage';
import { Store, Observable } from '@caiu/store';

import { ConfigActions, CurrentUserActions } from './shared/actions';
import { CurrentUser } from './shared/models';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  routeName$: Observable<string>;

  constructor(
    public store: Store<any>,
    public router: RouterService,
    public storage: StorageService,
    public lookup: LookupService) {
    this.routeName$ = routeNameSelector(this.store);
  }

  get localStorageActions(): string[] {
    return [
      ...CurrentUserActions.ALL,
    ];
  }

  get localStorageMapper(): (s: any) => any {
    return state => {
      const currentUser = build(CurrentUser, state['currentUser']);
      return { currentUser };
    };
  }

  get lookupKeys(): string[] {
    return [];
  }

  get lookupValues(): Lookup[] {
    return [];
  }

  get sessionStorageActions(): string[] {
    return [];
  }

  get sessionStorageMapper(): (s: any) => any {
    return state => { };
  }

  ngOnInit() {
    // this.loadConfiguration();
    // this.initStorage();
    // this.initLookup();
  }

  initLookup() {
    this.lookup.load(this.lookupKeys, this.lookupValues);
  }

  initStorage() {
    this.storage.init(this.localStorageMapper, this.sessionStorageMapper, this.localStorageActions, this.sessionStorageActions);
  }

  loadConfiguration() {
    this.store.dispatch(ConfigActions.initialize(environment));
  }

}
