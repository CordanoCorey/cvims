import { Injectable } from '@angular/core';
import { Effect, Actions } from '@caiu/effects';
import { RouterActions } from '@caiu/router';
import { Action, Observable } from '@caiu/store';

import { OrdersActions } from '../orders/orders.reducer';
import { Order } from './orders.model';



@Injectable()
export class OrdersEffects {

    /**
     * Navigate to order receipt after sucessfully adding order.
     */
    @Effect() onAddOrder: Observable<Action> = this.actions$
        .ofType(OrdersActions.POST)
        .map(action => this.redirectToReceipt(<Order>action.payload));

    constructor(private actions$: Actions) {
    }

    redirectToReceipt(order: Order): Action {
        const url = `/orders/${order.id}`;
        return RouterActions.navigate(url);
    }
}
