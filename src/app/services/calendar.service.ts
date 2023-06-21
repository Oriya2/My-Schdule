import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { calendarEvent } from '../classes/calendarEvent';

@Injectable({
  providedIn: 'root'
})

export class CalendarService {
  url:string="http://localhost:53661/api/Scheduling/"

  constructor(public http:HttpClient) { }

  getbyid(tz:string):Observable<Array<calendarEvent>>
  {
    return this.http.get<Array<calendarEvent>>(this.url+"getbyid/"+tz)
  }

  getEventByIdCust(tz:string):Observable<Array<calendarEvent>>
  {
    return this.http.get<Array<calendarEvent>>(this.url+"getEventByIdCust/"+tz)
  }

}
