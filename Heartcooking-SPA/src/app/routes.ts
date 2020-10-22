import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { RegisterComponent } from './register/register.component';


export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'products', component: ProductsListComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
