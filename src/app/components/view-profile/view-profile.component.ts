import { Component, OnInit } from '@angular/core';
import { Users } from 'src/app/classes/Users';
import { UsersService } from 'src/app/services/users.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Professionals } from 'src/app/classes/Professionals';
import { ProfessionalsService } from 'src/app/services/professionals.service';
import swal from 'sweetalert';



@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.scss']
})
export class ViewProfileComponent implements OnInit {
tz:string
pic:string
p:Professionals=new Professionals()
doesJobs:boolean=false

  constructor(private myUsersService:UsersService, private router:Router, private active:ActivatedRoute,private myProfessionalsService:ProfessionalsService) { }
  ngOnInit() {
    
      this.active.params.subscribe(d=>{this.tz=d["tz"]})
      this.p=this.myProfessionalsService.lProfessional.find(f => f.tz==this.tz)
      if(this.p.jobs.length>0)
        this.doesJobs=true
    }
    doedConect(tz)
    {
      
      if(this.myUsersService.isConect)
      {
        this.router.navigate(['/myHeader/myAddMeeting/',tz])
      }
      else
      {
        swal( "לא ניתן לקבוע פגישה ללא התחברות לאתר","הינך מועבר לעמוד ההתחברות", "error");


        this.router.navigate(['/myHeader/myLogin'])

      }
    }
}