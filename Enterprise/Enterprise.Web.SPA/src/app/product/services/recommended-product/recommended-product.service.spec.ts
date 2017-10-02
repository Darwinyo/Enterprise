/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RecommendedProductService } from './recommended-product.service';

describe('Service: RecommendedProduct', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RecommendedProductService]
    });
  });

  it('should ...', inject([RecommendedProductService], (service: RecommendedProductService) => {
    expect(service).toBeTruthy();
  }));
});