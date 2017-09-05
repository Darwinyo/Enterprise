/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { VariationsService } from './variations.service';

describe('Service: Variations', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VariationsService]
    });
  });

  it('should ...', inject([VariationsService], (service: VariationsService) => {
    expect(service).toBeTruthy();
  }));
});