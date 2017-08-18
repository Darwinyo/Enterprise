/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DashboardV5Component } from './dashboard-v5.component';

describe('DashboardV5Component', () => {
  let component: DashboardV5Component;
  let fixture: ComponentFixture<DashboardV5Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardV5Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardV5Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
