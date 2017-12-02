import { build, Token } from '@caiu/core';
import { LookupValue } from '@caiu/http';
import { StorageActions } from '@caiu/storage';
import { Action } from '@caiu/store';

import { ConfigActions, CurrentUserActions, SidenavActions, SiteLocationActions } from './actions';
import { SITE_LOCATIONS } from './lookup';
import { CurrentUser, Config, User } from './models';
import { findSiteLocationById } from './utils';

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

        case CurrentUserActions.UPDATE_GUEST_ID:
            return build(CurrentUser, state, { guestId: action.payload });

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

export function siteLocationReducer(state = SITE_LOCATIONS[0], action: Action): LookupValue {
    switch (action.type) {

        case SiteLocationActions.ACTIVATE:
            return findSiteLocationById(<number>action.payload);

        default:
            return state;
    }
}
