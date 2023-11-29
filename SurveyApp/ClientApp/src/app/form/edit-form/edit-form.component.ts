import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { DataService, Questionaire } from '../../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { of, switchMap } from 'rxjs';

@Component({
  selector: 'app-edit-form',
  templateUrl: './edit-form.component.html',
  styleUrls: ['./edit-form.component.css']
})
export class EditFormComponent implements OnInit {

  questionaire: any = {
    questionaireId: 0,
    title: "",
    createdDate: new Date(),
    modifiedDate: new Date(),
    questions: []
  };

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
    this.route.paramMap.pipe(
      switchMap(params => {
        this.id = Number(params.get('id'));
        if (this.id == 0) {
          return of({
            questionaireId: 0,
            title: "",
            createdDate: new Date(),
            modifiedDate: new Date(),
            questions: []
          });
        }
        return this.data.getQuestionaireById(this.id);
      })
    ).subscribe(result => {
      this.questionaire = result;
      this.initForm();
    })
  }

  ngOnInit(): void {
    console.log('form init with', this.questionaireForm.value);
  }

  initForm(): void {
    this.questionaireForm.patchValue({
      questionaireID: this.id,
      title: this.questionaire.title,
      createdDate: this.questionaire.createdDate,
      modifiedDate: new Date(),
    });

    this.questionaire.questions.forEach((question: any) => {
      this.questions.push(this.fb.group(question));
    });

  }

  addNewQuestion() {
    // this fires when the add new button is clicked
    console.log("add new question fired", this.questionaire);

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

    myQuestionaire.questions.forEach(question => {
      question.responses = [];
    })

    this.data.createNewQuestionaire(myQuestionaire);

    // navigate away to the new questionaire
    this.router.navigate(['administrator']);
  }
}
