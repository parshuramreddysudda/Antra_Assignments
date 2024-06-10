import { inject } from '@angular/core';
import { CanActivateChildFn } from '@angular/router';
import { LoginService } from '../services/login/login.service';
import { NgToastComponent, NgToastService } from 'ng-angular-popup';

export const authGuardGuard: CanActivateChildFn = (childRoute, state) => {
  const loginService = inject(LoginService)
  const toast=inject(NgToastService)
  if(loginService.userIsLoggedIn()){
    return true
  }else{
    toast.danger("Unauthorized, Please Login in back");
    return false;
  }
};


