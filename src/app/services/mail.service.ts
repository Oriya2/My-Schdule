import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MailService {
  url:string="http://localhost:53661/api/Users/"

  constructor() { }
  // sendMail(contactAddress:string,  subject:string,  body:string):Observable<null>
  //  {

    // return this.http.put<boolean>(this.url+"checkIfCustomerExist/"+usingName+"/"+password)

    // return  this.http.get<Users>(this.url+"checkIfCustomerExist/"+tz.trim()+"/"+password.trim())
   
  // }


  //  add(u:Users):Observable<Array<Users>>
  //  {
  //    return this.http.put<Array<Users>>(this.url+"add",u)
  //  }
}
