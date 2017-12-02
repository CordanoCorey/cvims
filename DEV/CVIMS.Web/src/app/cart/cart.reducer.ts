import { build } from '@caiu/core';
import { Action, Store, Observable } from '@caiu/store';

import { Cart, CartItem, CartCost } from './cart.model';
import { Product } from '../products/products.model';
import { productIdsSelector, productsSelector } from '../products/products.reducer';
import { siteLocationSelector } from '../shared/selectors';

export class CartActions {
    static GET = '[Cart] Get Cart';
    static ADD = '[Cart] Add Cart Item';
    static CHARGE = '[Cart] Charge Cart';
    static SET_SHIPPING_OPTION = '[Cart] Set Shipping Option';

    static setShippingOption(optionId: number): Action {
        return {
            type: CartActions.SET_SHIPPING_OPTION,
            payload: optionId
        };
    }
}

export class CartItemActions {
    static REMOVE = '[CartItem] Remove Cart Item';
    static UPDATE = '[CartItem] Update Cart Item';
}

export function cartReducer(state: Cart = new Cart(), action: Action): Cart {

    switch (action.type) {

        case CartActions.GET:
            return build(Cart, state, state.update(<CartItem[]>action.payload));

        case CartActions.ADD:
            return build(Cart, state, state.update(<CartItem>action.payload));

        case CartActions.SET_SHIPPING_OPTION:
            return build(Cart, state, { shippingOptionId: <number>action.payload });

        case CartItemActions.REMOVE:
            return build(Cart, state, state.delete(<number>action.payload));

        case CartItemActions.UPDATE:
            return build(Cart, state, state.update(<CartItem>action.payload));

        default:
            return state;
    }
}

export function cartSelector(store: Store<any>): Observable<Cart> {
    return store.select('cart');
}

export function cartItemIdsSelector(store: Store<any>): Observable<number[]> {
    return cartSelector(store).map(cart => cart.asArray.map(x => x.productId));
}

export function allCartItemsSelector(store: Store<any>): Observable<CartItem[]> {
    return Observable.combineLatest(cartSelector(store), productsSelector(store), (cart, products) => {
        return cart.asArray.map(cartItem => {
            const product = products.findBy(x => x.id === cartItem.productId);
            return build(CartItem, cartItem, { product });
        });
    });
}

export function cartItemsSelector(store: Store<any>): Observable<CartItem[]> {
    const siteLocation$ = siteLocationSelector(store);
    return siteLocation$.mergeMap(siteLocation => {
        switch (siteLocation) {
            case 'school-store':
                return schoolStoreCartItemsSelector(store);
            case 'supply-store':
                return staffStoreCartItemsSelector(store);
            default:
                return Observable.of([]);
        }
    });
}

export function schoolStoreCartItemsSelector(store: Store<any>): Observable<CartItem[]> {
    return allCartItemsSelector(store).map(items => items.filter(x => x.schoolStore));
}

export function staffStoreCartItemsSelector(store: Store<any>): Observable<CartItem[]> {
    return allCartItemsSelector(store).map(items => items.filter(x => x.staffStore));
}

export function cartItemProductsSelector(store: Store<any>): Observable<Product[]> {
    const ids$ = cartItemIdsSelector(store);
    return ids$.mergeMap(ids => productIdsSelector(store, ids));
}

export function cartItemByProductIdSelector(store: Store<any>, productId: number): Observable<CartItem> {
    return cartSelector(store).map(cart => cart.findBy(x => x.productId === productId));
}

export function cartCostSelector(store: Store<any>): Observable<CartCost> {
    return Observable.combineLatest(
        cartShippingCostSelector(store), cartSubtotalSelector(store), cartTaxSelector(store), cartTotalSelector(store),
        (shippingCost, subtotal, tax, total) => ({ shippingCost, subtotal, tax, total }));
}

export function cartShippingCostSelector(store: Store<any>): Observable<number> {
    return cartSelector(store).map(cart => cart.shippingCost).distinctUntilChanged();
}

export function cartSubtotalSelector(store: Store<any>): Observable<number> {
    return cartSelector(store).map(cart => cart.subtotal).distinctUntilChanged();
}

export function cartTaxSelector(store: Store<any>): Observable<number> {
    return cartSelector(store).map(cart => cart.tax).distinctUntilChanged();
}

export function cartTotalSelector(store: Store<any>): Observable<number> {
    return cartSelector(store).map(cart => cart.total).distinctUntilChanged();
}

