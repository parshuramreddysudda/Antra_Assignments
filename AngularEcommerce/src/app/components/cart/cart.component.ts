import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
  cartItems = [
   // { id: 1, name: 'Item 1', description: 'Description for item 1', price: 29.99, quantity: 1, image: 'https://via.placeholder.com/150' },
   // { id: 2, name: 'Item 2', description: 'Description for item 2', price: 49.99, quantity: 1, image: 'https://via.placeholder.com/150' },
    { id: 3, name: 'Item 3', description: 'Description for item 3', price: 19.99, quantity: 1, image: 'https://via.placeholder.com/150' }
  ];

  get cartSubtotal() {
    return this.cartItems.reduce((sum, item) => sum + item.price * item.quantity, 0);
  }

  get cartTax() {
    return this.cartSubtotal * 0.28; // assuming a tax rate of 10%
  }

  get cartTotal() {
    return this.cartSubtotal + this.cartTax;
  }

  removeFromCart(item:any) {
    this.cartItems = this.cartItems.filter(cartItem => cartItem.id !== item.id);
  }

  checkout() {
    // Implement checkout logic
    alert('Proceeding to checkout');
  }
}