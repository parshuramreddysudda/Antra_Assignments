import { Component, Injectable, OnInit, Output, output } from '@angular/core';
import { ProductService } from '../../services/product/product.service';
import { Product } from '../types/product';
import { CommonModule } from '@angular/common';
import { Router, RouterOutlet } from '@angular/router';
import { error } from 'node:console';
import { LoginService } from '../../services/login/login.service';
import { Store } from '@ngrx/store';
import { AppState } from '../../states/app.state';
import { addToCart } from '../../states/cart/cart.action';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule,RouterOutlet],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
@Injectable({
  providedIn: 'root'
})
export class ProductsComponent implements OnInit {

  constructor(private service:ProductService,
    private loginService:LoginService,
    private toast:NgToastService,
    private router:Router,
    private store:Store<AppState>
  ){
  }

  ngOnInit(){
    this.getAllProducts();
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
  }
  
  public products!: Product[];
  public errorMessage:string='';
  public isAdmin:boolean=true;
  
  addToCart(product:Product){
     console.log("Add to Product is ",product);
      this.store.dispatch(addToCart({product:product}));
      this.toast.success(product.name+" has been added from cart")
  }
  getAllProducts(){ 
    this.service.getAllProducts().subscribe({
      next: (data) => {
        this.products = data;
      },
      error: (error) => {
        if (error.status === 401) {
          // Redirect to the login page or any other page
          this.router.navigate(['/not-authorized']);
        }
        this.errorMessage = error.message;
        console.error("Error While Loading Products", error.s);
      },
      complete: () => {
        // This is optional and can be used if there's something to do after completion
        console.log("Products loading completed");
      }
    });
  }
    

}
