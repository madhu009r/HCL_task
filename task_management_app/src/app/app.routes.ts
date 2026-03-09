import { Routes } from '@angular/router';
import { ApiTest } from './component/api-test/api-test';
import { Home } from './component/home/home';
import { Register } from './component/register/register';
import { Login } from './component/login/login';

export const routes: Routes = [
    {path:'Home', component: Home},
    // /{path:'register', loadComponent: () => import('./component/register/register').then(m => m.Register)},
    {path:'register',component: Register},
    {path:'login', component: Login},
  { path: 'test', component: ApiTest }
];
