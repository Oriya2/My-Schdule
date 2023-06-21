import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EdidProComponent } from './edid-pro.component';

describe('EdidProComponent', () => {
  let component: EdidProComponent;
  let fixture: ComponentFixture<EdidProComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EdidProComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EdidProComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
