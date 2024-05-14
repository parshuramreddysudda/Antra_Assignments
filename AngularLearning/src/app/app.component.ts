import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductComponent } from './components/product/product.component';
import { product } from './Models/product';
import { DepartmentComponent } from './components/department/department.component';
import { CustomerComponent } from './components/customer/customer.component';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,DepartmentComponent,AppComponent,CustomerComponent],
templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AngularLearning';
  head="Products List";
  productList:product[] = [{id:1,productName:"Chair",price:50,quantity:5},
  {id:2,productName:"Monitor",price:100,quantity:5},
  {id:3,productName:"Mouse",price:30,quantity:5}
  ];
  selectedProduct: string = '';
  departmentName:string="";
  deparmentCount:any="";
  receiveMethods(e:any){
  };

  bindDepartment(e:any){
    this.departmentName=e.target.value;
  }

  showCount(e:any){
    this.deparmentCount=e
  }
}


