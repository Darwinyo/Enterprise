import { LOG_IN_SUCCESS, LoginSuccess } from './../../actions/auth.actions';
import { Action } from '@ngrx/store';

import { UserLoginResponseModel } from './../../models/responses/user-login-response/user-login-response.model';
import * as AuthActions from '../../actions/auth.actions';

export interface State {
    userKey: string;
    userLogin: string;
    isLogged: boolean;
}
export const INITIAL_STATE = {
    userKey: undefined,
    userLogin: undefined,
    isLogged: false
}

export function authReducer(state = INITIAL_STATE, action: AuthActions.Actions): State {
    switch (action.type) {
        case AuthActions.LOG_IN_SUCCESS: {
            return {
                ...state,
                userKey: (<LoginSuccess>action).payload.userKey,
                userLogin: (<LoginSuccess>action).payload.userLogin,
                isLogged: (<LoginSuccess>action).payload.isLogged,
            };
        }
        case AuthActions.LOG_OUT: {
            return Object.assign({}, state, INITIAL_STATE)
        }
        default:
            return state;
    }
}

export const getLoggedIn = (state: State) => state.isLogged;
export const getUserLogin = (state: State) => state.userLogin;
export const getUserKey = (state: State) => state.userKey;
