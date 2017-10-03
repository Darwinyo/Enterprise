/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LoginNavComponent } from './login-nav.component';

describe('LoginComponent', () => {
  let component: LoginNavComponent;
  let fixture: ComponentFixture<LoginNavComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginNavComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
