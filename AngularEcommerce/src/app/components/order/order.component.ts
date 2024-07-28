import { Component, OnInit } from '@angular/core';
import { Order } from '../types/Orders';
import { OrderService } from '../../services/order/order.service';
import { selectUser } from '../../states/user/user.selector';
import { AppState } from '../../states/app.state';
import { Store } from '@ngrx/store';
import { catchError, map, Observable, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NgToastService } from 'ng-angular-popup';
import { error } from 'console';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CommonModule,],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [];
  customerId:number | undefined =0;

  constructor(private orderService: OrderService,
    private toast:NgToastService,
    private store:Store<AppState>
  ) { }

  ngOnInit(): void {
    this.store.select(selectUser).subscribe((user) => {
      this.customerId = user.user?.id;
      if (this.customerId) {
        this.orderService.getOrders(this.customerId).subscribe(
         (data:Order[])=>{
          this.orders=data
         },
         (error:any)=>{
            this.handleError(error);
         }
        );
      }
    });
  }

  private handleError(error: HttpErrorResponse) {
    // Handle the error
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    this.toast.danger(errorMessage)
    console.error(error);
  }

  deleteOrder(orderId:number){
    this.orderService.deleteOrder(orderId).subscribe(
      (data)=>{
      console.log("Delete request Done",data);
      this.orders=this.orders.filter((order)=>order.id!==orderId)
      this.toast.success("Order has been Deleted")
      },
      (error)=>{
        console.log("Failed ",error)
        this.toast.danger("Order Deletion Failed")
      }
  
  );
  }
}