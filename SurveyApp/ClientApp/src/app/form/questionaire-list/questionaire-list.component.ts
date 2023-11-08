import { Component, Input } from '@angular/core';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-questionaire-list',
  templateUrl: './questionaire-list.component.html',
  styleUrls: ['./questionaire-list.component.css']
})
export class QuestionaireListComponent {
  @Input() questionaires: any[] = [];

  constructor(private data: DataService) {
    this.data.questionaires$.subscribe(result => {
      console.log(result);
    })
  }

  createNew() {
    this.data.createNewQuestionaire({
      formId: 0,
      createdDate: new Date(),
      modifiedDate: new Date(),
      title: 'toast',
      questions: []
    });
  }

  delete(id: number) {
    this.data.deleteQuestionaire(id);
  }
}
