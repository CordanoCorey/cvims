import { build, Token } from '@caiu/core';
import { StorageActions } from '@caiu/storage';
import { Action } from '@caiu/store';

import { ConfigActions, CurrentUserActions, SidenavActions } from './actions';
import { CurrentUser, Config, User } from './models';

export function configReducer(state: Config = new Config(), action: Action): Config {
    switch (action.type) {

        case ConfigActions.INITIALIZE:
            return build(Config, state, action.payload);

        default:
            return state;
    }
}

export function currentUserReducer(state: CurrentUser = new CurrentUser(), action: Action): CurrentUser {
    switch (action.type) {

        case StorageActions.INIT_STORE:
            return build(CurrentUser, action.payload.localStore ? action.payload.localStore.currentUser : {});

        case CurrentUserActions.LOGIN:
            const token = build(Token, {
                access_token: action.payload.access_token,
                expires_in: action.payload.expires_in
            });
            return build(CurrentUser, state, <User>action.payload.user, { token });

        case CurrentUserActions.LOGOUT:
            return build(CurrentUser, { token: new Token() });

        case CurrentUserActions.RESET_PASSWORD:
            return build(CurrentUser, state, <User>action.payload);

        default:
            return state;

    }
}

export function sidenavReducer(state = true, action: Action): boolean {
    switch (action.type) {

        case SidenavActions.CLOSE:
            return false;

        case SidenavActions.OPEN:
            return true;

        case SidenavActions.TOGGLE:
            return !state;

        default:
            return state;
    }
}
