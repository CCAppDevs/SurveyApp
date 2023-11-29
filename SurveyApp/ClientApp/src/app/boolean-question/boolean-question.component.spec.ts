import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BooleanComponentComponent } from './boolean-component.component';

describe('BooleanComponentComponent', () => {
  let component: BooleanComponentComponent;
  let fixture: ComponentFixture<BooleanComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BooleanComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BooleanComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
