import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TypeProfession } from '../classes/TypeProfession';

@Injectable({
  providedIn: 'root'
})
export class TypeProfessionService {
  url: string = "http://localhost:53661/api/TypeProfession/"
  lSelect: Array<TypeProfession> = new Array<TypeProfession>()
  lTypeProfession: Array<TypeProfession> = new Array<TypeProfession>()

  constructor(public http: HttpClient) { }

  getAllTypeProfession(): Observable<Array<TypeProfession>> {
    return this.http.get<Array<TypeProfession>>(this.url + "getAllTypeProfession")
  }

  addTypeProfessionals(p: TypeProfession): Observable<boolean> {
    return this.http.put<boolean>(this.url + "addTypeProfession", p)
  }
}

