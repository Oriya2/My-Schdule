import { Component, OnInit, Directive, ViewChild, HostListener } from '@angular/core';
import { MdbTableDirective } from 'angular-bootstrap-md';
import { tasks } from 'src/app/classes/tasks';
import { Users } from 'src/app/classes/Users';
import { ProfessionalsService } from 'src/app/services/professionals.service';
import { TaskService } from 'src/app/services/task.service';
import { UsersService } from 'src/app/services/users.service';
import swal from 'sweetalert';

@Component({
  selector: 'app-personal-area',
  templateUrl: './personal-area.component.html',
  styleUrls: ['./personal-area.component.scss']
})
export class PersonalAreaComponent implements OnInit {
  myDate: Date = new Date()
  enTask: tasks = new tasks()
  ok: string = "אושרה"
  notOk: string = "מחכה לאישור"
  cancled: string = "בוטלה"
  statusNum: Array<number> = new Array<number>(1, 2, 3)
  tempUser: Users = new Users()
  todayMeeting: boolean = true
  wait:number=0

  constructor(public myTaskService: TaskService, public myUsersService: UsersService, public myProfessionalsService: ProfessionalsService) { }
  // this.myProfessionalsService.getAllProfessional().subscribe(d => { this.myProfessionalsService.lProfessional = d; this.myProfessionalsService.lSelect = d }, e => { })

  ngOnInit(): void {
    debugger
    this.myTaskService.getAlltasks().subscribe(d => { this.myTaskService.LTaskProfessional = d;
      
                                                      this.myTaskService.LTaskCustomer = d; 
                                                      this.myDate = new Date(); this.myTaskService.LTaskDay = d; 
                                                      this.showTask(); 
                                                      this.funct(); 
                                                      
                                                      this.calcWait();
                                                    })
 
  }
  
  calcWait()
  {
    debugger
    this.myTaskService.LTaskProfessional.forEach(element => {
      debugger
        if(element.requireStatus==0)
          this.wait++
    });
  }

  showTask() {
    debugger
    this.myTaskService.LTaskProfessional = this.myTaskService.LTaskProfessional.filter(d => d.tzProfessional == this.myUsersService.currentUser.tz)
    this.myTaskService.LTaskCustomer = this.myTaskService.LTaskCustomer.filter(d => d.tzClient == this.myUsersService.currentUser.tz)
    debugger
    this.myTaskService.LTaskDay = this.myTaskService.LTaskProfessional.filter(d => d.startTime.getDate==this.myDate.getDate)
    console.log(this.myTaskService.LTaskDay)
    if (this.myTaskService.LTaskDay.length == 0)
      this.todayMeeting = false
  }

  enable(code: number) {
    debugger
    this.myTaskService.getTasksByCode(code).subscribe(data => {
      this.enTask = data;
      this.enTask.requireStatus = 2;
      debugger
      this.enTask.massage = this.ok;
      this.myTaskService.update(this.enTask).subscribe(data => this.enTask = data);
      swal( "הפגישה אושרה בהצלחה!!","", "success");

      this.wait=0
      this.ngOnInit();
      
    }
    )
  }

  disable(code: number) {
    this.myTaskService.getTasksByCode(code).subscribe(data => {
      this.enTask = data;
      this.enTask.requireStatus = 1;
      this.enTask.massage = this.cancled;
      this.myTaskService.update(this.enTask).subscribe(data => this.enTask = data);
      swal( "הפגישה בוטלה בהצלחה!!","", "success");
      this.tempUser = this.myUsersService.currentUser
      this.wait=0
      this.ngOnInit();
    })

  }
  // 0=לא אושרה
  // 1=בוטלה
  // 2=אושרה
  funct() {
    let f = this.myTaskService.LTaskCustomer;
    for (let i = 0; i < f.length; i++) {
      if (f[i].requireStatus == 2) {
        f[i].yes = true
        f[i].massage = this.ok
      }
      else if (f[i].requireStatus == 1)
        f[i].massage = this.cancled
      else {
        f[i].yes = false
        f[i].massage = this.notOk
      }
    }
  }
}