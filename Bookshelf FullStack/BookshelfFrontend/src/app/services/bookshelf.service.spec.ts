import { TestBed } from '@angular/core/testing';

import { BookshelfService } from './bookshelf.service';

describe('BookshelfService', () => {
  let service: BookshelfService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookshelfService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
