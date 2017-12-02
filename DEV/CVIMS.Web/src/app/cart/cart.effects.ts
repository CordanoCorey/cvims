import { Injectable } from '@angular/core';
import { Effect, Actions } from '@caiu/effects';
import { RouterActions } from '@caiu/router';
import { Action, Observable } from '@caiu/store';

import { OrdersActions } from '../orders/orders.reducer';
import { CartActions } from './cart.reducer';
import { HttpActions } from '@caiu/http';
import { build } from '@caiu/core';
import { Order } from '../orders/orders.model';



@Injectable()
export class CartEffects {

    /**
     * Call add order after successfully charging card.
     */
    @Effect() onChargeSuccess: Observable<Action> = this.actions$
        .ofType(CartActions.CHARGE)
        .map(action => this.getPostOrderAction(action.payload));

    constructor(private actions$: Actions) {
    }

    getPostOrderAction(response: any): Action {
        const order = build(Order, {});
        return HttpActions.post(`orders`, order, OrdersActions.POST);
    }
}
