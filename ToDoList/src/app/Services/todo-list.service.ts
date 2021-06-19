import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/Response/TaskResponse';
import { Task } from '../Models/Task';

@Injectable({
  providedIn: 'root'
})
export class TodoListService {

  constructor(private _httpClient: HttpClient) { }

  GetAllTask(): Observable<ApiResponse> {
    return this._httpClient.get<ApiResponse>('/Task');
  }

  AddTask(task: any): Observable<ApiResponse>{
    return this._httpClient.post<ApiResponse>('/Task', task);
  }

  RemoveTask(id: number): Observable<ApiResponse>{
    return this._httpClient.delete<ApiResponse>(`/Task/${id}`);
  }

  UpdateStatus(id: number): Observable<ApiResponse>{
    return this._httpClient.put<ApiResponse>(`/Task/${id}`, null);
  }

  EditTask(task: Task): Observable<ApiResponse>{
    return this._httpClient.put<ApiResponse>(`/Task`, task);
  }
}
