import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { NgForm, AbstractControl } from '@angular/forms';
import { PostApiHelper } from './../../../shared/helpers/post-api.helper';
import { UserService } from './../../services/user/user.service';
import { UserLoginModel } from './../../models/user/user-login/user-login.model';
import { Component, OnInit, OnDestroy, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime'
import 'rxjs/add/operator/distinctUntilChanged'
import { UserRegistrationResponseModel } from './../../models/responses/user-registration-response/user-registration-response.model';
import * as fromAuth from './../../reducers/auth-state.reducer';
import * as AuthActions from './../../actions/auth.actions';
@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit, AfterViewInit, OnDestroy {
  isUserLoginServerError: boolean;
  isPhoneServerError: boolean;
  isEmailServerError: boolean;
  checkEmailObservable$: Observable<any>;
  checkPhoneObservable$: Observable<any>;
  checkUserLoginObservable$: Observable<any>;
  pending$: Observable<boolean>;
  error$: Observable<string | null>;
  userLoginModel: UserLoginModel;
  serverMessageEmail: string;
  serverMessagePhone: string;
  serverMessageUserLogin: string;
  messageUserLoginError: string;
  messageEmailError: string;
  messagePhoneError: string;
  @ViewChild('registrationForm') registrationForm: NgForm;
  @ViewChild('userloginTxtBox') userloginTxtBox: ElementRef;
  @ViewChild('phoneTxtBox') phoneTxtBox: ElementRef;
  @ViewChild('emailTxtBox') emailTxtBox: ElementRef;

  constructor(
    private userService: UserService,
    private router: Router,
    private postApiHelper: PostApiHelper,
    private store: Store<fromAuth.State>
  ) {
    this.userLoginModel = <UserLoginModel>{};
    this.isEmailServerError = false;
    this.isPhoneServerError = false;
    this.isUserLoginServerError = false;
    this.pending$ = this.store.select(fromAuth.getRegistrationPending);
    this.error$ = this.store.select(fromAuth.getRegistrationError);
  }

  ngOnInit() {
  }
  ngAfterViewInit(): void {
    this.checkUserLoginObservable$ = Observable
      .fromEvent(this.userloginTxtBox.nativeElement, 'input');
    this.checkUserLoginObservable$
      .map((event: any) => event.target.value)
      .debounceTime(1500)
      .distinctUntilChanged()
      .subscribe((value) => {
        if (this.registrationForm.controls['userlogin'].valid) {
          this.checkUserLogin(value);
        }
      });
    this.checkPhoneObservable$ = Observable
      .fromEvent(this.phoneTxtBox.nativeElement, 'input');
    this.checkPhoneObservable$
      .map((event: any) => event.target.value)
      .debounceTime(1500)
      .distinctUntilChanged()
      .subscribe((value) => {
        if (this.registrationForm.controls['phone'].valid) {
          this.checkPhone(value);
        }
      });
    this.checkEmailObservable$ = Observable
      .fromEvent(this.emailTxtBox.nativeElement, 'input');
    this.checkEmailObservable$
      .map((event: any) => event.target.value)
      .debounceTime(1500)
      .distinctUntilChanged()
      .subscribe((value) => {
        if (this.registrationForm.controls['email'].valid) {
          this.checkEmail(value);
        }
      });
  }
  ngOnDestroy(): void {

  }
  checkUserLogin(userLogin: string): void {
    this.userService.checkUserLogin(this.postApiHelper.concatDoubleQuote(userLogin)).subscribe(
      (result) => {
        this.isUserLoginServerError = result;
        if (result) {
          this.serverMessageUserLogin = 'Userlogin already registered';
        }
      },
      (err) => {
        this.isUserLoginServerError = true;
        this.serverMessageUserLogin = err;
        this.userLoginValidator(this.serverMessageUserLogin);
      },
      () => this.userLoginValidator(this.serverMessageUserLogin)
    )
  }
  checkPhone(phone: string): void {
    this.userService.checkPhone(this.postApiHelper.concatDoubleQuote(phone)).subscribe(
      (result) => {
        this.isPhoneServerError = result;
        if (result) {
          this.serverMessagePhone = 'Phone already registered';
        }
      },
      (err) => {
        this.isPhoneServerError = true;
        this.serverMessagePhone = err;
        this.phoneValidator(this.serverMessagePhone);
      },
      () => this.phoneValidator(this.serverMessagePhone)
    )
  }
  checkEmail(email: string): void {
    this.userService.checkEmail(this.postApiHelper.concatDoubleQuote(email)).subscribe(
      (result) => {
        this.isEmailServerError = result;
        if (result) {
          this.serverMessageEmail = 'Email already registered';
        }
      },
      (err) => {
        this.isEmailServerError = true;
        this.serverMessageEmail = err;
        this.emailValidator(this.serverMessageEmail);
      },
      () => this.emailValidator(this.serverMessageEmail)
    )
  }
  userLoginValidator(message: string) {
    const control = this.registrationForm.controls['userlogin'];
    if (this.isUserLoginServerError) {
      control.setErrors({ backend: { error: message } });
      this.messageUserLoginError = control.errors['backend'].error;
    }
  }
  phoneValidator(message: string) {
    const control = this.registrationForm.controls['phone'];
    if (this.isPhoneServerError) {
      control.setErrors({ backend: { error: message } });
      this.messagePhoneError = control.errors['backend'].error;
    }
  }
  emailValidator(message: string) {
    const control = this.registrationForm.controls['email'];
    if (this.isEmailServerError) {
      control.setErrors({ backend: { error: message } });
      this.messageEmailError = control.errors['backend'].error;
    }
  }
  formValidator(): boolean {
    return this.registrationForm.invalid;
  }
  registerUser(registrationForm: NgForm) {
    const userLoginModel = <UserLoginModel>{
      userLogin: registrationForm.value['userlogin'],
      email: registrationForm.value['email'],
      phoneNumber: registrationForm.value['phone'],
      password: registrationForm.value['password']
    }
    this.store.dispatch(new AuthActions.Registration(userLoginModel));
  }
}
