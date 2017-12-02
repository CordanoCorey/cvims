import { build, toInt } from '@caiu/core';
import { LookupValue, lookupValuesSelector } from '@caiu/http';
import { Store, Observable } from '@caiu/store';

import { CurrentUser } from './models';
import { findSchoolYear } from './utils';

export function authenticatedSelector(store: Store<any>): Observable<boolean> {
    return currentUserSelector(store).map(user => user.authenticated).take(1);
}

export function currentSchoolYearSelector(store: Store<any>): Observable<string> {
    return Observable.of(findSchoolYear());
}

export function currentUserSelector(store: Store<any>): Observable<CurrentUser> {
    return store.select('currentUser');
}

export function currentUserIdSelector(store: Store<any>): Observable<number> {
    return currentUserSelector(store).map(user => toInt(user.id)).distinctUntilChanged();
}

export function sidenavOpenedSelector(store: Store<any>): Observable<boolean> {
    return (<Observable<boolean>>store.select('sidenav')).distinctUntilChanged();
}
