import { Routes } from '@angular/router';
import { ProductsComponent } from './components/products/products.component';
import { CustomersComponent } from './components/customers/customers.component';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [
    {path:"products",component:ProductsComponent},
    {path:"customer",component:CustomersComponent},
    {path:"home",component:HomeComponent}

];
