import { UserLoginViewModel } from './../../viewmodels/user-login/user-login.viewmodel';
import { hostTestUrl } from './../../../shared/consts/host-url.const';
import { FormsModule } from '@angular/forms';
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LoginNavComponent } from './login-nav.component';

describe('Auth:LoginNavComponent', () => {
  let component: LoginNavComponent;
  let fixture: ComponentFixture<LoginNavComponent>;
  let de: DebugElement;
  let el: HTMLElement;
  let testUrl: string;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule],
      declarations: [LoginNavComponent]
    })
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    testUrl = hostTestUrl;
  });
  afterEach(() => {
    de = null;
    el = null;
  })
  it('should be hidden logo passLogoImg when hidden pass is true', () => {
    component.hiddenpass = true;
    de = fixture.debugElement.query(By.css('#passLogoImg'));
    el = de.nativeElement;
    fixture.detectChanges();
    expect((<HTMLImageElement>el).src).toBe(testUrl + 'img/icons/hidden.png');
  });
  it('should be unhidden logo passLogoImg when hidden pass is false', () => {
    component.hiddenpass = false;
    de = fixture.debugElement.query(By.css('#passLogoImg'));
    el = de.nativeElement;
    fixture.detectChanges();
    expect((<HTMLImageElement>el).src).toBe(testUrl + 'img/icons/unhidden.png');
  });
  it('should be type text inputPassword when hidden pass is true', () => {
    component.hiddenpass = true;
    de = fixture.debugElement.query(By.css('#inputPassword'));
    el = de.nativeElement;
    fixture.detectChanges();
    expect((<HTMLInputElement>el).type).toBe('text');
  });
  it('should be type password inputPassword when hidden pass is false', () => {
    component.hiddenpass = false;
    de = fixture.debugElement.query(By.css('#inputPassword'));
    el = de.nativeElement;
    fixture.detectChanges();
    expect((<HTMLInputElement>el).type).toBe('password');
  });
  it('should be emit event with correct data when loginbtn clicked', async () => {
    spyOn(component.loginEvent, 'emit');

    const email = <HTMLInputElement>fixture.debugElement.query(By.css('#inputEmail')).nativeElement;
    const pass = <HTMLInputElement>fixture.debugElement.query(By.css('#inputPassword')).nativeElement;
    const remember = <HTMLInputElement>fixture.debugElement.query(By.css('#remembermechkbox')).nativeElement;

    de = fixture.debugElement.query(By.css('#global_login_btn'));
    el = de.nativeElement;

    const userLoginViewModel = <UserLoginViewModel>{
      userLogin: 'email',
      password: 'pass',
      rememberme: true
    }
    fixture.whenStable().then(() => {
      email.value = userLoginViewModel.userLogin;
      pass.value = userLoginViewModel.password;
      remember.checked = userLoginViewModel.rememberme;

      email.dispatchEvent(new Event('input'));
      pass.dispatchEvent(new Event('input'));
      remember.dispatchEvent(new Event('input'));
      el.dispatchEvent(new Event('click'));
      expect(component.loginEvent.emit).toHaveBeenCalledWith(userLoginViewModel);
    })
  });
});
