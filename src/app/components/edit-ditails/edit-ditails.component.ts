import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbilityForProfessional } from 'src/app/classes/AbilityForProfessional';
// import { ProfessionalsService } from '../services/professionals.service';
import { document } from 'src/app/classes/document';
import { Professionals } from 'src/app/classes/Professionals';
import { TypeAbility } from 'src/app/classes/TypeAbility';
import { TypeProfession } from 'src/app/classes/TypeProfession';
import { Users } from 'src/app/classes/Users';
import { AbilityProfessionService } from 'src/app/services/ability-profession.service';
import { ProfessionalsService } from 'src/app/services/professionals.service';
import { TypeAbilityService } from 'src/app/services/type-ability.service';
// import { AbilityProfessionService } from '../services/ability-profession.service';
import { TypeProfessionService } from 'src/app/services/type-Profession.service';
import { UsersService } from 'src/app/services/users.service';
import swal from 'sweetalert';


@Component({
  selector: 'app-edit-ditails',
  templateUrl: './edit-ditails.component.html',
  styleUrls: ['./edit-ditails.component.scss']
})
export class EditDitailsComponent implements OnInit {
  checked: boolean = false;
  file: document = new document();
  updateProfesional: Professionals = new Professionals()
  updateUser: Users = new Users()
  selectedProffesionalAbility1: any
  TypeAbility: TypeAbility = new TypeAbility()
  TryTypeAbility:  Array<TypeAbility> = new Array<TypeAbility>()
  TypeAbilityExist:TypeAbility = new TypeAbility()
  isShow1: boolean = false
  lTypeAbility: Array<TypeAbility> = new Array<TypeAbility>()
  lTypeAbility1: Array<TypeAbility> = new Array<TypeAbility>()
  lTypeAbility2: Array<TypeAbility> = new Array<TypeAbility>()

  lTypeProf: Array<TypeProfession> = new Array<TypeProfession>()
  ability: AbilityForProfessional = new AbilityForProfessional()
  newProfessionals: Professionals = new Professionals()
  isShow: boolean = false
  nameProf: string
  ProfType:  Array<TypeProfession> = new Array<TypeProfession>()
  constructor(public myUsersService: UsersService,
    private router: Router,
    public myProfessionalsService: ProfessionalsService,
    public myAbilityProfessionService: AbilityProfessionService,
    public myTypeProfessionService: TypeProfessionService,
    public myTypeAbilityService: TypeAbilityService,

  ) { }

  ngOnInit(): void {
    this.updateUser = this.myUsersService.currentUser
    this.updateProfesional = this.myProfessionalsService.currentProf
    this.newProfessionals.tz = this.myUsersService.currentUser.tz
  }

  fun1() {
    debugger
    this.isShow1 = !this.isShow1
    this.myTypeProfessionService.getAllTypeProfession().subscribe(d => {
      this.lTypeProf = d
      debugger;
      this.myProfessionalsService.currentProf.nameProf.forEach(element => {
        this.ProfType.push(this.lTypeProf.filter(d =>d.professionalName==element)[0]);

        });
  
      this.ProfType.forEach(element => {
      this.myTypeAbilityService.getTypeAbilityForProfessionalByTz(element.professionalTypeCode).subscribe(data =>this.lTypeAbility1= this.lTypeAbility1.concat(data) );
        console.log(this.TryTypeAbility)
      });
      // this.lTypeAbility1=this.TryTypeAbility
      console.log(this.lTypeAbility1)
    })
  }
   ShowAbility(code: number) {
    this.TypeAbility.professionalTypeCode = code
    this.myTypeAbilityService.getTypeAbilityForProfessionalByTz(code).subscribe(data => this.lTypeAbility = data)
  }
  ShowAbilityExist(code: number) {
    this.TypeAbilityExist.professionalTypeCode = code
    this.myTypeAbilityService.getTypeAbilityForProfessionalByTz(code).subscribe(data => this.lTypeAbility2 = data)
  }
 ShowAbilitytoNewProf() {
    this.myTypeAbilityService.getAllTypeAbilityForProfession().subscribe(d => this.lTypeAbility1 = d)
   this.myProfessionalsService.currentProf.nameProf.forEach(element => {  
       let r = this.lTypeAbility1.filter(d => d.abilityName ==element )[0].abilityCode
    this.myTypeAbilityService.getTypeAbilityForProfessionalByTz(r).subscribe(data =>this.lTypeAbility= this.lTypeAbility.concat(data))

      });
  }
  ShowAbilitytoExistProf() {

    this.myTypeAbilityService.getAllTypeAbilityForProfession().subscribe(d => this.lTypeAbility2 = d)
       let r = this.lTypeAbility1.filter(d => d.abilityName ==this.selectedProffesionalAbility1 )[0].abilityCode
    this.myTypeAbilityService.getTypeAbilityForProfessionalByTz(r).subscribe(data =>this.lTypeAbility2= data)

     
  }
   addAbility() {

    this.ability.abilityCode = this.TypeAbility.abilityCode
    this.ability.tzProfessional = this.myUsersService.currentUser.tz
    this.ability.taskLength = 5.0
    this.myAbilityProfessionService.addAbilityForProfessionals(this.ability).subscribe(data => {swal( "היכולת התווספה בהצלחה!!","", "success");
  })
  }
  mychange(input) {
    this.file = new document()
    this.file.FileName = input.target.files[0].name
    if (input.target.files && input.target.files[0]) {
      this.updateProfesional.pic = input.target.files[0].name
      this.newProfessionals.pic = input.target.files[0].name

      var reader = new FileReader()
      let self = this
      reader.onload = function (e) {
        self.file.Base64 = (e.target as any).result
      }
      reader.readAsDataURL(input.target.files[0])
    }
  }
  fun() {
    this.isShow = !this.isShow

  } 
  addProf() {
    debugger
    this.ability.tzProfessional = this.newProfessionals.tz
    this.ability.abilityCode = this.selectedProffesionalAbility1
    this.ability.taskLength = 2.4
    //  this.nameProf= this.myTypeProfessionService.lTypeProfession.filter(d=>d.professionalTypeCode==this.selectedProffesionalAbility1)[0].professionalName
    this.myProfessionalsService.addProfessionals(this.newProfessionals, this.selectedProffesionalAbility1).subscribe(data => {         swal("המקצוע עודכן בהצלחה","", "success");
  })

  }
  selectAbility() {

    let f = this.selectedProffesionalAbility1
  }
  updateUsers() {
    debugger;
    let sendMail: boolean
    this.myUsersService.updateUser(this.updateUser).subscribe(data => {
      // this.myUsersService.currentUser = data;
      // this.myUsersService.SendMassageUserRegister().subscribe(data => {
      //   sendMail = data;
      //   if (sendMail)
      //     alert("ברגעים אלה נשלח אליך מייל עם ססמתך החדשה")
      // }
      // )
      if (this.myProfessionalsService.ifProf == true) {
        debugger;
        this.updateProfesional.tz = this.updateUser.tz
        this.myProfessionalsService.updateProfessionals(this.updateProfesional,this.TypeAbility.abilityCode).subscribe(
          data => {
            swal( "המקצוע עודכן בהצלחה","", "success");

            // this.myProfessionalsService.currentProf = this.updateProfesional;
            // this.myUsersService.currentUser = this.updateProfesional;
          })
      }
      swal( "נרשמת בהצלחה","פרטיך נקלטו במערכת", "success");
      this.router.navigate(['/myHeader/myHome'])
    })
  }
  

  
  
    deleteUser() {
  //   swal({
  //   title:"Are you sure?",
  //   text:"Your will not be able to recover this imaginary file!",
  //   type: "warning",
  //   showCancelButton: true,
  //   confirmButtonClass: "btn-danger",
  //   confirmButtonText: "Yes, delete it!",
  //   closeOnConfirm: false,
  // },
  // function(){
  //   swal("Deleted!", "Your imaginary file has been deleted.", "success");
  // });
  
   
      return this.myUsersService.deleteUser(this.myUsersService.currentUser.tz).subscribe(data => {
        if (this.myProfessionalsService.ifProf)
          this.myProfessionalsService.deleteProf(this.myProfessionalsService.currentProf.code).subscribe(data => {
          });
swal( "המשתמש נמחק בהצלחה","", "success");
         this.router.navigate(['/myHeader/myHome']);
        this.myUsersService.isNoConect = true;
        this.myUsersService.isConect = false;
      })
      

    }

  
}
