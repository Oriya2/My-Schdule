import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeeaderComponent } from './heeader.component';

describe('HeeaderComponent', () => {
  let component: HeeaderComponent;
  let fixture: ComponentFixture<HeeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeeaderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
