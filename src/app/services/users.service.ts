import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Users } from '../classes/Users';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  url: string = "http://localhost:53661/api/Users/"
  lUsers: Array<Users> = new Array<Users>()

  // tz:string=null
  // password:string=null

  isShow = false
  isConect: boolean = false
  isNoConect: boolean = true
  nameInHome: string
  tz: string
  password: string
  currentUser: Users = new Users()
  newUserService: Users = new Users()
  tzUserToReset

  randomPassword = Math.random().toString(36).slice(-8);
  newPassword = Math.random().toString(36).slice(-8);

  // lUsers:Array<Users>=new Array<Users>()

  //שליפת כל המשתמשים
  getAllUsers(): Observable<Array<Users>> {
    return this.http.get<Array<Users>>(this.url + "getAllUsers")
  }
  getUserByTz(tz: string): Observable<Users> {
    return this.http.get<Users>(this.url + "getUserByTz/" + tz)
  }
  // בדיקה אם משתמש קיים לפי ת.ז. וסיסמא
  checkIfCustomerExist(tz: string, password: string): Observable<Users> {
    debugger
    return this.http.get<Users>(this.url + "checkIfCustomerExist/" + tz.trim() + "/" + password.trim())
  }
  add(u: Users): Observable<Array<Users>> {
    return this.http.put<Array<Users>>(this.url + "add", u)

  }
  //שליחת מייל לאישור הרשמה
  SendMassageUserRegister(): Observable<boolean> {
    
    return this.http.get<boolean>(this.url + "SendMassage/" + this.currentUser.mail.trim() + "/" + 1 + "/" + this.currentUser.password.trim())
  }
  //שליחת מייל עם סיסמא מאופסת
  //  mailReeserPassword():Observable<boolean>
  //  {

  //   //  return this.http.get
  //  }


  // newPassword() {

    // var randomstring = Math.random().toString(36).slice(-8);

  // }
  //עידכון פרטי משתמש
  updateUser(u: Users): Observable<Users> {
    return this.http.post<Users>(this.url + "update", u)
  }
  updatePassword(u: Users):Observable<boolean> {

    return this.http.post<boolean>(this.url + "updatePassword" ,u)
  }

  // updatePassword(tz:string)
  // {
  //   return this.http
  // }

  //עידכון סיסמא
  // updateClothes(tz:string,  newPassword:string): Observable<boolean> {
  //   return this.http.post<boolean>(this.url + "updatePassword/"+this.tzUserToReset.trim()+"/"+this.newPassword.trim())
  // }
  deleteUser(tz:string):Observable<boolean>{

    return this.http.delete<boolean>(this.url + "deleteUser/"+ tz)

  }
}
