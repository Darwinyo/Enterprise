/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FilterProductTailComponent } from './filter-product-tail.component';

describe('FilterProductTailComponent', () => {
  let component: FilterProductTailComponent;
  let fixture: ComponentFixture<FilterProductTailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FilterProductTailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FilterProductTailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
