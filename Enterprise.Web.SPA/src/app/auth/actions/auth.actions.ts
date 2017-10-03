import { UserLoginModel } from './../models/user/user-login/user-login.model';
import { UserLoginViewModel } from './../viewmodels/user-login/user-login.viewmodel';
import { UserLoginResponseModel } from './../models/responses/user-login-response/user-login-response.model';
import { Action } from '@ngrx/store';

export const LOG_IN = '[AUTH] LOG_IN';
export const LOG_OUT = '[AUTH] LOG_OUT';
export const LOG_IN_REDIRECT = '[AUTH] LOG_IN_REDIRECT';
export const LOG_IN_SUCCESS = '[AUTH] LOG_IN_SUCCESS';
export const LOG_IN_FAILURE = '[AUTH] LOG_IN_FAILURE';
export const REGISTRATION = '[AUTH] REGISTRATION';
export const REGISTRATION_SUCCESS = '[AUTH] REGISTRATION_SUCCESS';
export const REGISTRATION_FAILURE = '[AUTH] REGISTRATION_FAILURE';

export class Login implements Action {
    readonly type: string = LOG_IN;
    constructor(public payload: UserLoginViewModel) { }
}
export class LoginRedirect implements Action {
    readonly type: string = LOG_IN_REDIRECT;
}
export class LoginSuccess implements Action {
    readonly type: string = LOG_IN_SUCCESS;
    constructor(public payload: UserLoginResponseModel) { }
}
export class LoginFailure implements Action {
    readonly type: string = LOG_IN_FAILURE;
    constructor(public payload: any) { }
}
export class Logout implements Action {
    readonly type: string = LOG_OUT;
}
export class Registration implements Action {
    readonly type: string = REGISTRATION;
    constructor(public payload: UserLoginModel) { }
}
export class RegistrationSuccess implements Action {
    readonly type: string = REGISTRATION_SUCCESS;
}
export class RegistrationFailure implements Action {
    readonly type: string = REGISTRATION_FAILURE;
    constructor(public payload: any) { }
}
export type Actions =
    | Login
    | Logout
    | LoginRedirect
    | LoginSuccess
    | LoginFailure
    | Registration
    | RegistrationSuccess
    | RegistrationFailure;

