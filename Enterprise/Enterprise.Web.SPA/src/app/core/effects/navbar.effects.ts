import { Effect, Actions } from '@ngrx/effects';
import { Injectable } from '@angular/core';
import * as NavbarActions from './../actions/navbar.actions';
@Injectable()
export class NavbarEffects {
    @Effect({ dispatch: false })
    logged$ = this.actions$
        .ofType(NavbarActions.NAV_LOGGED)
        .do(() => console.log('navbar logged'));
    @Effect({ dispatch: false })
    toggleUser$ = this.actions$
        .ofType(NavbarActions.TOGGLE_USER)
        .do(() => console.log('Nav User Toggled'));
    @Effect({ dispatch: false })
    toogleLogin$ = this.actions$
        .ofType(NavbarActions.TOGGLE_LOGIN)
        .do(() => console.log('Nav Login Toggled'));
    @Effect({ dispatch: false })
    toggleCart$ = this.actions$
        .ofType(NavbarActions.TOGGLE_CART)
        .do(() => console.log('Nav Cart Toggled'));
    @Effect({ dispatch: false })
    toggleNotif$ = this.actions$
        .ofType(NavbarActions.TOGGLE_NOTIF)
        .do(() => console.log('Nav Notif Toggled'));

    constructor(private actions$: Actions) { }
}
