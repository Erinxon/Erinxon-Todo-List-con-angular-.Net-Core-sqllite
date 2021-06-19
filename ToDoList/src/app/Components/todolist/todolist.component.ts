import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Task } from 'src/app/Models/Task';
import { TodoListService } from 'src/app/Services/todo-list.service';


@Component({
  selector: 'app-todolist',
  templateUrl: './todolist.component.html',
  styleUrls: ['./todolist.component.css']
})
export class TodolistComponent implements OnInit {
  taskForm = new FormGroup({
    id: new FormControl(null),
    nameTask: new FormControl('', Validators.required),
    status: new FormControl(null),
  });

  listTask: Task[] = [];

  isEditing: boolean = false;

  p: number = 1;

  constructor(private _todoListService: TodoListService) {

  }

  ngOnInit(): void {
    this.GetTasks();
  }

  GetTasks(): void {
    this._todoListService.GetAllTask().subscribe(t => {
      this.listTask = t.data;
    });
  }

  SaveTask(): void {
    const task = {
      nameTask: this.taskForm.get('nameTask')?.value,
   }
   this._todoListService.AddTask(task).subscribe(t => {
      if(t.success){
        this.GetTasks();
      }
   });
  }

  UpdateTask(): void {
    this._todoListService.EditTask(this.taskForm.value).subscribe(t => {
      if(t.success){
        this.GetTasks();
      }
   });
   this.isEditing = false;
  }

  EditTask(task: Task): void {
    this.isEditing = true;
    this.taskForm.get('id')?.setValue(task.id);
    this.taskForm.get('nameTask')?.setValue(task.nameTask); 
    this.taskForm.get('status')?.setValue(task.status);
  }

  RemoveTask(id: number): void {
    this._todoListService.RemoveTask(id).subscribe(t => {
      if(t.success){
        this.GetTasks();
      }
   })
  }

  UpdateEstatus(id: number): void {
    this._todoListService.UpdateStatus(id).subscribe(t => {
      if(t.success){
        this.GetTasks();
      }
   })
  }

  GetTextButtunSave(): string {
    return this.isEditing ? 'Edit Task' : 'Save Task';
  }

  
  onSubmit(): void {
    this.isEditing ? this.UpdateTask() : this.SaveTask();
    this.ResetForm();
  }


  ResetForm(): void {
    this.taskForm.reset();
  }

}
