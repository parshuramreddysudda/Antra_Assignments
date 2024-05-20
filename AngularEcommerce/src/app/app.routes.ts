import { Routes } from '@angular/router';
import { ProductsComponent } from './components/products/products.component';
import { CustomersComponent } from './components/customers/customers.component';
import { HomeComponent } from './components/home/home.component';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { ProductComponent } from './components/products/product/product.component';

export const routes: Routes = [

{path:'app',loadChildren:()=>import('./router/router.module').then(m=>m.RouterModule)},
  
];
