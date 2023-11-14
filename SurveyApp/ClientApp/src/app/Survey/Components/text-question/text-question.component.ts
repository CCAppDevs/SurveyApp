import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-text-question',
  templateUrl: './text-question.component.html',
  styleUrls: ['./text-question.component.css']
})
export class TextQuestionComponent {
  @Input() Question: any = {
    QuestionID: 0,
    Prompt: "Test Feedback Question",
    PromptType: 0,
    QuestionaireID: 0,
    Responses: []
  }
}
