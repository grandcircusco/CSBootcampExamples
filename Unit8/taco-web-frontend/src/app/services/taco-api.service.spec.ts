import { TestBed } from '@angular/core/testing';

import { TacoApiService } from './taco-api.service';

describe('TacoApiService', () => {
  let service: TacoApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TacoApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
