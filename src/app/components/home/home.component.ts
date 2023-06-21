import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Professionals } from 'src/app/classes/Professionals';
import { Users } from 'src/app/classes/Users';
import { ProfessionalsService } from 'src/app/services/professionals.service';
import { UsersService } from 'src/app/services/users.service';
import { TypeProfessionService } from 'src/app/services/type-Profession.service';
import { document } from 'src/app/classes/document';
import { AbilityProfessionService } from 'src/app/services/ability-profession.service';
import { TypeProfession } from 'src/app/classes/TypeProfession';
import { AbilityForProfessional } from 'src/app/classes/AbilityForProfessional';
import { Router } from '@angular/router';
import { TypeAbility } from 'src/app/classes/TypeAbility';
import { TypeAbilityService } from 'src/app/services/type-ability.service';
import { Recommend } from 'src/app/classes/Recommend';
import { MdbTableDirective } from 'angular-bootstrap-md';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private myUsersService: UsersService,
    public myProfessionalsService: ProfessionalsService,
    public myTypeProfessionService: TypeProfessionService,
    public myTypeAbilityService: TypeAbilityService,
    public myAbilityProfessionService: AbilityProfessionService, public router: Router) { }

  selectProfessional: any
  selectedAbility: any
  selectedProffesionalAbility: TypeProfession = new TypeProfession()
  selectedProffesionalAbility1: any
  selectTypeProfessional: any
  name: string
  tz = this.myUsersService.tz
  file: document = new document();
  ability: AbilityForProfessional = new AbilityForProfessional()
  newProfessionals: Professionals = new Professionals()
  isShow: boolean = false
  isShow1: boolean = false
  lTypeAbility: Array<TypeAbility> = new Array<TypeAbility>()
  lprof: Array<Professionals> = new Array<Professionals>()
mone:number=0
  TypeAbility: TypeAbility = new TypeAbility()


  ngOnInit(): void {

    this.myProfessionalsService.getAllProfessional().subscribe(d => { this.myProfessionalsService.lProfessional = d;this.profFunc(); this.myProfessionalsService.lSelect = d; this.sortArrayProfByName(); this.myProfessionalsService.lSelect = d })
    this.myTypeProfessionService.getAllTypeProfession().subscribe(d => { this.myTypeProfessionService.lTypeProfession = d; this.myTypeProfessionService.lSelect = d; this.sortTypeProf(); this.myTypeProfessionService.lSelect = d }
    )
    
    this.selectProfessional = "בחר בעל עסק"
    this.selectTypeProfessional = "בחר מקצוע"

    this.myAbilityProfessionService.getAllAbilityForProfessional().subscribe(d => this.myAbilityProfessionService.lAbilityForProfessional = d)

  }

  sortTypeProf() {
    this.myTypeProfessionService.lTypeProfession = this.myTypeProfessionService.lTypeProfession.sort((a, b) => (a.professionalName > b.professionalName) ? 1 : ((b.professionalName > a.professionalName) ? -1 : 0))
  }

  sortArrayProfByName() {
    this.myProfessionalsService.lProfessional = this.myProfessionalsService.lProfessional.sort((a, b) => (a.name > b.name) ? 1 : ((b.name > a.name) ? -1 : 0))
  }

  sortByProfName() {
    this.myProfessionalsService.lProfessional.sort((a, b) => (a.nameProf > b.nameProf) ? 1 : ((b.nameProf > a.nameProf) ? -1 : 0))
  }
  cancelSort() {
    this.sortArrayProfByName()
  }
  profFunc(){
    this.myProfessionalsService.lProfessional.forEach(element => {
              debugger

        if(element.nameProf.length>1){
              element.realNameProf=element.nameProf[this.mone]       
this.mone++        }
      debugger
    });


  }

  Recommend: Array<Recommend> = new Array<Recommend>(
    { code: 1, pic: "Recommend1" },
    { code: 2, pic: "Recommend2" },
    { code: 3, pic: "Recommend3" },
    { code: 4, pic: "Recommend4" },
    { code: 5, pic: "Recommend5" },
    { code: 6, pic: "Recommend6" })

  mychange(input) {

    this.file = new document()
    this.file.FileName = input.target.files[0].name
    if (input.target.files && input.target.files[0]) {
      this.newProfessionals.pic = input.target.files[0].name
      var reader = new FileReader()
      let self = this
      reader.onload = function (e) {
        self.file.Base64 = (e.target as any).result
      }
      reader.readAsDataURL(input.target.files[0])
    }
  }

  ShowAbility(code: number) {
    this.TypeAbility.professionalTypeCode = code
    this.myTypeAbilityService.getTypeAbilityForProfessionalByTz(code).subscribe(data => this.lTypeAbility = data)
  }
 
  selectProf() {
    // lselect-לא משתנה
    // lProf משתנה
    let f = this.selectProfessional
    this.myProfessionalsService.lProfessional = this.myProfessionalsService.lSelect.filter(x => x.tz == this.selectProfessional)
  
  }

  showAllProf() {
    this.myProfessionalsService.lProfessional = this.myProfessionalsService.lSelect

  }

  selectAbility() {
    debugger
    let f = this.selectedAbility
    let myArr=[]
    this.myProfessionalsService.lProfessional.forEach(element => {
      element.jobs.forEach(element2 => {
        if(element2==this.selectedAbility)
        myArr.push(element)
      });
    });
    this.myProfessionalsService.lProfessional=myArr;
    // this.myProfessionalsService.lProfessional= this.myProfessionalsService.lProfessional.filter(s => s.jobs.filter(d => d == this.selectedAbility))
    console.log(this.myProfessionalsService.lProfessional);
    debugger
  }


  selectTypeProf() {
    let f = this.selectTypeProfessional
    this.myProfessionalsService.lProfessional = this.myProfessionalsService.lSelect.filter(s => s.nameProf == this.selectTypeProfessional)
  }

}

