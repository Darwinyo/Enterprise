/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProductReviewService } from './product-review.service';

describe('Service: ProductReview', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductReviewService]
    });
  });

  it('should ...', inject([ProductReviewService], (service: ProductReviewService) => {
    expect(service).toBeTruthy();
  }));
});