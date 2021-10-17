/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PapelService } from './papel.service';

describe('Service: Papel', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PapelService]
    });
  });

  it('should ...', inject([PapelService], (service: PapelService) => {
    expect(service).toBeTruthy();
  }));
});
