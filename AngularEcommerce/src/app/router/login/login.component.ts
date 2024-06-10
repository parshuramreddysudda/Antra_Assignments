import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {MatSnackBar, MatSnackBarConfig} from '@angular/material/snack-bar'
import { LoginService } from '../../services/login/login.service';
import { environment } from '../../../environments/environment.development';
import { NgToastComponent, NgToastModule, NgToastService, ToastMessage } from 'ng-angular-popup';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,NgToastModule],
templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
loginForm:any
registerForm:any
activeForm:'login' | 'register' ='login' 
 

constructor(private fb:FormBuilder,
  private router: Router,
  private toast:NgToastService,
  private loginService:LoginService
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
  // console.log("Login Form is ",this.loginForm.value);
  
  if(this.loginForm.valid){

    const loginDetails={
      email:this.loginForm.value?.email,
      password:this.loginForm.value?.password
    }
    this.loginService.login(loginDetails).subscribe(
      (data)=>{
        console.log(data.token);
        // this.toast.danger('Wrong Email and Password');
        this.loginService.setToken(data.token);
        
      },
      (err) =>{
        console.log("Authentication Failed ",err.error);
        this.toast.danger('Wrong Email and Password');
      
      }
    );
  }
}
register(){
  alert("Register Form")
  if(this.registerForm.valid){
      alert("Valid Form")
  }
}
}
