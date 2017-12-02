import { Injectable } from '@angular/core';
import { Effect, Actions } from '@caiu/effects';
import { RouterActions } from '@caiu/router';
import { Action, Observable } from '@caiu/store';

import { CurrentUserActions } from './actions';

@Injectable()
export class CurrentUserEffects {

    /**
     * Navigate to root url upon successful login.
     */
    @Effect() onLoginSuccess: Observable<Action> = this.actions$
        .ofType(CurrentUserActions.LOGIN)
        .map(action => RouterActions.navigate('/'));

    /**
     * Navigate to login page after logging out.
     */
    @Effect() onLogout: Observable<Action> = this.actions$
        .ofType(CurrentUserActions.LOGOUT)
        .map(action => RouterActions.navigate('/login'));

    constructor(private actions$: Actions) {
    }
}
