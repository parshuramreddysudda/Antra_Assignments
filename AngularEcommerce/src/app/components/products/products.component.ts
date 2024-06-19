import { Component, Injectable, OnInit, Output, output } from '@angular/core';
import { ProductService } from '../../services/product/product.service';
import { Product } from '../types/product';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { error } from 'node:console';
import { LoginService } from '../../services/login/login.service';

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
    private loginService:LoginService
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
  
  addToCart(id:any){

  }
  getAllProducts(){
    this.service.getAllProducts().subscribe({
      next: (data) => {
        this.products = data;
      },
      error: (error) => {
        this.errorMessage = error.message;
        console.error("Error While Loading Products", error);
      },
      complete: () => {
        // This is optional and can be used if there's something to do after completion
        console.log("Products loading completed");
      }
    });
  }
    

}
