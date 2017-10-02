import * as AuthActions from './../../actions/auth.actions';
import { RegistrationFailure } from './../../actions/auth.actions';

export interface State {
    error: string | null;
    pending: boolean;
}

export const INITIAL_STATE: State = {
    error: null,
    pending: false
};

export function registrationReducer(state = INITIAL_STATE, action: AuthActions.Actions): State {
    switch (action.type) {
        case AuthActions.REGISTRATION: {
            return {
                ...state,
                pending: true,
                error: null
            }
        }

        case AuthActions.REGISTRATION_FAILURE: {
            return {
                ...state,
                pending: false,
                error: (<RegistrationFailure>action).payload
            }
        }

        case AuthActions.REGISTRATION_SUCCESS: {
            return {
                ...state,
                pending: false,
                error: null
            }
        }
        default:
            return state;
    }
}

export const getRegistrationError = (state: State) => state.error;
export const getRegistrationPending = (state: State) => state.pending;
