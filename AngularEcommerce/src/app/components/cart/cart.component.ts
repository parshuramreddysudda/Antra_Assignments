import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AppState } from '../../states/app.state';
import { Product } from '../types/product';
import { selectorCartState } from '../../states/cart/cart/cart.selector';
import { decrementProduct, incrementProduct, removeFromCart, updateProductQuantity } from '../../states/cart/cart/cart.action';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import {faTrashAlt } from '@fortawesome/free-regular-svg-icons';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule,FormsModule,FontAwesomeModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit{

  cartItems:Product[]=[];
  faTrashCan=faTrashAlt
  constructor(
    private store:Store<AppState>,
    private toast:NgToastService,
  ) {}

  ngOnInit(): void {
      this.store.select(selectorCartState).subscribe((products)=>{
        console.log("Products are ",products);
        this.cartItems=products.products;
        
      })
  }

 
  increaseQuantity(item:Product) {
    this.store.dispatch(incrementProduct({ productId: item.id }));
  }

  decreaseQuantity(item:Product) {
    if (item.quantity > 1) {
      this.store.dispatch(decrementProduct({ productId: item.id }));
    }else{
      this.removeFromCart(item);
    }
  }


    changeInput(event: Event,item:Product) {
    const inputElement = event.target as HTMLInputElement;
    const newQuantity = parseInt(inputElement.value, 10);
    console.log("Called on Change Input");
    
    // Ensure the quantity is valid
    if (newQuantity > 0 && newQuantity !== item.quantity && newQuantity < item.qty) {
      // Update the quantity directly in the store (or handle it accordingly)
      // Example: Dispatch an action to set the exact quantity
      this.store.dispatch(updateProductQuantity({ productId: item.id, quantity: newQuantity }));
    }else if(newQuantity>item.qty){
      this.toast.warning("Maximum "+item.qty+" is allowed for this product");
      this.store.dispatch(updateProductQuantity({productId:item.id,quantity:item.qty}))
    } 
    else {
      this.toast.warning("Minimum 1 product must be contained")
      this.store.dispatch(updateProductQuantity({productId:item.id,quantity:1}))
      // Reset the input value if invalid
      // inputElement.value = this.item.userQuantity.toString();
    }
  }

  
  get cartSubtotal() {
    return this.cartItems.reduce((sum, item) => sum + item.price * item.quantity, 0);
  }

  get cartTax() {
    return this.cartSubtotal * 0.28; // assuming a tax rate of 10%
  }

  get cartTotal() {
    return this.cartSubtotal + this.cartTax;
  }

  removeFromCart(item:Product) {
    if(confirm("Do you want to remove "+item.name+" from cart")){
        this.store.dispatch(removeFromCart({productId:item.id}));
        this.toast.danger(item.name+" has been deleted from cart")
    }
  }

  checkout() {
    // Implement checkout logic
    alert('Proceeding to checkout');
  }
}