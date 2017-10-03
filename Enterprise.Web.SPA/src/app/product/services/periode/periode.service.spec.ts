/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PeriodeService } from './periode.service';

describe('Service: Periode', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PeriodeService]
    });
  });

  it('should ...', inject([PeriodeService], (service: PeriodeService) => {
    expect(service).toBeTruthy();
  }));
});
