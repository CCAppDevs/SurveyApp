import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-questionaire-item',
  templateUrl: './questionaire-item.component.html',
  styleUrls: ['./questionaire-item.component.css']
})
export class QuestionaireItemComponent {
  @Input() questionaire: any = {
    questionaireID: 0,
    title: "New Questionaire",
    createdDate: Date.now(),
    modifiedDate: Date.now(),
    questions: []
  }

  @Output() onStart = new EventEmitter<any>();

  onStartButtonPressed() {
    this.onStart.emit({ message: "pressed start" });
  }

}
