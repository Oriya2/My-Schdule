import { Component, OnInit } from '@angular/core';
import { Professionals } from 'src/app/classes/Professionals';

@Component({
  selector: 'app-add-poffesional',
  templateUrl: './add-poffesional.component.html',
  styleUrls: ['./add-poffesional.component.scss']
})
export class AddPoffesionalComponent implements OnInit {
  // newUser:Users=new Users()
  newProffosional:Professionals=new Professionals()
  constructor() { }

  ngOnInit(): void {
  }
  addProffesional()
  {}

}
