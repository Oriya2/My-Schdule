import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TypeAbility } from '../classes/TypeAbility';

@Injectable({
  providedIn: 'root'
})
export class TypeAbilityService {
  url:string="http://localhost:53661/api/TypeAbilityForProfession/"

  constructor(public http:HttpClient) { }
  getTypeAbilityForProfessionalByTz(code:number):Observable<Array< TypeAbility>>
  {
    return this.http.get<Array<TypeAbility>>(this.url+"getTypeAbilityForProfessionalByTz/"+code)
  }
  getAllTypeAbilityForProfession():Observable<Array< TypeAbility>>
  {
      return this.http.get<Array<TypeAbility>>(this.url+"getAllTypeAbilityForProfession")
  }
  addTypeAbilityForProfession(t:TypeAbility):Observable<boolean>
  {
    return this.http.post<boolean>(this.url+"addTypeAbilityForProfession",t)
  }
}
