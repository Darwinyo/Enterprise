import { environment } from './../../environments/environment';
import { RouterStateUrl } from './../shared/utils';
import * as fromRouter from '@ngrx/router-store';
import { MetaReducer, ActionReducerMap, ActionReducer, createSelector, createFeatureSelector } from '@ngrx/store';
import { storeFreeze } from 'ngrx-store-freeze';

export interface State {
    routerReducer: fromRouter.RouterReducerState<RouterStateUrl>;
}
export const routerReducers: ActionReducerMap<State> = {
    routerReducer: fromRouter.routerReducer
}
export function logger(reducer: ActionReducer<State>): ActionReducer<State> {
    return function (state: State, action: any): State {
        console.log('state', state);
        console.log('action', action);

        return reducer(state, action);
    };
}
export const metaReducers: MetaReducer<State>[] = !environment.production
    ? [logger, storeFreeze] : [];
