import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Professionals } from '../classes/Professionals';
import { Users } from '../classes/Users';

@Injectable({
  providedIn: 'root'
})
export class ProfessionalsService {

  constructor(public http:HttpClient) { }
  ifProf:boolean=false
  url:string="http://localhost:53661/api/Professional/"
  lProfessional:Array<Professionals>=new Array<Professionals>()
  lSelect:Array<Professionals>= new Array<Professionals>()
  currentProf:Professionals=new Professionals()
  templProfessional:Array<Professionals>=new Array<Professionals>()

  // שליפת כל הבעלי מקצוע
  // getAllProfessional
  getAllProfessional():Observable<Array<Professionals>>
  {
    return this.http.get<Array<Professionals>>(this.url+"getAllProfessional")
  }

  

 //שליפת בעל מקצוע לפי תעודת זהות
 getProfessionalByTz(tz:string):Observable<Professionals>
 {
   return this.http.get<Professionals>(this.url+"getProfessionalByTz/"+tz)
 }
 getAbilityForProfessionalByName(tz:string,name:string):Observable<Professionals>
 {
   return this.http.get<Professionals>(this.url+"getAbilityForProfessionalByName/"+tz+"/"+name)
 }
 ifExistProfessionalByTz(tz:string):Observable<Professionals>
 {
   return this.http.get<Professionals>(this.url+"ifExistProfessionalByTz/"+tz)
 }
 addProfessionals(p:Professionals,code:number):Observable<boolean>
 {
   return this.http.put<boolean>(this.url+"add/"+code,p)
 }
updateProfessionals(p:Professionals,code:number):Observable<boolean>
 {
   return this.http.post<boolean>(this.url+"updateProfessional/"+code,p)
 }
 deleteProf(id:number):Observable<boolean>
 {
   return this.http.delete<boolean>(this.url+"deleteProf/"+id)
 }
}
