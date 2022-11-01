import { TestBed } from '@angular/core/testing';

import { CardsAPIService } from './cards-api.service';

describe('TestService', () => {
  let service: CardsAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CardsAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
