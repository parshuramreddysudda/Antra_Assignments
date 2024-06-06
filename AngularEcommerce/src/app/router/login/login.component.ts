import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {MatSnackBar, MatSnackBarConfig} from '@angular/material/snack-bar'
import { LoginService } from '../../services/login/login.service';

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
  private snackbar:MatSnackBar,
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
  console.log("Login Form is ",this.loginForm.value);
  
  if(this.loginForm.valid){


    const loginDetails={
      email:this.loginForm.value?.email,
      password:this.loginForm.value?.password
    }
    this.loginService.login(loginDetails).subscribe(
      (data)=>{
        this.openSnackBar('Authentication successful', 'success-snackbar');
        console.log(data.token);
        localStorage.setItem("AngularCookie",data.token);
        
        
      },
      (err) =>{
        console.log("Authentication Failed ",err.error);
        this.openSnackBar('Wrong Email and Password', 'error-snackbar');
      
      }
    );
    
 

  }
}
register(){
  alert("Regoster Form")
  if(this.registerForm.valid){
      alert("Valid Form")
  }
}

openSnackBar(message: string, panelClass: string): void {
  const config = new MatSnackBarConfig();
  config.duration = 3000;
  config.horizontalPosition = 'start';
  config.verticalPosition = 'top';
  config.panelClass = [panelClass];
  this.snackbar.open(message, 'Close', config);
}

}
