import { Product } from "./product";

export interface Order {
    id: number;
    orderDate: string; // You can use Date type if you handle the conversion
    customerId: number;
    customerName: string;
    paymentMethod: string;
    paymentName: string;
    shippingMethod: string;
    shippingAddress: string;
    billAmount: number;
    orderStatus: string;
    orderDetails: OrderDetails[];
  }
  export interface OrderDetails {
    id: number;
    productId: number;
    product: Product;
    productPrice: number;
    quantity: number;
    price: number;
    discount: number;
  }

  export interface OrderDetailsRequest {
    productId: number;
    productPrice: number;
    quantity: number;
    price: number;
    discount: number;
  }
  
  export interface OrderRequest {
    customerId: number;
    orderDate: string;
    customerName: string;
    paymentMethod: string;
    paymentName: string;
    shippingMethod: string;
    shippingAddress: string;
    billAmount: number;
    orderStatus: string;
    orderDetails: OrderDetailsRequest[];
  }