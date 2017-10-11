import { UserLoginModel } from './../models/user/user-login/user-login.model';
import { Action } from '@ngrx/store';
export const REGISTRATION = '[AUTH] [REGISTRATION_PAGE] REGISTRATION';
export const REGISTRATION_SUCCESS = '[AUTH] [REGISTRATION_PAGE] REGISTRATION_SUCCESS';
export const REGISTRATION_FAILURE = '[AUTH] [REGISTRATION_PAGE] REGISTRATION_FAILURE';

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
    | Registration
    | RegistrationSuccess
    | RegistrationFailure;
