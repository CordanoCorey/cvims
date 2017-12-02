import { Action } from '@caiu/store';

import { Config } from './models';

export class ConfigActions {
    static INITIALIZE = '[Config] Initialize Configuration';

    static initialize(config: Config): Action {
        return {
            type: ConfigActions.INITIALIZE,
            payload: config
        };
    }
}

export class CurrentUserActions {
    static LOGIN = '[CurrentUser] Login';
    static LOGOUT = '[CurrentUser] Logout';
    static RESET_PASSWORD = '[CurrentUser] Reset';
    static UPDATE_GUEST_ID = '[CurrentUser] Update Guest ID';
    static ALL = [
        CurrentUserActions.LOGIN,
        CurrentUserActions.LOGOUT,
        CurrentUserActions.RESET_PASSWORD,
        CurrentUserActions.UPDATE_GUEST_ID,
    ];

    static logout(): Action {
        return {
            type: CurrentUserActions.LOGOUT
        };
    }

    static updateGuestId(id: string): Action {
        return {
            type: CurrentUserActions.UPDATE_GUEST_ID,
            payload: id
        };
    }
}

export class SidenavActions {
    static CLOSE = '[Sidenav] Close';
    static OPEN = '[Sidenav] Open';
    static TOGGLE = '[Sidenav] Toggle';

    static close(): Action {
        return {
            type: SidenavActions.CLOSE
        };
    }

    static open(): Action {
        return {
            type: SidenavActions.OPEN
        };
    }

    static toggle(): Action {
        return {
            type: SidenavActions.TOGGLE
        };
    }
}

export class SiteLocationActions {
    static ACTIVATE = '[SiteLocation] Activate';

    static activate(payload: number): Action {
        return {
            type: SiteLocationActions.ACTIVATE,
            payload
        };
    }
}
