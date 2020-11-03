import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  uri = `${environment.apiUrl}/api/student`;

  constructor(
    private http: HttpClient
  ) { }

  getAll() {
    return this.http.get<Student[]>(`${this.uri}`);
  }

  get(id: number) {
    return this.http.get<Student>(`${this.uri}/${id}`);
  }

  create(student: Student[]) {
    return this.http.post<Student>(`${this.uri}`, student);
  }

  update(id: number, student: Student[]): any {
    return this.http.put<Student>(`${this.uri}/${id}`, student);
  }

  delete(id: number) {
    return this.http.delete(`${this.uri}/${id}`);
  }
}
