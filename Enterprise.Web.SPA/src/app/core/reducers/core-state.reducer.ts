import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromAuth from './../../auth/reducers/auth-state.reducer';
import * as fromNavbar from './../reducers/navbar/navbar.reducer';

export interface CoreState {
    navbarState: fromNavbar.State;
}
export interface State extends fromAuth.State {
    coreState: CoreState;
}

export const coreStateReducer = {
    navbarState: fromNavbar.navbarReducer
}
export const selectCoreState = createFeatureSelector<CoreState>('core');

export const selectNavbarState = createSelector(
    selectCoreState,
    (state: CoreState) => state.navbarState
)
export const getLoginMenuState = createSelector(
    selectNavbarState,
    fromNavbar.getLoginMenuState
);
export const getUserMenuState = createSelector(
    selectNavbarState,
    fromNavbar.getUserMenuState
);
export const getNotifMenuState = createSelector(
    selectNavbarState,
    fromNavbar.getNotifMenuState
);
export const getCartMenuState = createSelector(
    selectNavbarState,
    fromNavbar.getCartMenuState
);
export const getLoggedState = createSelector(
    selectNavbarState,
    fromNavbar.getLoggedState
);