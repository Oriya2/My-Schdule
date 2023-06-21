import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CalendarOptions } from '@fullcalendar/angular';
import { AbilityForProfessional } from 'src/app/classes/AbilityForProfessional';
import { Professionals } from 'src/app/classes/Professionals';
import { tasks } from 'src/app/classes/tasks';
import { TypeAbility } from 'src/app/classes/TypeAbility';
import { AbilityProfessionService } from 'src/app/services/ability-profession.service';
import { CalendarService } from 'src/app/services/calendar.service';
import { ProfessionalsService } from 'src/app/services/professionals.service';
import { TaskService } from 'src/app/services/task.service';
import { TypeAbilityService } from 'src/app/services/type-ability.service';
import { UsersService } from 'src/app/services/users.service';
import { formatDate } from '@fullcalendar/core'
import swal from 'sweetalert';
import { calendarEvent } from 'src/app/classes/calendarEvent';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {




  
  newTask: tasks = new tasks()
  AbilityName: string
  tz: string
  codeProf: number
  p: Professionals = new Professionals()
  lAbility: Array<AbilityForProfessional> = new Array<AbilityForProfessional>()
  lTypeAbility: Array<TypeAbility> = new Array<TypeAbility>()

  clk: boolean = false
  calendarOptions: CalendarOptions = {
    height:700,
    initialView: 'dayGridMonth',
    dateClick: this.handleDateClick.bind(this),
    eventClassNames: 'uuu',


    navLinks: true, // can click day/week names to navigate views

    // bind is important!
    // events: [
    //     { title: 'event 1', date: '2021-12-01' , color:"red"},
    //     { title: 'event 2', date: '2021-12-05' }
    // ],

  };

  // t=typeof( this.calendarOptions.events[0])


  


  handleDateClick(arg) {
    this.clk = true
    let y = arg.dayEl



  }
  addTasks() {
    this.newTask.DateInsert = new Date()
    this.newTask.endTime = new Date()
    this.newTask.requireStatus = 0
    this.myTaskServices.addTasks(this.newTask).subscribe(data => { swal("הפגישה נקבעה בהצלחה", "😉תענוג לעשות איתך עסקים", "success"); })


  }
  select() {

    let f = this.AbilityName
    this.myAbilityProfessionService.getAbilityForProfessionalByTz(this.p.tz).subscribe(data => {
      this.lAbility = data;
      this.newTask.typeAbilityCode = this.lAbility.filter(d => d.nameability = this.AbilityName)[0].abilityCode
    })

  }
  constructor(public cal: CalendarService, private router: Router, public user: UsersService,
    public myProfessionalsService: ProfessionalsService,
    private myTaskServices: TaskService, private active: ActivatedRoute,
    public myTypeAbilityService: TypeAbilityService,
    public myAbilityProfessionService: AbilityProfessionService) { }

    


  myList: Array<calendarEvent> = new Array<calendarEvent>()


  ngOnInit(): void {

    
debugger
    this.cal.getbyid(this.user.currentUser.tz).subscribe(d => {
      console.log(d);
      this.myList = d
      console.log(this.myList );
    })

    this.cal.getEventByIdCust(this.user.currentUser.tz).subscribe(d => {
      debugger
      console.log(d);
      this.myList=  this.myList.concat(d)
      console.log(this.myList)
      this.calendarOptions.events=this.myList

      console.log(this.calendarOptions.events);
      debugger
    })
  }
}
