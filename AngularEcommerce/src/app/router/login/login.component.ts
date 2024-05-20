import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

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


constructor(private fb:FormBuilder){
}
ngOnInit(){
  this.loginForm=this.fb.group({
    email:['',Validators.required,Validators.email],
    password:['',Validators.required,Validators]
  })

  this.registerForm=this.fb.group({
    email:['',Validators.required,Validators.email],
    password:['',Validators.required,Validators]
  })
}
toggleForm(form:'login'|'register'){
  this.activeForm=form
}

login(){
  alert("Login Form")
  if(this.loginForm.valid){
      alert("Valid Form")
  }
}
register(){
  alert("Regoster Form")
  if(this.registerForm.valid){
      alert("Valid Form")
  }
}

}
