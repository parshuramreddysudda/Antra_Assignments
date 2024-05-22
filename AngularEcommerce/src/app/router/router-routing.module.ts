import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from '../components/products/products.component';
import { CustomersComponent } from '../components/customers/customers.component';
import { HomeComponent } from '../components/home/home.component';
import { ProductComponent } from '../components/products/product/product.component';
import { NotfoundComponent } from '../components/notfound/notfound.component';
import { LoginComponent } from './login/login.component';
import { CreateProductComponent } from '../components/products/create-product/create-product.component';
import { DeleteProductComponent } from '../components/products/delete-product/delete-product.component';
import { authGuardGuard } from '../guards/auth-guard.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'products',
    title:"Products",
    children: [
      {path:'',component:ProductsComponent,pathMatch:"full",canActivate:[authGuardGuard]},
      {path:'create',component:CreateProductComponent,pathMatch:"full"},
      {path:'delete',component:DeleteProductComponent,pathMatch:"full"},
      { path: ':id', component: ProductComponent,pathMatch:"full"},
    ],
  },
  { path: 'customers', component: CustomersComponent,title:"Customers" }, // not lazy loading
  { path: 'home', component: HomeComponent ,title:"Home"},
  {path:'',redirectTo:'home',pathMatch:'full'},
  { path: '**', component: NotfoundComponent,title:"404 - Not Found " },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RouterRoutingModule {}
