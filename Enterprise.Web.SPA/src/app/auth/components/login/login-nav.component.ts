import { UserLoginViewModel } from './../../viewmodels/user-login/user-login.viewmodel';
import { NgForm } from '@angular/forms';
import { Component, OnInit, ViewChild, ElementRef, AfterViewInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-login-nav',
  templateUrl: './login-nav.component.html',
  styleUrls: ['./login-nav.component.scss']
})
export class LoginNavComponent implements OnInit, AfterViewInit {
  userLoginViewModel: UserLoginViewModel;
  hiddenpass: boolean;
  check: boolean;
  @Output() loginEvent: EventEmitter<UserLoginViewModel>;
  @ViewChild('remembercheckbox') remembercheckbox: ElementRef
  constructor() {
    this.hiddenpass = false;
    this.check = false;
    this.loginEvent = <EventEmitter<UserLoginViewModel>>{};
    this.userLoginViewModel = <UserLoginViewModel>{};
  }
  ngOnInit() {
  }
  ngAfterViewInit(): void {
    this.check = this.remembercheckbox.nativeElement.checked = false;
  }
  loginUser(loginForm: NgForm) {
    const loginViewModel = <UserLoginViewModel>{
      userLogin: loginForm.value['userlogin'],
      password: loginForm.valid['password'],
      rememberme: this.remembercheckbox.nativeElement.checked
    }
    this.loginEvent.emit(loginViewModel);
  }
  tooglePassword() {
    this.hiddenpass = !this.hiddenpass;
  }
  toogleRememberMe() {
    this.check = !this.check;
  }
  passwordType(): string {
    return !this.hiddenpass ? 'password' : 'text';
  }
  checkedUrl(): string {
    return this.check ? 'img/icons/checked.png' : 'img/icons/unchecked.png';
  }
}
