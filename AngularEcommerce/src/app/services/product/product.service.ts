import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../../components/types/product';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(environment.apiUrl+"/product/");
  }
  getProductById(id:number): Observable<Product> {
    return this.http.get<Product>(environment.apiUrl+"/product/GetByID?id="+id);
  }
  updateProduct(product:Product,id:number):Observable<Product>{
    console.log(product);
    
    return this.http.put<Product>(environment.apiUrl+"/Product?id="+id,product);
  }

}
