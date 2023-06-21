import { Injectable } from '@angular/core';
import { tasks } from '../classes/tasks';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Professionals } from '../classes/Professionals';


@Injectable({
  providedIn: 'root'
})

 export class TaskService {

  constructor(public http:HttpClient) { }
  url:string="http://localhost:53661/api/Tasks/"
  // lProfessional:Array<Professionals>=new Array<Professionals>()
  LTaskProfessional:Array<tasks>=new Array<tasks>()
  LTaskCustomer:    Array<tasks>=new Array<tasks>()
  LTaskDay:    Array<tasks>=new Array<tasks>()
  LTaskDayNotNull:boolean=true


  //שליפת כל המשימות
  getAlltasks():Observable<Array<tasks>>{
    return this.http.get<Array<tasks>>(this.url+"getAlltasks")
  }

  //שליפת כל המשימות
  getTasksByCode(code:number):Observable<tasks>{
    return this.http.get<tasks>(this.url+"getTasksByCode/"+code)
  }

  addTasks(t:tasks):Observable<boolean>
  {
    return this.http.put<boolean>(this.url+"addTasks", t)
  }
  update(t: tasks): Observable<tasks> {
    return this.http.post<tasks>(this.url + "update", t)
  }
  delete(t:number):Observable<boolean>
  {
    return this.http.delete<boolean>(this.url+"delete/"+ t)
  }
}
