import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

export interface Survey {
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

  constructor(private http: HttpClient, @Inject('BASE_URL') base: string) {
    this.baseUrl = base + "api";
  }

  // questionaires

  // get all questionaires
  getAllQuestionaires(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/questionaires`);
  }

  // get form by id (read)
  getQuestionaireById(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/questionaires/${id}`);
  }

  // put an updated form (update)
  updateQuestionaire(form: Survey): Observable<Survey> {
    return this.http.put<Survey>(`${this.baseUrl}/questionaires/${form.formId}`, form);
  }

  // post a new form (create)
  createNewQuestionaire(form: Survey): Observable<Survey> {
    return this.http.post<Survey>(`${this.baseUrl}/questionaires`, form);
  }

  // delete a form (delete)
  deleteQuestionaire(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/questionaires/${id}`)
  }


  // questions

  // responses

}
