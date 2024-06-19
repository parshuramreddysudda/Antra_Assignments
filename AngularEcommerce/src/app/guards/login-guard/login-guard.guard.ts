import { CanActivateFn, Router } from '@angular/router';
import { LoginService } from '../../services/login/login.service';
import { inject } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';

export const loginGuardGuard: CanActivateFn = (route, state) => {
  const loginService=inject(LoginService)
  const router=inject(Router)
  const toast= inject(NgToastService)

  if(loginService.userIsLoggedIn()){
    toast.info("User already Logged in ")
    router.navigate(['home'])
    return false;
  }
  return true;
};
