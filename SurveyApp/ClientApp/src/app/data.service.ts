import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';

export interface Questionaire {
  formId: number;
  createdDate: Date;
  modifiedDate: Date;
  title: string;
  questions: any[];
}

@Injectable({
  providedIn: 'root'
})
export class DataService {

  baseUrl: string;

  questionaires$: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);

  constructor(private http: HttpClient, @Inject('BASE_URL') base: string) {
    this.baseUrl = base + "api";
    this.getAllQuestionaires();
  }

  // questionaires

  // get all questionaires
  getAllQuestionaires(): void {
    this.http.get<any[]>(`${this.baseUrl}/questionaires`).subscribe(questionaires => {
      this.questionaires$.next(questionaires);
    });
  }

  // get form by id (read)
  getQuestionaireById(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/questionaires/${id}`);
  }

  // put an updated form (update)
  updateQuestionaire(questionaire: Questionaire) {
    this.http.put<Questionaire>(`${this.baseUrl}/questionaires/${questionaire.formId}`, questionaire).subscribe(result => {
      this.getAllQuestionaires();
    });
  }

  // post a new form (create)
  createNewQuestionaire(questionaire: Questionaire) {
    this.http.post<Questionaire>(`${this.baseUrl}/questionaires`, questionaire).subscribe(result => {
      this.getAllQuestionaires();
    });
  }

  // delete a form (delete)
  deleteQuestionaire(id: number): void {
    this.http.delete<any>(`${this.baseUrl}/questionaires/${id}`).subscribe(result => {
      this.getAllQuestionaires();
    });
  }


  // questions

  // responses

}
