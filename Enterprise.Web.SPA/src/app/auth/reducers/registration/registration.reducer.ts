import { RegistrationFailure } from './../../actions/registration-page.actions';
import * as RegistrationActions from './../../actions/registration-page.actions';

export interface State {
    error: string | null;
    pending: boolean;
}

export const INITIAL_STATE: State = {
    error: null,
    pending: false
};

export function registrationReducer(state = INITIAL_STATE, action: RegistrationActions.Actions): State {
    switch (action.type) {
        case RegistrationActions.REGISTRATION: {
            return {
                ...state,
                pending: true,
                error: null
            }
        }

        case RegistrationActions.REGISTRATION_FAILURE: {
            return {
                ...state,
                pending: false,
                error: (<RegistrationFailure>action).payload
            }
        }

        case RegistrationActions.REGISTRATION_SUCCESS: {
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
