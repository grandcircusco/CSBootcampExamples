import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComboListComponent } from './combo-list.component';

describe('ComboListComponent', () => {
  let component: ComboListComponent;
  let fixture: ComponentFixture<ComboListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComboListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ComboListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
