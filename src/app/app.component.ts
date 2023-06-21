import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbilityProfessionService } from './services/ability-profession.service';
import { ProfessionalsService } from './services/professionals.service';
import { UsersService } from './services/users.service';
import { TypeProfessionService } from 'src/app/services/type-Profession.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  // implements OnInit{
  constructor(private myRouter: Router,
    private myProfessionalsService: ProfessionalsService,
    private myUsersService: UsersService,
    private myTypeProfessionService:TypeProfessionService
  ) { }


  ngOnInit(): void {
    this.myRouter.navigate(['myHeader/myHome'])
    
    // this.myRouter.navigate(['myHeader/myRegister'])

  }

  
}