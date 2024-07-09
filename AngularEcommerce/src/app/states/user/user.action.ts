import { createAction, props } from "@ngrx/store";
import { LoginResponse } from "../../components/types/login";
import { ILoginState } from "./user.reducer";
import { CartState } from "../cart/cart.reducer";

export const addLoginInfo = createAction(
  '[Login] Add Login Info',
  props<{ user: LoginResponse }>()
);

export const removeLoginInfo = createAction(
  '[Login] Remove Login Info'
);
 
export const updateState = createAction(
  '[App] Update State',
  props<{ user: ILoginState, cart: CartState }>()
);