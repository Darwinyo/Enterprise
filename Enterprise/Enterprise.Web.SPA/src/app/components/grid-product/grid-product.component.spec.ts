/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GridProductComponent } from './grid-product.component';

describe('GridProductComponent', () => {
  let component: GridProductComponent;
  let fixture: ComponentFixture<GridProductComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridProductComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
