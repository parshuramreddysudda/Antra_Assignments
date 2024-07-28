import { Component, OnInit } from '@angular/core';
import { Order, OrderRequest } from '../types/Orders';
import { OrderService } from '../../services/order/order.service';
import { AsyncPipe, CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { OrderStatus, PaymentMethod, ShippingMethod } from '../types/Enums';
import { AppState } from '../../states/app.state';
import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { emptyCart, removeFromCart } from '../../states/cart/cart.action';

@Component({
  selector: 'app-order-create',
  standalone: true,
  imports: [CommonModule,FormsModule,AsyncPipe],
  templateUrl: './order-create.component.html',
  styleUrl: './order-create.component.css'
})
export class OrderCreateComponent implements OnInit {
  /**
   *
   */
  constructor(
    private orderService:OrderService,
    private router:Router,
    private toast:NgToastService,
    private store:Store<AppState>
  ) {
  }

  cart:any;
  user:any;
  ngOnInit(): void {
    this.orderService.formatOrder();
    this.store.subscribe((data)=>{
      this.cart=data.cart
      this.user=data.user.user
    })
  }


  get totalItems(): number {
    return this.cart.products.reduce((acc: any, product: { quantity: any; }) => acc + product.quantity, 0);
  }

  get totalAmount(): number {
    return this.cart.products.reduce((acc: number, product: { price: number; quantity: number; }) => acc + (product.price * product.quantity), 0);
  }

  order: OrderRequest = {
    customerId: 0,
    orderDate: '',
    customerName: '',
    paymentMethod: '',
    paymentName: '',
    shippingMethod: '',
    shippingAddress: '',
    billAmount: 0,
    orderStatus: '',
    orderDetails: []
  };

  paymentMethods = [PaymentMethod.BankTransfer, PaymentMethod.CashOnDelivery, PaymentMethod.CreditCard, PaymentMethod.PayPal];
  shippingMethods = [ShippingMethod.Standard, ShippingMethod.Express, ShippingMethod.Overnight, ShippingMethod.Pickup];
  orderStatuses = [OrderStatus.Pending, OrderStatus.Processing, OrderStatus.Shipped, OrderStatus.Delivered, OrderStatus.Canceled];


  selectedPaymentMethod: PaymentMethod = PaymentMethod.CreditCard;
  selectedShippingMethod: ShippingMethod = ShippingMethod.Standard;
  selectedOrderStatus: OrderStatus = OrderStatus.Pending;

  addDetail() {
    this.order.orderDetails.push({
      productId: 0,
      productPrice: 0,
      quantity: 0,
      price: 0,
      discount: 0
    });
  }

  
  removeDetail(index: number) {
    this.order.orderDetails.splice(index, 1);
  }

  submitOrder() {
    const order = {
      customerId: this.user.id,
      orderDate: new Date().toISOString(),
      customerName: this.user.fullName,
      paymentMethod: this.selectedPaymentMethod,
      paymentName: this.user.fullName,
      shippingMethod: this.selectedShippingMethod,
      shippingAddress: 'User Address', // Replace with actual user address
      billAmount: this.cart.products.reduce((sum: number, product: { price: number; quantity: number; }) => sum + (product.price * product.quantity), 0),
      orderStatus: this.selectedOrderStatus,
      orderDetails: this.cart.products.map((product: { id: any; price: number; quantity: number; }) => ({
        productId: product.id,
        productPrice: product.price,
        quantity: product.quantity,
        price: product.price * product.quantity,
        discount: 0 // Replace with actual discount logic if any
      }))
    };

    console.log("Before Order ",order);
    

    this.orderService.finalOrders(order).subscribe({
      next: (data) => {
        console.log('Inserted the Order', data);
        this.store.dispatch(emptyCart());
        this.toast.success("Order Placed Successfully")
        this.router.navigateByUrl("/orders")

      },
      error: (error) => {
        console.error('Something went wrong', error);
      }
    }
  )
    console.log('Order Submitted', order);
  }
    // Add your logic to send the order data to your backend
  }