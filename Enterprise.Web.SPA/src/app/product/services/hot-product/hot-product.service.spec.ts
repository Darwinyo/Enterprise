/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { HotProductService } from './hot-product.service';

describe('Service: HotProduct', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HotProductService]
    });
  });

  it('should ...', inject([HotProductService], (service: HotProductService) => {
    expect(service).toBeTruthy();
  }));
});