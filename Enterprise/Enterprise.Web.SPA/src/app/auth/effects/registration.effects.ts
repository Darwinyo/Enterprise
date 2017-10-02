import { Router } from '@angular/router';
import { UserService } from './../services/user/user.service';
import { Injectable } from '@angular/core';
import * as AuthActions from './../actions/auth.actions';
import { Effect, Actions } from '@ngrx/effects';
import { of } from 'rxjs/observable/of';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/exhaustMap';
import 'rxjs/add/operator/map';
import * as fromAuth from './../reducers/auth-state.reducer';
@Injectable()
export class RegistrationEffects {

    @Effect()
    registration$ = this.actions$
        .ofType(AuthActions.REGISTRATION)
        .map((action: AuthActions.Registration) => action.payload)
        .exhaustMap(userLogin =>
            this.userService.userRegistration(userLogin)
                .map(response => {
                    if (!response.result) {
                        return new AuthActions.RegistrationSuccess()
                    } else {
                        return new AuthActions.RegistrationFailure('form is not valid')
                    }
                })
                .catch(err => of(new AuthActions.RegistrationFailure(err))))
    @Effect({ dispatch: false })
    registrationSuccess$ = this.actions$
        .ofType(AuthActions.REGISTRATION_SUCCESS)
        .do(() => {
            alert('youre registered');
            this.router.navigate(['/login']);
        });
    @Effect({ dispatch: false })
    registrationFailure$ = this.actions$
        .ofType(AuthActions.REGISTRATION_FAILURE)
        .do((err) => alert((<AuthActions.RegistrationFailure>err).payload));
    constructor(
        private actions$: Actions,
        private userService: UserService,
        private router: Router
    ) { }
}
