import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Todo } from '../_models/todo';
import { first } from 'rxjs/operators';

import { TodoListService } from '../_services/todo-list.service';
import { MatListOption } from '@angular/material/list';
@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  todoForm: FormGroup;
  todoList: Todo[] = [];
  todoSelected: Todo;
  toggle: boolean = false;
  texto: string;
  constructor(
    private todolistService: TodoListService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.todoForm = this.formBuilder.group({
      description: ['', Validators.required]
    });
    this.texto = "Mostrar completados";
    this.listPending();
  }

  private listPending() {
    this.todolistService.GetCompleted(this.toggle).pipe(first()).subscribe(todos => {
      this.todoList = todos;
    });
  }

  get f() { return this.todoForm.controls; }

  onSubmit() {
    if (this.todoForm.invalid) {
      return;
    }
    let todo: Todo = {
      description: this.f.description.value,
      completed: false,
    }
    console.log(todo);
    this.todolistService.Post(todo)
      .pipe(first())
      .subscribe(
        data => {
          this.listPending();
          this.todoForm.reset();
        });
  }

  selectionChange(option: MatListOption) {
    this.todoSelected = option.value;
    this.todoSelected.completed = option.selected;
    this.todolistService.Put(this.todoSelected.id, this.todoSelected)
      .pipe(first())
      .subscribe(
        data => {
          this.listPending();
        });
  }

  doToggle(): void {
    this.toggle = !this.toggle;
    this.texto = this.toggle ? "Ocultar completados" : "Mostrar completados";
    this.listPending();
  }
}
