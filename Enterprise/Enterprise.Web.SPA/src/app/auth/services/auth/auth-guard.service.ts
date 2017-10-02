import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import 'rxjs/add/operator/take';
import 'rxjs/add/operator/map';
import * as fromAuth from './../../reducers/auth-state.reducer';
import * as AuthActions from './../../actions/auth.actions';
@Injectable()
export class AuthGuardService implements CanActivate {
    constructor(private store: Store<fromAuth.State>) { }
    canActivate(): Observable<boolean> {
        return this.store
            .select(fromAuth.getLoggedIn)
            .map(authed => {
                if (!authed) {
                    this.store.dispatch(new AuthActions.LoginRedirect());
                    return false;
                }
                return true;
            })
            .take(1);
    }
}
