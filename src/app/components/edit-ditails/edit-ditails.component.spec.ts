import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDitailsComponent } from './edit-ditails.component';

describe('EditDitailsComponent', () => {
  let component: EditDitailsComponent;
  let fixture: ComponentFixture<EditDitailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditDitailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditDitailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
