import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { send } from 'process';
import { Professionals } from 'src/app/classes/Professionals';
import { Users } from 'src/app/classes/Users';
import { document } from 'src/app/classes/document';

import { UsersService } from 'src/app/services/users.service';
import { ProfessionalsService } from 'src/app/services/professionals.service';
import { TypeProfessionService } from 'src/app/services/type-Profession.service';
import swal from 'sweetalert';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {
  newUser: Users = new Users()
  checked: boolean = false;
  good: number = 0;
  file: document = new document();
  selectedProffesionalAbility1: any
  newProfesional: Professionals = new Professionals()
  codeProf: number


  constructor(private myUsersService: UsersService,
    private router: Router,
    public myTypeProfessionService: TypeProfessionService,

    private myProfessionalsService: ProfessionalsService) { }

  ngOnInit(): void { }
  selectAbility() {
    let f = this.selectedProffesionalAbility1
  }
  mychange(input) {
    this.file = new document()
    this.file.FileName = input.target.files[0].name
    if (input.target.files && input.target.files[0]) {

      this.newProfesional.pic = input.target.files[0].name
      var reader = new FileReader()
      let self = this
      reader.onload = function (e) {
        self.file.Base64 = (e.target as any).result
      }
      reader.readAsDataURL(input.target.files[0])
    }
  }

  aaa: boolean = false

  ch() {
    this.aaa = !this.aaa
  }

  addUser() {
    debugger
    let sendMail: boolean
    this.myUsersService.add(this.newUser).subscribe(data => {
      this.myUsersService.lUsers = data;
      this.myUsersService.currentUser = this.newUser;
      // this.myUsersService.SendMassageUserRegister().subscribe(data => {
      //   sendMail = data;
      //   if (sendMail)
      //     alert("ברגעים אלה נשלח אליך מייל עם ססמתך החדשה")
      // }
      // )

      if (this.aaa == true) {
        this.newProfesional.tz = this.newUser.tz
        this.myProfessionalsService.addProfessionals(this.newProfesional, this.codeProf).subscribe(
          data => {
            this.myProfessionalsService.currentProf = this.newProfesional;
            debugger;
            this.myUsersService.currentUser = this.newProfesional;
          }
        )
      }
      swal( "נרשמת בהצלחה","פרטייך נקלטו במערת", "success");
      this.router.navigate(['/myHeader/myHome'])
      this.myUsersService.isConect = true
      this.myUsersService.isNoConect = false
      this.myUsersService.nameInHome = this.newUser.firstName + " " + this.newUser.lastName
      this.myUsersService.tz = this.newUser.tz
    })
  }
}