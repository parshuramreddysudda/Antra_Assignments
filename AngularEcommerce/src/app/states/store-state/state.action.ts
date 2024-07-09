import { createAction, props } from '@ngrx/store';
import { ILoginState } from '../user/user.reducer';
import { CartState } from '../cart/cart.reducer';

export const updateState = createAction(
  '[App] Update State',
  props<{ user: ILoginState, cart: CartState }>()
);

export const loadState = createAction('[App] Load State');
