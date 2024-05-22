import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {MatSnackBar} from '@angular/material/snack-bar'

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
loginForm:any
registerForm:any
activeForm:'login' | 'register' ='login' 


constructor(private fb:FormBuilder,
  private router: Router,
  private snackbar:MatSnackBar
){
}
ngOnInit(){
  this.loginForm=this.fb.group({
    email:['',[Validators.required,Validators.email]],
    password:['',[Validators.required,Validators.minLength(8)]]
  })

  this.registerForm=this.fb.group({
    email:['',[Validators.required,Validators.email]],
    password:['',[Validators.required,Validators.minLength(8)]]
  })
}
toggleForm(form:'login'|'register'){
  this.activeForm=form
}

login(){
  // alert("Login Form")
  console.log("Login Form is ",this.loginForm.value);
  
  if(this.loginForm.valid){
    
      this.snackbar.open("Form is Valid",'Close',{duration:3000, horizontalPosition: 'start',
      verticalPosition: 'top',
      panelClass: ['snackbar-top-left']})

  }
}
register(){
  alert("Regoster Form")
  if(this.registerForm.valid){
      alert("Valid Form")
  }
}

}
