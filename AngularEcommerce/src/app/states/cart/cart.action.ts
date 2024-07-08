import { createAction, props } from "@ngrx/store";
import { Product } from "../../components/types/product";

export const addToCart = createAction(
    '[AddToCart] Add Product to Cart',
    props<{product:Product}>()
);

export const removeFromCart = createAction(
    '[RemoveFromCart] Remove Product From Cart',
    props<{productId:Number}>()
);

export const incrementProduct = createAction(
    '[IncrementProduct] Increment Product From Cart',
    props<{productId:Number}>()
);

export const decrementProduct = createAction(
    '[DecrementProduct] Decrement Product From Cart',
    props<{productId:Number}>()
);

export const updateProductQuantity = createAction(
    '[Update Product Quantity] Update Product Quantity From Cart',
    props<{productId:Number,quantity:number}>()
);

export const emptyCart = createAction(
    '[EmptyCart] Remove All Product From Cart'
);