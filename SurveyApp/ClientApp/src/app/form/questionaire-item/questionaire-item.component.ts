import { Component, EventEmitter, Input, Output } from '@angular/core';

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

  @Output() onDelete = new EventEmitter<number>();

  deleteItem() {
    this.onDelete.emit(this.questionaire.questionaireID);
  }

}
