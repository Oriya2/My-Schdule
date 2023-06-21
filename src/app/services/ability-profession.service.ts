import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AbilityForProfessional } from '../classes/AbilityForProfessional';

@Injectable({
  providedIn: 'root'
})
export class AbilityProfessionService {
  url:string="http://localhost:53661/api/AbilityForProfessional/"
  lSelect:Array<AbilityForProfessional>= new Array<AbilityForProfessional>()
  lAbilityForProfessional:Array<AbilityForProfessional>=new Array<AbilityForProfessional>()

  constructor(public http:HttpClient) { }

  getAllAbilityForProfessional():Observable<Array<AbilityForProfessional>>
  {
    return this.http.get<Array<AbilityForProfessional>>(this.url+"getAllAbilityForProfessional")
  }
  getAbilityForProfessionalByTz(tz:string):Observable<Array<AbilityForProfessional>>
  {
    return this.http.get<Array<AbilityForProfessional>>(this.url+"getAbilityForProfessionalByTz/"+tz)
  }
  addAbilityForProfessionals(a:AbilityForProfessional):Observable<boolean>
 {
   return this.http.put<boolean>(this.url+"add",a)
 }
}