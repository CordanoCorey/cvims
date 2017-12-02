import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { build, guid } from '@caiu/core';
import { HttpActions, HttpService, LookupService, Lookup } from '@caiu/http';
import { RouterService, routeNameSelector } from '@caiu/router';
import { StorageService, StorageActions } from '@caiu/storage';
import { Store, Observable } from '@caiu/store';

import { CategoriesActions } from './categories/categories.reducer';
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
    public http: HttpService,
    public router: RouterService,
    public storage: StorageService,
    public lookup: LookupService) {
    this.routeName$ = routeNameSelector(this.store);
  }

  get guestId(): string {
    return localStorage.getItem('CVIMS_GUEST_ID');
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
    this.loadConfiguration();
    this.initStorage();
    this.initHttp();
    this.initLookup();
    this.getCategories();
  }

  getCategories() {
    this.store.dispatch(HttpActions.get(`categories`, CategoriesActions.GET));
  }

  initHttp() {
    let guestId = this.guestId;
    if (!guestId) {
      guestId = guid();
      localStorage.setItem('CVIMS_GUEST_ID', guestId);
    }
    this.http.headers = { guestId };
    this.store.dispatch(CurrentUserActions.updateGuestId(guestId));
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
