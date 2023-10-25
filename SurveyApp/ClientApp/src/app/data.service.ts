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

  // forms

  // get all forms
  getAllForms(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/forms`);
  }

  // get form by id (read)
  getFormById(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/forms/${id}`);
  }

  // put an updated form (update)
  updateForm(form: Survey): Observable<Survey> {
    return this.http.put<Survey>(`${this.baseUrl}/forms/${form.formId}`, form);
  }

  // post a new form (create)
  createNewForm(form: Survey): Observable<Survey> {
    return this.http.post<Survey>(`${this.baseUrl}/forms`, form);
  }

  // delete a form (delete)
  deleteForm(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/forms/${id}`)
  }


  // questions

  // responses

}
