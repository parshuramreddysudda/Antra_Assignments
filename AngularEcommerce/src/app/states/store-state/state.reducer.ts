import { createReducer, on } from '@ngrx/store';
import { loadState, updateState } from './state.action';
export interface IAppState {
  data: any;
}

export const initialState: IAppState = {
  data: null
};

export const storeStateReducer = createReducer(
  initialState,
  on(updateState, (state) => {
    

    console.log("StoreState REducer Data is ",state);
    
    return {
        ...state
    }



  }),
  on(loadState, (state => {
    console.log("Called Load State");
    
    var savedState = sessionStorage.getItem('applicationState');
    if(savedState!=null)
        return {
            ...state,
            data:{...JSON.parse(savedState).user},
            userInfo:{...JSON.parse(savedState).user}
        };
    
    return state
  })
)
);



