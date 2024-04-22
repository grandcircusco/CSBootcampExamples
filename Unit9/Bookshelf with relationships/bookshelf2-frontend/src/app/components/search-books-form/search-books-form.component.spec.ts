import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchBooksFormComponent } from './search-books-form.component';

describe('SearchBooksFormComponent', () => {
  let component: SearchBooksFormComponent;
  let fixture: ComponentFixture<SearchBooksFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SearchBooksFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SearchBooksFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
