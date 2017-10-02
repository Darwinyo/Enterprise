import { Router } from '@angular/router';
import { UserService } from './../services/user/user.service';
import { Injectable } from '@angular/core';
import * as AuthActions from './../actions/auth.actions';
import * as NavbarActions from './../../core/actions/navbar.actions';
import { Effect, Actions } from '@ngrx/effects';
import { of } from 'rxjs/observable/of';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/exhaustMap';
import 'rxjs/add/operator/map';
@Injectable()
export class LoginEffects {

    @Effect()
    login$ = this.actions$
        .ofType(AuthActions.LOG_IN)
        .map((action: AuthActions.Login) => action.payload)
        .exhaustMap(userLogin =>
            this.userService.userLogin(userLogin)
                .map(response => {
                    if (response.isLogged === true) {
                        return new AuthActions.LoginSuccess(response)
                    } else {
                        return new AuthActions.LoginFailure('Wrong Pass or UserName')
                    }
                })
                .catch(err => of(new AuthActions.LoginFailure(err))));
    @Effect({ dispatch: false })
    loginRedirect$ = this.actions$
        .ofType(AuthActions.LOG_IN_REDIRECT)
        .do(() => this.router.navigate(['/']));
    @Effect({ dispatch: false })
    loginSuccess$ = this.actions$
        .ofType(AuthActions.LOG_IN_SUCCESS)
        .do(() => {
            alert('youre logged in');
            return new NavbarActions.NavLogged();
            // this.router.navigate(['/home']);
        });
    @Effect({ dispatch: false })
    loginFailure$ = this.actions$
        .ofType(AuthActions.LOG_IN_FAILURE)
        .do((err) => alert((<AuthActions.RegistrationFailure>err).payload));
    @Effect({ dispatch: false })
    logout$ = this.actions$
        .ofType(AuthActions.LOG_OUT)
        .do(() => alert('youre logged out'))
    constructor(
        private actions$: Actions,
        private userService: UserService,
        private router: Router
    ) { }
}
