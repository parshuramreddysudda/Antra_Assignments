import { Routes } from '@angular/router';
export const routes: Routes = [

{path:'app',loadChildren:()=>import('./router/router.module').then(m=>m.RouterModule)},
{path:'',redirectTo:"app/home",pathMatch:"full"}
  
];
