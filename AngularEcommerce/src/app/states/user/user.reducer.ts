import { createReducer, on } from "@ngrx/store";
import { LoginResponse } from "../../components/types/login";
import { addLoginInfo, removeLoginInfo } from "./user.action";
import { loadState } from "../store-state/state.action";

export interface ILoginState {
  user: LoginResponse | null;
}
export const initialLoginState: ILoginState = {
  user: null
};
 
export const loginReducer = createReducer(
  initialLoginState,
  on(addLoginInfo, (state, { user }) => {
    console.log('Adding login info:', user); // Log the user object being added
    return {
      ...state,
      user: { ...user }
    };
  }),

  on(removeLoginInfo, (state) => {
    console.log('Removing login info'); // Log the removal of login info
    return {
      ...state,
      user: initialLoginState.user
    };
  }),
  on(loadState, (state) => {
    const savedState = sessionStorage.getItem('applicationState');
    if (savedState) {
      const parsedState = JSON.parse(savedState);
      return {
        ...state,
        user: parsedState.user ? { ...parsedState.user.user } : state.user
      };
    }
    return state;
  })
);

