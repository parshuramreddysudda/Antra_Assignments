import { Routes } from '@angular/router';
import { LoginComponent } from './router/login/login.component';
import { authGuardGuard } from './guards/auth-guard.guard';
import { loginGuardGuard } from './guards/login-guard/login-guard.guard';
export const routes: Routes = [

{path:'',redirectTo:"login",pathMatch:"full"},
{ path: 'login', component: LoginComponent,canActivate:[loginGuardGuard] },
{path:'',loadChildren:()=>import('./router/router.module').then(m=>m.RouterModule)},
];

