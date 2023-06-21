import { TestBed } from '@angular/core/testing';

import { TypeAbilityService } from './type-ability.service';

describe('TypeAbilityService', () => {
  let service: TypeAbilityService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TypeAbilityService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
