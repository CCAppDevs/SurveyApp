import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

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

  @Output() onDelete = new EventEmitter<number>();

  constructor(private router: Router) { }

  deleteItem() {
    this.onDelete.emit(this.questionaire.questionaireID);
  }

  editItem() {
    // reroute to edit
    this.router.navigate(['form', this.questionaire.questionaireID]);
  }



}
