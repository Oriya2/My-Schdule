import {  OnInit } from '@angular/core';
import { Component } from '@angular/core';
  import {FormControl, FormGroup, Validators} from "@angular/forms";
@Component({
  selector: 'app-edid-pro',
  templateUrl: './edid-pro.component.html',
  styleUrls: ['./edid-pro.component.scss']
})
export class EdidProComponent implements OnInit {
    validatingForm: FormGroup;

  constructor() { }

  ngOnInit(): void { this.validatingForm = new FormGroup({
        loginFormModalEmail: new FormControl('', Validators.email),
        loginFormModalPassword: new FormControl('', Validators.required)
      });
  }
  
  
    get loginFormModalEmail() {
      return this.validatingForm.get('loginFormModalEmail');
    }
  
    get loginFormModalPassword() {
      return this.validatingForm.get('loginFormModalPassword');
    }
  }

