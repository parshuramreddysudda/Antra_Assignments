import { Routes } from '@angular/router';
import { LoginComponent } from './router/login/login.component';
export const routes: Routes = [

{path:'',redirectTo:"login",pathMatch:"full"},
{ path: 'login', component: LoginComponent },
{path:'',loadChildren:()=>import('./router/router.module').then(m=>m.RouterModule)},
  
];
