import { Component, Input } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { DataService, Questionaire } from '../../data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-form',
  templateUrl: './edit-form.component.html',
  styleUrls: ['./edit-form.component.css']
})
export class EditFormComponent {

  questionaireForm: FormGroup;
  id = 1234;

  questionTypesSimple = [
    'Yes/No',
    'Choice',
    'Rating',
    'Text'
  ];

  constructor(private fb: FormBuilder, private data: DataService, private router: Router) {
    this.questionaireForm = this.fb.group({
      questionaireID: 1234,
      title: "test form",
      createdDate: "2023-04-14",
      modifiedDate: "2023-04-14",
      questions: this.fb.array([])
    });
  }

  addNewQuestion() {
    // this fires when the add new button is clicked
    console.log("add new question fired");

    // add a new question into the array
    this.questions.push(this.fb.group({
      prompt: '',
      promptType: 0,
      responses: this.fb.array([])
    }));
  }

  get questions() {
    return this.questionaireForm.get('questions') as FormArray;
  }

  onSubmit(): void {
    console.log("form was submitted", this.questionaireForm.value);

    let myQuestionaire: Questionaire = {
      formId: this.questionaireForm.value.formId,
      createdDate: this.questionaireForm.value.createdDate,
      modifiedDate: this.questionaireForm.value.modifiedDate,
      title: this.questionaireForm.value.title,
      questions: this.questionaireForm.value.questions
    }

    this.data.createNewQuestionaire(myQuestionaire);

    // navigate away to the new questionaire
    this.router.navigate(['administrator']);
  }
}
