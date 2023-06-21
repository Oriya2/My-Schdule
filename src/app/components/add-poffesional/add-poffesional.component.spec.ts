import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPoffesionalComponent } from './add-poffesional.component';

describe('AddPoffesionalComponent', () => {
  let component: AddPoffesionalComponent;
  let fixture: ComponentFixture<AddPoffesionalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPoffesionalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPoffesionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
