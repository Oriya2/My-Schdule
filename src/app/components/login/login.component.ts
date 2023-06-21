import { Component, OnInit, ɵɵpureFunction1 } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Professionals } from 'src/app/classes/Professionals';
import { Users } from 'src/app/classes/Users';
import { ProfessionalsService } from 'src/app/services/professionals.service';
import { UsersService } from 'src/app/services/users.service';
import swal from 'sweetalert';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private myUsersService: UsersService, public myProfessionalsService: ProfessionalsService,
    private router: Router) { }
  newUser: Users = new Users()
  notSubscribe: boolean = false
  checked: boolean = false;
  newProf: Professionals = new Professionals()
  newName: string

  ngOnInit(): void { }

  validatingForm: FormGroup;

  //login
  login() {
    debugger

    this.myUsersService.checkIfCustomerExist(this.newUser.tz, this.newUser.password).subscribe(data => {
      this.myUsersService.currentUser = data;
      this.myProfessionalsService.ifExistProfessionalByTz(this.newUser.tz).subscribe(data => { this.newProf = data;  
         if (this.newProf != null&& this.myUsersService.currentUser!=null) {
        this.myProfessionalsService.ifProf = true
        this.myProfessionalsService.getProfessionalByTz(this.newProf.tz).subscribe(data => {
          this.myProfessionalsService.currentProf = data;
        })
        this.newUser.tz = this.newProf.tz
        this.myUsersService.getUserByTz(this.newUser.tz).subscribe(data => {
        this.myUsersService.currentUser = data;
        this.newUser = data
        })
        
         swal("היי " + this.newProf.name + " -בעל עסק", "😉כיף לראות אותך שוב", "success");


        this.router.navigate(['/myHeader/myPersonalArea'])
        // this.router.navigate(['/myHeader/myEdit'])
        
        this.myUsersService.isConect = true
        this.myUsersService.isNoConect = false
        this.myUsersService.nameInHome = this.newProf.name
        this.myUsersService.tz = this.newUser.tz
      }
      else {
        debugger
        if (this.myUsersService.currentUser && this.myProfessionalsService.ifProf == false) {
         swal("היי " + this.myUsersService.currentUser.firstName + " " + this.myUsersService.currentUser.lastName + " -לקוח", "😉כיף לראות אותך שוב", "success");
          this.router.navigate(['/myHeader/myHome'])
          this.myUsersService.isConect = true
          this.myUsersService.isNoConect = false
          this.myUsersService.nameInHome = this.newUser.firstName + " " + this.newUser.lastName
          this.myUsersService.tz = this.newUser.tz
        }
        else {
          swal("אופסס אתה לא רשום המערכת","הינך מועבר לעמוד ההרשמה", "error");
          this.router.navigate(["/myHeader/myRegister"])

        }
      }
     });
 })
}
}
