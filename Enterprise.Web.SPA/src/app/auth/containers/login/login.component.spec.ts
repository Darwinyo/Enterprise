import { Store } from '@ngrx/store';
import { FormsModule } from '@angular/forms';
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import * as fromAuth from './../../reducers/auth-state.reducer';
import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let de: DebugElement;
  let el: HTMLElement;
  let store: Store<fromAuth.State>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [LoginComponent],
      imports: [
        FormsModule,
        Store
      ]
    })
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    store=<Store>
    fixture.detectChanges();
  });

  it('should be emit event with correct data when loginbtn clicked', async () => {
    spyOn(component.loginEvent, 'emit');

    const email = <HTMLInputElement>fixture.debugElement.query(By.css('#inputEmail')).nativeElement;
    const pass = <HTMLInputElement>fixture.debugElement.query(By.css('#inputPassword')).nativeElement;
    const remember = <HTMLInputElement>fixture.debugElement.query(By.css('#remembermechkbox')).nativeElement;

    de = fixture.debugElement.query(By.css('#global_login_btn'));
    el = de.nativeElement;

    fixture.detectChanges();

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
