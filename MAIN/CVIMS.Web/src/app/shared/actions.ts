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
    static ALL = [CurrentUserActions.LOGIN, CurrentUserActions.LOGOUT, CurrentUserActions.RESET_PASSWORD];

    static logout(): Action {
        return {
            type: CurrentUserActions.LOGOUT
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
