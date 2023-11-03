import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionaireItemComponent } from './questionaire-item.component';

describe('QuestionaireItemComponent', () => {
  let component: QuestionaireItemComponent;
  let fixture: ComponentFixture<QuestionaireItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuestionaireItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QuestionaireItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
