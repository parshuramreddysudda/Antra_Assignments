import { createReducer, on } from "@ngrx/store";
import { LoginResponse } from "../../components/types/login";
import { addLoginInfo, removeLoginInfo } from "./user.action";

export interface ILoginState {
  user: LoginResponse;
}

export const initialLoginState: ILoginState = {
  user: {
    id: 0,
    fullName: "",
    email: "",
    gender: "",
    phone: "",
    profilePic: "",
    role: "",
    userId: "",
    token: "",
    claims: [],
  }
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
  })
);
