/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProductSpecsService } from './product-specs.service';

describe('Service: ProductSpecs', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductSpecsService]
    });
  });

  it('should ...', inject([ProductSpecsService], (service: ProductSpecsService) => {
    expect(service).toBeTruthy();
  }));
});