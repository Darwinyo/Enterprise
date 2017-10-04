import * as fromAuth from './auth/auth.reducer';
import * as fromLogin from './login/login.reducer';
import * as fromRegistration from './registration/registration.reducer';
import * as fromRoot from './../../reducers/app-state.reducer'
import { createFeatureSelector, createSelector } from '@ngrx/store';

export interface AuthState {
    userState: fromAuth.State;
    loginState: fromLogin.State;
    registrationState: fromRegistration.State;
}

export interface State extends fromRoot.State {
    authState: AuthState;
}

export const authStateReducer = {
    userReducer: fromAuth.authReducer,
    loginReducer: fromLogin.loginReducer,
    registrationReducer: fromRegistration.registrationReducer
}

export const selectAuthState = createFeatureSelector<AuthState>('auth');

export const selectUserState = createSelector(
    selectAuthState,
    (state: AuthState) => state.userState
);
export const getLoggedIn = createSelector(
    selectUserState,
    fromAuth.getLoggedIn
);
export const getUserLogin = createSelector(
    selectUserState,
    fromAuth.getUserLogin
);
export const getuserKey = createSelector(
    selectUserState,
    fromAuth.getUserKey
);

export const selectLoginState = createSelector(
    selectAuthState,
    (state: AuthState) => state.loginState
);

export const getLoginError = createSelector(
    selectLoginState,
    fromLogin.getLoginError
);
export const getLoginPending = createSelector(
    selectLoginState,
    fromLogin.getLoginPending
);

export const selectRegistrationState = createSelector(
    selectAuthState,
    (state: AuthState) => state.registrationState
);

export const getRegistrationError = createSelector(
    selectLoginState,
    fromRegistration.getRegistrationError
);
export const getRegistrationPending = createSelector(
    selectLoginState,
    fromRegistration.getRegistrationPending
);
