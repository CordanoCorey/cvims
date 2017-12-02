import { build, toInt } from '@caiu/core';
import { LookupValue, lookupValuesSelector } from '@caiu/http';
import { Store, Observable } from '@caiu/store';

import { CurrentUser, QueryItem } from './models';
import { findSchoolYear } from './utils';

export function authenticatedSelector(store: Store<any>): Observable<boolean> {
    return currentUserSelector(store).map(user => user.authenticated).take(1);
}

export function currentSchoolYearSelector(store: Store<any>): Observable<string> {
    return Observable.of(findSchoolYear());
}

export function currentUserSelector(store: Store<any>): Observable<CurrentUser> {
    return store.select('currentUser').map(user => build(CurrentUser, user));
}

export function lookupShippingOptions(store: Store<any>): Observable<LookupValue[]> {
    return lookupValuesSelector(store, 'ShippingOptions_lkp');
}

export function lookupStates(store: Store<any>): Observable<LookupValue[]> {
    return lookupValuesSelector(store, 'State_lkp');
}

export function currentUserIdSelector(store: Store<any>): Observable<string> {
    return currentUserSelector(store).map(user => user.userId).distinctUntilChanged();
}

export function sidenavOpenedSelector(store: Store<any>): Observable<boolean> {
    return (<Observable<boolean>>store.select('sidenav')).distinctUntilChanged();
}

export function siteLocationSelector(store: Store<any>): Observable<string> {
    return (<Observable<LookupValue>>store.select('siteLocation'))
        .map(x => x.name)
        .distinctUntilChanged();
}
