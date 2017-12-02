import { build } from '@caiu/core';
import { Action, Store, Observable } from '@caiu/store';

import { Products, Product, ProductsQuery } from './products.model';
import { CartItem } from '../cart/cart.model';
import { CartActions, cartItemByProductIdSelector, CartItemActions } from '../cart/cart.reducer';
import { CategoriesActions, categoriesSelector } from '../categories/categories.reducer';
import { SiteLocationActions } from '../shared/actions';
import { QueryItem } from '../shared/models';

export class ProductsActions {
    static ACTIVATE = '[Products] Activate Product';
    static FIND = '[Products] Find Products';
    static GET = '[Products] Get Products';
    static GET_FAVORITES = '[Products] Get Favorites';

    static activate(productId: number): Action {
        return {
            type: ProductsActions.ACTIVATE,
            payload: productId
        };
    }
}

export class ProductActions {
    static GET = '[Products] Get Product';
}

export function productsReducer(state: Products = new Products(), action: Action): Products {

    switch (action.type) {

        case ProductsActions.ACTIVATE:
            return build(Products, state, state.activate(action.payload));

        case ProductsActions.FIND:
            return build(Products, state, state.update(<Product[]>action.payload.results));

        case ProductsActions.GET:
            return build(Products, state, state.update(<Product[]>action.payload));

        case ProductsActions.GET_FAVORITES:
            return build(Products, state.update(<Product[]>action.payload));

        case ProductActions.GET:
            return build(Products, state, state.update(<Product>action.payload));

        case CartActions.GET:
            return build(Products, state, state.update(<Product[]>(<CartItem[]>action.payload).map(x => x.product)));

        case CartItemActions.UPDATE:
            return build(Products, state, state.update(<Product>(<CartItem>action.payload).product));

        case CategoriesActions.ACTIVATE:
            return build(Products, state, { categoryId: action.payload });

        case SiteLocationActions.ACTIVATE:
            return build(Products, state, { siteLocationId: action.payload });

        default:
            return state;
    }
}

export function productsSelector(store: Store<any>): Observable<Products> {
    return store.select('products');
}

export function productSelector(store: Store<any>): Observable<Product> {
    const product$ = productsSelector(store).map(products => products.active);
    return product$.mergeMap(product => cartItemByProductIdSelector(store, product.id)
        .map(cartItem => build(Product, product, {
            cartItemId: cartItem.id,
            quantityInCart: cartItem.quantity // will be 0 if not in cart
        })));
}

export function productCartItemIdSelector(store: Store<any>): Observable<number> {
    return productSelector(store).map(product => product.cartItemId).distinctUntilChanged();
}

export function productsArraySelector(store: Store<any>): Observable<Product[]> {
    return productsSelector(store).map(products => products.asArray);
}

export function productsQuerySelector(store: Store<any>): Observable<ProductsQuery> {
    return productsSelector(store).map(products => products.queryModel);
}

export function productsQueryItemsSelector(store: Store<any>): Observable<QueryItem[]> {
    const categories$ = categoriesSelector(store);
    const query$ = productsQuerySelector(store);
    return Observable.combineLatest(categories$, query$, ProductsQuery.QueryItems);
}

export function productsQueryStringSelector(store: Store<any>): Observable<string> {
    return productsSelector(store).map(products => products.queryString)
        .distinctUntilChanged();
}

export function productsSearchSelector(store: Store<any>): Observable<Product[]> {
    return productsSelector(store).map(products => products.searchResults);
}

export function productIdsSelector(store: Store<any>, ids: number[]): Observable<Product[]> {
    return productsSelector(store).map(products => ids.map(id => products.get(id)));
}

export function productsCategorySelector(store: Store<any>): Observable<number> {
    return productsSelector(store).map(products => products.categoryId).distinctUntilChanged();
}
