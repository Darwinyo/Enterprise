/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProductImagesService } from './product-images.service';

describe('Service: ProductImages', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductImagesService]
    });
  });

  it('should ...', inject([ProductImagesService], (service: ProductImagesService) => {
    expect(service).toBeTruthy();
  }));
});