import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Users } from 'src/app/classes/Users';
import { UsersService } from 'src/app/services/users.service';
import  swal from 'sweetalert';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {

  constructor(
    public myUsersService: UsersService,    private router: Router,

  ) { }

  ngOnInit(): void {
 this.myUsersService.getAllUsers().subscribe(d=>this.lUsers=d)
  }
  tzUser:string
  userToUpdate:Users=new Users()
  lUsers:Array<Users>=new Array<Users>()
  reset()
  {
    debugger
    this.userToUpdate=this.lUsers.filter(d=>d.tz==this.tzUser)[0]
    this.userToUpdate.password = Math.random().toString(36).slice(-8);

    this.myUsersService.updateUser(this.userToUpdate).subscribe(data => {
      debugger;
        swal(this.userToUpdate.password+"הסיסמא החדשה שלך היא:   "  , " 😎 אנא היכנס איתה בפעם הבאה", "success");

      this.router.navigate(['/myHeader/myLogin'])

    })
    
  }
}
