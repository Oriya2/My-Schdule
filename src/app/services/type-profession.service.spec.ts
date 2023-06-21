import { TestBed } from '@angular/core/testing';

import { TypeProfessionService } from './type-profession.service';

describe('TypeProfessionService', () => {
  let service: TypeProfessionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TypeProfessionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
