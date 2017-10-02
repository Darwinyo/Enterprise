import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { NgForm } from '@angular/forms';
import { UserLoginViewModel } from './../../viewmodels/user-login/user-login.viewmodel';
import { Component, OnInit, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import * as fromAuth from './../../reducers/auth-state.reducer';
import * as AuthActions from './../../actions/auth.actions';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, AfterViewInit {
  check: boolean;
  userLoginViewModel: UserLoginViewModel;
  pending$: Observable<boolean>;
  error$: Observable<string | null>;
  @ViewChild('remembercheckbox') remembercheckbox: ElementRef
  constructor(private store: Store<fromAuth.State>) {
    this.check = false;
    this.userLoginViewModel = <UserLoginViewModel>{};
  }

  ngOnInit() {
  }
  ngAfterViewInit(): void {
    this.check = this.remembercheckbox.nativeElement.checked = false;
  }
  checkedUrl(): string {
    return this.check ? 'img/icons/checked.png' : 'img/icons/unchecked.png';
  }
  toogleRememberMe() {
    this.check = !this.check;
  }
  loginUser(form: NgForm) {
    const userLoginViewModel = <UserLoginViewModel>{
      userLogin: form.value['userlogin'],
      password: form.value['password'],
      rememberme: form.value['rememberme']
    }
    this.store.dispatch(new AuthActions.Login(userLoginViewModel));
  }
}
