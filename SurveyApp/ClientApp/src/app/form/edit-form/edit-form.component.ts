import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { DataService, Questionaire } from '../../data.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-form',
  templateUrl: './edit-form.component.html',
  styleUrls: ['./edit-form.component.css']
})
export class EditFormComponent implements OnInit {

  questionaireForm: FormGroup = this.fb.group({
    questionaireID: 0,
    title: "",
    createdDate: new Date(),
    modifiedDate: new Date(),
    questions: this.fb.array([])
  });

  id = 0;

  questionTypesSimple = [
    'Yes/No',
    'Choice',
    'Rating',
    'Text'
  ];

  constructor(private fb: FormBuilder, private data: DataService, private router: Router, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(params => {
      this.id = Number(params.get('id'));
    })

    this.data.questionaires$.subscribe(questionaires => {
      console.log(questionaires);
    });
  }

  ngOnInit(): void {
    // adjust to match our existing id
    if (this.id > 0) {
      console.log('got', this.data.getQuestionaireById(this.id), this.id);
      this.questionaireForm.patchValue({
        questionaireID: this.id
      });
    } else {
      // do nothing
      console.log('doing nothing');
    }

    

    console.log('form init with', this.questionaireForm.value);
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
