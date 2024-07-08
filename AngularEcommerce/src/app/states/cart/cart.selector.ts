import { AppState } from "../app.state";


export const selectorCartState = (state:AppState)=>state.cart;
// export const selectorCartSize = (state:AppState)=>state.cart;

const selectCartState = (state:AppState)=>{
    return state?.cart?.products;
}

export const selectorCartSize = (state:AppState)=>{
    return state?.cart?.products.reduce((total,item)=>{
        return total+item.quantity
    },0);
}
