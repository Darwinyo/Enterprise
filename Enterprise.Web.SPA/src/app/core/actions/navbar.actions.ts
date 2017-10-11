import { UserLoginViewModel } from './../../auth/viewmodels/user-login/user-login.viewmodel';
import { Action } from '@ngrx/store';
export const TOGGLE_LOGIN = '[NAVBAR] TOGGLE_LOGIN';
export const TOGGLE_CART = '[NAVBAR] TOGGLE_CART';
export const TOGGLE_NOTIF = '[NAVBAR] TOGGLE_NOTIF';
export const TOGGLE_USER = '[NAVBAR] TOGGLE_USER';
export const NAV_LOGGED = '[NAVBAR] NAV_LOGGED';

export class ToggleLogin implements Action {
    readonly type: string = TOGGLE_LOGIN;
}
export class ToggleCart implements Action {
    readonly type: string = TOGGLE_CART;
}
export class ToggleNotif implements Action {
    readonly type: string = TOGGLE_NOTIF;
}
export class ToggleUser implements Action {
    readonly type: string = TOGGLE_USER;
}
export class NavLogged implements Action {
    readonly type: string = NAV_LOGGED;
}
export type Actions =
    | ToggleCart
    | ToggleLogin
    | ToggleNotif
    | ToggleUser
    | NavLogged;
