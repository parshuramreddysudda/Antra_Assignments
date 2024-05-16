import { Component, Injectable } from '@angular/core';
import { ProductService } from '../../services/product/product.service';
import { Product } from '../types/product';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
@Injectable({
  providedIn: 'root'
})
export class ProductsComponent {

  constructor(private service:ProductService){}

  ngOnInit(){
    this.getAllProducts();
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
  }
  
  public products!: Product[];
  
  getAllProducts(){
  this.service.getAllProducts().subscribe((data)=>{
    this.products=data
})
  }

}
