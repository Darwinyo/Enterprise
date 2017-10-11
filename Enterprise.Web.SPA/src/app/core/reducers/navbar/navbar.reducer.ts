import * as fromAuth from './../../../auth/reducers/auth-state.reducer';
import * as NavbarActions from './../../actions/navbar.actions';
export interface State {
    logged: boolean;
    loginMenuDropped: boolean;
    userMenuDropped: boolean;
    notifMenuDropped: boolean;
    cartMenuDropped: boolean;
}

export const INITIAL_STATE = {
    logged: false,
    loginMenuDropped: false,
    userMenuDropped: false,
    notifMenuDropped: false,
    cartMenuDropped: false
}

export function navbarReducer(state = INITIAL_STATE, action: NavbarActions.Actions): State {
    switch (action.type) {
        case NavbarActions.NAV_LOGGED: {
            return {
                ...state,
                logged: !state.logged
            }
        }
        case NavbarActions.TOGGLE_CART: {
            return {
                ...state,
                cartMenuDropped: !state.cartMenuDropped
            }
        }
        case NavbarActions.TOGGLE_LOGIN: {
            return {
                ...state,
                loginMenuDropped: !state.loginMenuDropped
            }
        }
        case NavbarActions.TOGGLE_NOTIF: {
            return {
                ...state,
                notifMenuDropped: !state.notifMenuDropped
            }
        }
        case NavbarActions.TOGGLE_USER: {
            return {
                ...state,
                userMenuDropped: !state.userMenuDropped
            }
        }

        default:
            return state;
    }
}

export const getLoginMenu = (state: State) => state.loginMenuDropped;
export const getUserMenu = (state: State) => state.userMenuDropped;
export const getNotifMenu = (state: State) => state.notifMenuDropped;
export const getCartMenu = (state: State) => state.cartMenuDropped;
export const getLogged = (state: State) => state.logged;

