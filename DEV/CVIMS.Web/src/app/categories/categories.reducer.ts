import { build } from '@caiu/core';
import { Action, Store, Observable } from '@caiu/store';

import { Categories, Category } from './categories.model';
import { siteLocationSelector } from '../shared/selectors';

export class CategoriesActions {
    static ACTIVATE = '[Categories] Activate Category';
    static GET = '[Categories] Get Categories';

    static activate(categoryId: number): Action {
        return {
            type: CategoriesActions.ACTIVATE,
            payload: categoryId
        };
    }
}

export function categoriesReducer(state: Categories = new Categories(), action: Action): Categories {
    switch (action.type) {

        case CategoriesActions.ACTIVATE:
            return build(Categories, state.activate(action.payload));

        case CategoriesActions.GET:
            return build(Categories, state.update(<Category[]>action.payload));

        default:
            return state;
    }
}

export function categoriesSelector(store: Store<any>): Observable<Categories> {
    return store.select('categories');
}

export function categorySelector(store: Store<any>): Observable<Category> {
    return categoriesSelector(store).map(categories => categories.active);
}

export function allCategoriesSelector(store: Store<any>): Observable<Category[]> {
    return categoriesSelector(store).map(categories => categories.toArray());
}

export function schoolStoreCategoriesSelector(store: Store<any>): Observable<Category[]> {
    return allCategoriesSelector(store).map(categories => categories.filter(x => x.locationId === 2));
}

export function supplyStoreCategoriesSelector(store: Store<any>): Observable<Category[]> {
    return allCategoriesSelector(store).map(categories => categories.filter(x => x.locationId === 1));
}

export function sectionCategoriesSelector(store: Store<any>): Observable<Category[]> {
    const siteLocation$ = siteLocationSelector(store);
    return siteLocation$.mergeMap(x => {
        switch (x) {
            case 'school-store':
                return schoolStoreCategoriesSelector(store);
            case 'supply-store':
                return supplyStoreCategoriesSelector(store);
            case 'warehouse':
                return allCategoriesSelector(store);
            default:
                return Observable.of([]);
        }
    });
}

export function categoryNameSelector(store: Store<any>): Observable<string> {
    return categorySelector(store).map(category => category.label).distinctUntilChanged();
}
