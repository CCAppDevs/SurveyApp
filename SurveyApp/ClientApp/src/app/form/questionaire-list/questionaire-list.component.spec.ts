import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionaireListComponent } from './questionaire-list.component';

describe('QuestionaireListComponent', () => {
  let component: QuestionaireListComponent;
  let fixture: ComponentFixture<QuestionaireListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuestionaireListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QuestionaireListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
