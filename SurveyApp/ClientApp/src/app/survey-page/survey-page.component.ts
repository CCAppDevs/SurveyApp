import { Component } from '@angular/core';

@Component({
  selector: 'app-survey-page',
  templateUrl: './survey-page.component.html',
  styleUrls: ['./survey-page.component.css']
})
export class SurveyPageComponent {

  data: any = {
    instructor: "jesse",
    location: "wah216"
  }

  startSurvey() {
    console.log("Survey Started", this.data);
    // we will add code to process the form
  }
}
