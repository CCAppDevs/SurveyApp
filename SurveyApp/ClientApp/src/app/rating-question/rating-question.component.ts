import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-rating-question',
  templateUrl: './rating-question.component.html',
  styleUrls: ['./rating-question.component.css']
})
export class RatingQuestionComponent {
  @Input() questionID: string = '';
  @Input() questionText: string = '';
  @Input() range: number = 5; // Default range is 5, but can be set to 10 for 1-10 rating.

  rangeArray: number[] = [];

  constructor() {
    this.rangeArray = Array.from({ length: this.range }, (_, i) => i + 1);
  }

  selectOption(option: number) {
    // Handle the user's selection here (e.g., send data to a server)
    console.log(`User selected option ${option} for question ${this.questionID}`);
  }
}
