import { Time } from '@angular/common';
import { newArray } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AbilityForProfessional } from 'src/app/classes/AbilityForProfessional';
import { Professionals } from 'src/app/classes/Professionals';
import { tasks } from 'src/app/classes/tasks';
import { TypeAbility } from 'src/app/classes/TypeAbility';
import { AbilityProfessionService } from 'src/app/services/ability-profession.service';
import { ProfessionalsService } from 'src/app/services/professionals.service';
import { TaskService } from 'src/app/services/task.service';
import { TypeAbilityService } from 'src/app/services/type-ability.service';
import { UsersService } from 'src/app/services/users.service';
import swal from 'sweetalert';

@Component({
  selector: 'app-add-meeting',
  templateUrl: './add-meeting.component.html',
  styleUrls: ['./add-meeting.component.scss']
})
export class AddMeetingComponent implements OnInit {
  // newMeeting:meeting=new meeting()
  newTask: tasks = new tasks()
  AbilityName: string
  tz: string
  codeProf: number
  p: Professionals = new Professionals()
  lAbility: Array<AbilityForProfessional> = new Array<AbilityForProfessional>()
  lTypeAbility: Array<TypeAbility> = new Array<TypeAbility>()
  t: any
  timepicker: Date = new Date()

  constructor(public myProfessionalsService: ProfessionalsService,
    private myTaskServices: TaskService, private active: ActivatedRoute,
    public myTypeAbilityService: TypeAbilityService,
    public myAbilityProfessionService: AbilityProfessionService, private router: Router,
    public myUserServices: UsersService) { }

  ngOnInit(): void {
    this.active.params.subscribe(d => {
      this.tz = d["tz"];
      this.p = this.myProfessionalsService.lProfessional.find(f => f.tz == this.tz)
      this.newTask.tzClient = this.myUserServices.currentUser.tz
      this.newTask.tzProfessional = this.tz
      this.newTask.nameProfessional = this.p.name
      console.log()
    })
  }


  addTasks() {
    this.newTask.DateInsert = new Date()
    console.log(this.t);
    console.log(this.timepicker);
    this.newTask.startTime = this.timepicker;
    this.newTask.RangeDays = this.lAbility.filter(d => d.nameability == this.AbilityName)[0].taskLength
    if (this.newTask.RangeDays <= 8)
      this.newTask.endTime = this.newTask.startTime
    else {
      let i = this.newTask.RangeDays / 8
      // this.newTask.endTime.setDate(this.newTask.endTime.getDate() + i)
      this.newTask.endTime = this.newTask.startTime
    }
    this.newTask.requireStatus = 0
    console.log(this.newTask);

    this.myTaskServices.addTasks(this.newTask).subscribe(data => {
      debugger
      if(data==true){
      swal("הפגישה נקבעה בהצלחה", "😉תענוג לעשות איתך עסקים", "success");
      this.router.navigate(['/myHeader/myPersonalArea'])}
      else
      swal(" נסה שוב", " הפגישה לא נקבעה לצערי", "error");

    }, err => {
      debugger
      swal(" נסה שוב", " הפגישה לא נקבעה לצערי", "error");
      alert(err);
      alert("הפגישה לא נקבעה")
    })


  }
  select() {
    let f = this.AbilityName
    this.myAbilityProfessionService.getAbilityForProfessionalByTz(this.p.tz).subscribe(data => {
      this.lAbility = data;
      this.newTask.typeAbilityCode = this.lAbility.filter(d => d.nameability == this.AbilityName)[0].abilityCode
    })
  }
}
