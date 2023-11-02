import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-edit-form',
  templateUrl: './edit-form.component.html',
  styleUrls: ['./edit-form.component.css']
})
export class EditFormComponent {

  questionaireForm: FormGroup;
  id = 1234;

  constructor(private fb: FormBuilder) {
    this.questionaireForm = this.fb.group({
      questionaireID: 1234,
      title: "test this form",
      createdDate: "2023-04-14",
      modifiedDate: "2023-04-14",
      questions: [
        { questionID: 1, questionText: "test", questionType: 1 },
        { questionID: 2, questionText: "test 1", questionType: 1 },
        { questionID: 3, questionText: "test 2", questionType: 1 },
      ]
    });
  }

  addNewQuestion() {
    // this fires when the add new button is clicked
    console.log("add new question fired");
  }
}
