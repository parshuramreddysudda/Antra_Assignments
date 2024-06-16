import { LoginResponse } from "../../components/types/login";
import { createReducer, on } from "@ngrx/store";
import { addLoginInfo, removeLoginInfo } from "./user.action";

export interface LoginState{
  user:LoginResponse[]
}

export const initialLoginState:LoginState={
    user:[]
}


export const loginReducer = createReducer(
    initialLoginState,
    on(addLoginInfo, (state, { user }) => {
        const updatedUser = [...state.user, user];
        return {
            ...state,
            user: updatedUser
        };
    }),

    on(removeLoginInfo,(state)=>{
        return {
            ...state,
            user:[]
        }
    })
);
