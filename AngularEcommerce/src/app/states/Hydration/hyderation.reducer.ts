import { ActionReducer, INIT, MetaReducer, UPDATE } from "@ngrx/store";
import { AppState } from "../app.state";
import { isPlatformBrowser } from '@angular/common';
import { Inject, PLATFORM_ID } from '@angular/core';

export const hydrationMetaReducer = (
  reducer: ActionReducer<AppState>
): ActionReducer<AppState> => {
  return (state, action) => {
    console.log(action.type);
    console.log("Platform Browser",isPlatformBrowser(PLATFORM_ID));
    
    if (isPlatformBrowser(PLATFORM_ID) && (action.type === INIT || action.type === UPDATE)) {
        console.log("I am in Hydration Reducer");
        
      const storageValue = localStorage.getItem("state");
      if (storageValue) {
        try {
          return JSON.parse(storageValue);
        } catch {
          localStorage.removeItem("state");
        }
      }
    }
    const nextState = reducer(state, action);
    if (!isPlatformBrowser(PLATFORM_ID)) {
      localStorage.setItem("state", JSON.stringify(nextState));
    }
    return nextState;
  };
};

export const metaReducers: MetaReducer[] = [
  hydrationMetaReducer
];
