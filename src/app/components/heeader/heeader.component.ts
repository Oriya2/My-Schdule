import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Users } from 'src/app/classes/Users';
import { ProfessionalsService } from 'src/app/services/professionals.service';
import { UsersService } from 'src/app/services/users.service';
import swal from 'sweetalert';

@Component({
  selector: 'app-heeader',
  templateUrl: './heeader.component.html',
  styleUrls: ['./heeader.component.scss']
})
export class HeeaderComponent implements OnInit {

  constructor(public myUserServise:UsersService, public router:Router, public myProfessionalsService: ProfessionalsService) { }
  // tz=this.myUserServise.tz
  ngOnInit(): void {
    
  }
  newUser:Users=new Users()
  myDate:Date=new Date()
    
  
  
 
  LogOut()
  {
    swal( "התנתקת בהצלחה מהמערכת","", "success");
    this.router.navigate(['/myHeader/myHome'])
    this.myUserServise.isNoConect=true
    this.myUserServise.isConect=false
    this.myUserServise.currentUser=null;
    this.myProfessionalsService.currentProf=null
    this.myProfessionalsService.ifProf=false


  }
  edit()
  {
    //Kנווט אותו לעמוד של עידכון
    this.myUserServise.updateUser(this.newUser).subscribe(data=>{  swal( "המשתמש עודכן בהצלחה","", "success");
  })
  }
}
