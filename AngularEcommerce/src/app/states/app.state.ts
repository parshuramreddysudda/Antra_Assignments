import { cartReducer, CartState } from './cart/cart/cart.reducer';
import { metaReducers } from './Hydration/hyderation.reducer';
import { ILoginState, loginReducer } from './user/user.reducer';

export interface AppState {
  user: ILoginState;
  cart: CartState;
}

export const appStoreConfig = {
  reducers: {
    user: loginReducer,
    // Ensure to add other reducers if needed, like cart
    cart: cartReducer
  },
//   metaReducers: metaReducers // Ensure this is a flat array
};
