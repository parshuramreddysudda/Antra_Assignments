import { createAction, props } from "@ngrx/store";
import { LoginResponse } from "../../components/types/login";

export const addLoginInfo = createAction('[Login Component] AddLoginInfo',props<{user:LoginResponse}>());
export const removeLoginInfo = createAction('[Login Component] RemoveLoginInfo');
