import { createSelector } from '@ngrx/store';
import * as AuthActions from './../../actions/auth.actions';
import { Login, LoginFailure } from './../../actions/auth.actions';

export interface State {
    error: string | null;
    pending: boolean;
}

export const INITIAL_STATE: State = {
    error: null,
    pending: false
};

export function loginReducer(state = INITIAL_STATE, action: AuthActions.Actions): State {
    switch (action.type) {
        case AuthActions.LOG_IN: {
            return {
                ...state,
                error: null,
                pending: true
            };
        }

        case AuthActions.LOG_IN_SUCCESS: {
            return {
                ...state,
                error: null,
                pending: false
            };
        }

        case AuthActions.LOG_IN_FAILURE: {
            return {
                ...state,
                error: (<LoginFailure>action).payload,
                pending: false
            }
        }

        default:
            return state;
    }
}

export const getLoginError = (state: State) => state.error;
export const getLoginPending = (state: State) => state.pending;
