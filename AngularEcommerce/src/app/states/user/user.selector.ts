import { createSelector } from "@ngrx/store";
import { AppState } from "../app.state";
import { ILoginState } from "./user.reducer";

export const selectorLoginState = (state:AppState) =>state.user;

// export const select

// user.selector.ts
const selectLoginState = (state: AppState) => {
    console.log('Current AppState:', state); // Check AppState structure
    return state?.user;
  };
  
  export const selectFullName = createSelector(
    selectLoginState,
    (state: ILoginState) => state?.user // Use null coalescing operator to handle potential undefined
  );
  
  export const selectUser = createSelector(
    selectLoginState,
    (user) => user // Selector to directly access 'user'
  ); 