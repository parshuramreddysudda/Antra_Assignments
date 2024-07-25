import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order, OrderRequest } from '../../components/types/Orders';
import { environment } from '../../../environments/environment.development';
import { AppState } from '../../states/app.state';
import { Store } from '@ngrx/store';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
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
  storeData :any;
  constructor(private http: HttpClient,
    private store:Store<AppState>
  ) { }

  getOrders(customerId:number|undefined): Observable<Order[]> {
    return this.http.get<Order[]>("http://localhost:5130/api/Orders/"+customerId);
  }
  finalOrders(orders:OrderRequest): Observable<OrderRequest> {
    console.log("Order Information is ",orders);
    
    return this.http.post<OrderRequest>("http://localhost:5130/api/Orders",orders);
  }

  public formatOrder(){

    this.store.subscribe((data)=>{
      this.storeData=data
    })
    this.order.customerId=this.storeData.user.user.id;
    this.order.customerName=this.storeData.user.user.fullName;
    console.log("Store details is ",this.storeData);
    console.log("Store details is ",this.order);
  }
}
