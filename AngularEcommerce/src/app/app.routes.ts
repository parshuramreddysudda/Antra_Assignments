import { Routes } from '@angular/router';
import { ProductsComponent } from './components/products/products.component';
import { CustomersComponent } from './components/customers/customers.component';
import { HomeComponent } from './components/home/home.component';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { ProductComponent } from './components/products/product/product.component';

export const routes: Routes = [
    {path:"products",component:ProductsComponent},
    {path:"customers",component:CustomersComponent},
    {path:"home",component:HomeComponent},
    {path:"products/:id",component:ProductComponent},
    {path:"", redirectTo:"home",pathMatch: 'full'},
    {path:"**",component:NotfoundComponent}
];
