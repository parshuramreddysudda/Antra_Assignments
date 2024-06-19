import { createAction, props } from "@ngrx/store";
import { LoginResponse } from "../../components/types/login";

export const addLoginInfo = createAction(
  '[Login] Add Login Info',
  props<{ user: LoginResponse }>()
);

export const removeLoginInfo = createAction(
  '[Login] Remove Login Info'
);
