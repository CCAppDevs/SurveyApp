import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-questionaire-item',
  templateUrl: './questionaire-item.component.html',
  styleUrls: ['./questionaire-item.component.css']
})
export class QuestionaireItemComponent {
  @Input() questionaire: any = {
    questionaireID: 0,
    title: "test",
    createdDate: Date.now(),
    modifiedDate: Date.now(),
    questions: []
   }

}
