import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {MatSnackBar, MatSnackBarConfig} from '@angular/material/snack-bar'
import { LoginService } from '../../services/login/login.service';
import { environment } from '../../../environments/environment.development';
import { NgToastComponent, NgToastModule, NgToastService, ToastMessage } from 'ng-angular-popup';
import { Store } from '@ngrx/store';
import { AppState } from '../../states/app.state';
import { addLoginInfo } from '../../states/user/user.action';

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
  private store:Store<AppState>,
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
    password:['',[Validators.required,Validators.minLength(8)]],
    role:['',[]],
    firstName:['',[Validators.required,Validators.minLength(4)]],
    lastName:['',[Validators.required,Validators.minLength(4)]],
    gender:['',Validators.minLength(1)],
    phone:['',[]],
    profilePic:['',[Validators.required]],
  })
}
toggleForm(form:'login'|'register'){
  this.activeForm=form
}

login(){
  
  if(this.loginForm.valid){

    const loginDetails={
      email:this.loginForm.value?.email,
      password:this.loginForm.value?.password
    }
    this.loginService.login(loginDetails);
  }
}
register(){
  // alert("Register Form"+this.registerForm.valid)
  console.log(this.registerForm);
  
  if(this.registerForm.valid){
      
    const registerDetails={
      email:this.registerForm.value?.email,
      password:this.registerForm.value?.password,
      role:'',
      firstName:this.registerForm.value?.firstName,
      lastName:this.registerForm.value?.lastName,
      gender:this.registerForm.value?.gender,
      phone:this.registerForm.value?.phone,
      profilePic:this.registerForm.value?.profilePic,
    }
    this.loginService.register(registerDetails);
  }
}
}
