import { createReducer, on } from '@ngrx/store';
import { Product } from '../../components/types/product';
import {
  addToCart,
  decrementProduct,
  emptyCart,
  incrementProduct,
  removeFromCart,
  updateProductQuantity,
} from './cart.action';

export interface CartState {
  products: Product[];
}

export const initialCartState: CartState = {
  products: [],
};

export const cartReducer = createReducer(
  initialCartState,
  on(addToCart, (state, { product }) => {
    console.log("Inside the store for AddToCart");
    const item = state.products.find((item)=>item.id===product.id);
    if(item){
      return{
        ...state,
        products:state.products.map((product) =>
          product.id === product.id ? { ...product, quantity: product.quantity + 1 } : product
        )
      };
    }
    product={...product,quantity:1}
    const updatedProduct = [...state.products, product];
    return {
      ...state,
      products: updatedProduct,
    };
  }),
  on(removeFromCart, (state, { productId }) => {
    const updatedProducts = state.products.filter(
      (product) => product.id != productId
    );
    return {
      ...state,
      products: updatedProducts,
    };
  }),
  on(incrementProduct, (state, { productId }) => {
    const updatedProducts = state.products.map((product) =>
      product.id === productId ? { ...product, quantity: product.quantity + 1 } : product
    );
    return {
      ...state,
      products: updatedProducts,
    };
  }),
  on(decrementProduct, (state, { productId }) => {
    const updatedProducts = state.products
      .map((product) => {
        if (product.id === productId) {
          if (product.quantity === 1) {
            return null;
          } else {
            return { ...product,quantity:product.quantity - 1};
          }
        }
        return product;
      })
      .filter((product):product is Product => product !== null);
    return {
      ...state,
      products: updatedProducts,
    };
  }),
  on(updateProductQuantity, (state, { productId,quantity }) => {
    const updatedProducts = state.products
      .map((product) => {
        if (product.id === productId) {
          if (quantity < 0) {
            quantity = 0;
          } else {
            return { ...product, quantity };
          }
        }
        return product;
      })
      .filter((product):product is Product => product !== null);
    return {
      ...state,
      products: updatedProducts,
    };
  }),

  on(emptyCart, (state) => {
    return {
      ...state,
      products: [],
    };
  })

);
