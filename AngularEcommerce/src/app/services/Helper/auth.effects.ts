import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { of } from 'rxjs';
import { map, mergeMap } from 'rxjs/operators';
import { removeLoginInfo } from '../../states/user/user.action';
import { emptyCart } from '../../states/cart/cart/cart.action';

@Injectable()
export class AuthEffects {

  constructor(
    private actions$: Actions,
    private store: Store
  ) {}

  removeLoginInfo$ = createEffect(() =>
    this.actions$.pipe(
      ofType(removeLoginInfo),
      mergeMap(() => {
        console.log('Dispatching emptyCart action'); // Log the dispatch of emptyCart action
        return of(emptyCart());
      })
    )
  );
}
