import { CanActivateFn, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from '../../states/app.state';
import { ILoginState } from '../../states/user/user.reducer';
import { inject } from '@angular/core';
import { selectUserRole } from '../../states/user/user.selector';
import { map } from 'rxjs';
import { Roles } from '../../components/types/Roles';
import { NgToastService } from 'ng-angular-popup';

export const RouteGuard: CanActivateFn = (route, state) => {
  const store = inject(Store<ILoginState>);
  const toast = inject(NgToastService);
  const router = inject(Router)
  const allowedRoles = route.data['roles'] as Array<String>;

  return store.select(selectUserRole).pipe(
    map((userRole) => {
      console.log(' In Route Guard Role is ', userRole);
      if (allowedRoles.includes(userRole || Roles.Employee)) {
        console.log(userRole, ' is Role Allowed');
        return true;
      } else {
        console.log(userRole, ' is Not allowed');
        toast.danger("You are not Authorized")
        router.navigate(['/not-authorized']);
        return false;
      }
    })
  );
};
