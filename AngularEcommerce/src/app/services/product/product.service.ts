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
    return this.http.get<Product[]>(environment.apiUrl+"/Products/");
  }
  getProductById(id:number): Observable<Product> {
    return this.http.get<Product>(environment.apiUrl+"/Products/"+id);
  }
  updateProduct(product:Product,id:number):Observable<Product>{
    return this.http.put<Product>(environment.apiUrl+"/Products/"+id,product);
  }
  createProduct(product:Product):Observable<Product>{
    return this.http.put<Product>(environment.apiUrl+"/Products",product);
  }
}
