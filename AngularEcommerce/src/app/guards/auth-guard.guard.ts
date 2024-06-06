import { CanActivateChildFn } from '@angular/router';

export const authGuardGuard: CanActivateChildFn = (childRoute, state) => {
  return true;
};
