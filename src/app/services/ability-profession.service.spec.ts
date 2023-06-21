import { TestBed } from '@angular/core/testing';

import { AbilityProfessionService } from './ability-profession.service';

describe('AbilityProfessionService', () => {
  let service: AbilityProfessionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AbilityProfessionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
