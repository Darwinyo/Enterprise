import { Store } from '@ngrx/store';
import { PostApiHelper } from './../../../shared/helpers/post-api.helper';
import { RouterStub } from './../../../shared/stubs/router.stub';
import { Router } from '@angular/router';
import { UserLoginModel } from './../../models/user/user-login/user-login.model';
import { UserService } from './../../services/user/user.service';
import { FormsModule } from '@angular/forms';
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import * as fromAuth from './../../reducers/auth-state.reducer';
import * as AuthActions from './../../actions/auth.actions';

import { RegistrationComponent } from './registration.component';

describe('RegistrationComponent', () => {
  let component: RegistrationComponent;
  let fixture: ComponentFixture<RegistrationComponent>;
  let de: DebugElement;
  let el: HTMLElement;
  let userService: UserService;
  const userServiceStub = {
    checkUserLogin: () => true,
    checkEmail: () => true,
    checkPhone: () => true
  }
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [RegistrationComponent],
      imports: [FormsModule],
      providers: [
        { provide: UserService, useValue: userServiceStub },
        { provide: Router, useClass: RouterStub },
        PostApiHelper
      ]
    })
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.componentInstance;
    userService = fixture.debugElement.injector.get(UserService);
    fixture.detectChanges();
  });

  it('should show userlogin validation when inputs is dirty and chars less than 6', () => {
    de = fixture.debugElement.query(By.css('#userlogin'));
    el = de.nativeElement;
    (<HTMLInputElement>el).value = 'error';
    fixture.detectChanges();
    expect(el.nextSibling.textContent).toContain('User Login length should be more than 6 characters');
  });
  it('should show userlogin validation when inputs is dirty and no input', () => {
    de = fixture.debugElement.query(By.css('#userlogin'));
    el = de.nativeElement;
    (<HTMLInputElement>el).value = '';

    fixture.detectChanges();
    expect(el.nextSibling.textContent).toContain('User Login is required');
  });
});
