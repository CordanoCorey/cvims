import { build } from '@caiu/core';
import { Action, Store, Observable } from '@caiu/store';

import { Orders, Order } from './orders.model';

export class OrdersActions {
    static GET = '[Orders] Get Orders';
    static POST = '[Orders] Add Order';

    static post(response: any): Action {
        return {
            type: OrdersActions.POST,
            payload: response
        };
    }
}

export function ordersReducer(state: Orders = new Orders(), action: Action): Orders {
    switch (action.type) {

        case OrdersActions.GET:
            return build(Orders, state.update(<Order[]>action.payload));

        default:
            return state;
    }
}

export function ordersSelector(store: Store<any>): Observable<Orders> {
    return store.select('orders');
}

export function ordersSearchSelector(store: Store<any>): Observable<Order[]> {
    return ordersSelector(store).map(orders => orders.searchResults);
}
