import { Component } from '@angular/core';

@Component({
  selector: 'app-survey-page',
  templateUrl: './survey-page.component.html',
  styleUrls: ['./survey-page.component.css']
})
export class SurveyPageComponent {
  survey: any = {
    surveyId: 1234,
    instructor: "bob",
    location: "wah216",
    questionaire: {
      questionaireID: 1,
      title: "Questionaire Title",
      createdDate: Date.now(),
      modifiedDate: Date.now(),
      questions: []
    }
  }
}
