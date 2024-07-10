import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { loginGuardGuard } from './guards/login-guard/login-guard.guard';
import { NgModule } from '@angular/core';
export const routes: Routes = [

{path:'',redirectTo:"login",pathMatch:"full"},
{ path: 'login', component: LoginComponent,canActivate:[loginGuardGuard] },
{path:'',loadChildren:()=>import('./router/router.module').then(m=>m.RouterModule)},
];

@NgModule({
    imports: [RouterModule.forRoot(routes)], // Root level
    exports: [RouterModule],
  })

  export class AppRoutingModule{}