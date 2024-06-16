import { createSelector } from "@ngrx/store";
import { AppState } from "../app.state";
import { LoginState } from "./user.reducer";

export const selectorLoginState = (state:AppState) =>state.user;

export const selectUser = createSelector(
    selectorLoginState,
    (state:LoginState)=>state.user
)
// export const select