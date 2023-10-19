import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') base: string) {
    this.baseUrl = base + "api";
  }

  getAllForms(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/forms`);
  }

  getFormById(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/forms/${id}`);
  }

}
