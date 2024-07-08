import { createReducer, on } from '@ngrx/store';
import { loadState, updateState } from './state.action';
export interface AppState {
  data: any;
}

export const initialState: AppState = {
  data: null
};

export const storeStateReducer = createReducer(
  initialState,
  on(updateState, (state, { state: data }) => ({ ...state, data })),
  on(loadState, state => {
    const savedState = sessionStorage.getItem('applicationState');
    return savedState ? JSON.parse(savedState) : state;
  })
);



