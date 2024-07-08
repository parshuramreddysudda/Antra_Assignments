import { createAction, props } from '@ngrx/store';

export const updateState = createAction(
  '[App] Update State',
  props<{ state: any }>()
);

export const loadState = createAction(
  '[App] Load State'
);
