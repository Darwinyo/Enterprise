/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { SortProductComponent } from './sort-product.component';

describe('SortProductComponent', () => {
  let component: SortProductComponent;
  let fixture: ComponentFixture<SortProductComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SortProductComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SortProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
