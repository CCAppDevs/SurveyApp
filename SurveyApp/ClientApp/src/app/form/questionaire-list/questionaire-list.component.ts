import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-questionaire-list',
  templateUrl: './questionaire-list.component.html',
  styleUrls: ['./questionaire-list.component.css']
})
export class QuestionaireListComponent {
  @Input() questionaires: any[] = [
    {
      questionaireID: 0,
      title: "test",
      createdDate: Date.now(),
      modifiedDate: Date.now(),
      questions: []
    },
    {
      questionaireID: 0,
      title: "test 2",
      createdDate: Date.now(),
      modifiedDate: Date.now(),
      questions: []
    }
  ];
}
