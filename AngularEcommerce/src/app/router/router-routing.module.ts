import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from '../components/products/products.component';
import { CustomersComponent } from '../components/customers/customers.component';
import { HomeComponent } from '../components/home/home.component';
import { ProductComponent } from '../components/products/product/product.component';
import { NotfoundComponent } from '../components/notfound/notfound.component';
import { LoginComponent } from './login/login.component';
import path from 'path';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'products',
    component: ProductsComponent,
    children: [{ path: ':id', component: ProductComponent }],
  },
  { path: 'customers', component: CustomersComponent },
  { path: 'home', component: HomeComponent },
  { path: 'products/:id', component: ProductComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', component: NotfoundComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RouterRoutingModule {}
