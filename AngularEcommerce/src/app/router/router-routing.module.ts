import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from '../components/products/products.component';
import { CustomersComponent } from '../components/customers/customers.component';
import { HomeComponent } from '../components/home/home.component';
import { ProductComponent } from '../components/products/product/product.component';
import { NotfoundComponent } from '../components/notfound/notfound.component';
import { CreateProductComponent } from '../components/products/create-product/create-product.component';
import { DeleteProductComponent } from '../components/products/delete-product/delete-product.component';
import { isAuthenticGuard } from '../guards/auth-guard.guard';
import { CartComponent } from '../components/cart/cart.component';
import { RoleGuard } from '../guards/rbac-auth/admin-auth.guard';
import { Roles } from '../components/types/Roles';
import { NotAuthorizedComponent } from '../components/not-authorized/not-authorized.component';
import { RoutesEnums } from '../components/types/Enums';
import { ServiceUnavailableComponent } from '../components/service-unavailable/service-unavailable.component';
import { OrdersComponent } from '../components/order/order.component';
import { OrderCreateComponent } from '../components/order-create/order-create.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'products',
    title: 'Products',
    children: [
      { path: '', component: ProductsComponent, pathMatch: 'full' },
      {
        path: 'create',
        component: CreateProductComponent,
        pathMatch: 'full',
        canActivate: [isAuthenticGuard, RoleGuard],
        data: { roles: [Roles.Admin,Roles.Manager] },
      },
      {
        path: 'delete',
        component: DeleteProductComponent,
        pathMatch: 'full',
        canActivate: [isAuthenticGuard, RoleGuard],
        data: { roles: [Roles.Admin] },
      },
      {
        path: ':id',
        component: ProductComponent,
        pathMatch: 'full',
        canActivate: [isAuthenticGuard, RoleGuard],
        data: { roles: [Roles.Admin,Roles.Manager] },
      },
    ],
  },
  { path: 'cart', component: CartComponent, title: 'Cart' },
  { path: 'orders', component: OrdersComponent, title: 'Cart',canActivate:[isAuthenticGuard]},
  { path: 'orders-create', component: OrderCreateComponent, title: 'Cart',canActivate:[isAuthenticGuard]},
  { path: 'customers', component: CustomersComponent, title: 'Customers' }, // not lazy loading
  { path: 'home', component: HomeComponent, title: 'Home' },
  { path:RoutesEnums.notAuthorized,component:NotAuthorizedComponent,title:"403 Forbidden"},
  { path:RoutesEnums.serviceUnavailable,component:ServiceUnavailableComponent,title:"403 Forbidden"},
  { path: '**', component: NotfoundComponent, title: '404 - Not Found ' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RouterRoutingModule {}
