import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Todo } from '../_models/todo';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root'
})
@Injectable()
export class TodoListService {

  constructor(private http: HttpClient) { }

  GetAll() {
    return this.http.get<Todo[]>(`${environment.apiUrl}/todo`);
  }

  GetCompleted(completed: boolean) {
    return this.http.get<Todo[]>(`${environment.apiUrl}/todo/${completed}`);
  }

  GetById(id: number) {
    return this.http.get<Todo>(`${environment.apiUrl}/todo/${id}`);
  }

  Post(todo: Todo) {
    return this.http.post(`${environment.apiUrl}/todo/`, todo);
  }

  Put(id: number, todo: Todo) {
    return this.http.put(`${environment.apiUrl}/todo/${id}`, todo);
  }

  Delete(id: number) {
    return this.http.delete(`${environment.apiUrl}/todo/${id}`);
  }
}
