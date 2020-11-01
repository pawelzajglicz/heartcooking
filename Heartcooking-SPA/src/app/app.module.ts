import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatMenuModule } from '@angular/material/menu';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { ProductComponent } from './product/product.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { RecipesComponent } from './recipes/recipes.component';
import { RegisterComponent } from './register/register.component';
import { appRoutes } from './routes';
import { AuthService } from './services/auth.service';
import { EnvConfigService } from './services/env-config.service';
import { ErrorInterceptorProvider } from './services/error.interceptor';
import { UnderConstructionComponent } from './under-construction/under-construction.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      ProductComponent,
      UnderConstructionComponent,
      RecipesComponent,
      RegisterComponent,
      HomeComponent,
      ProductsListComponent
   ],
   imports: [
      BrowserAnimationsModule,
      BrowserModule,
      FormsModule,
      HttpClientModule,
      MatMenuModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
     AuthService,
     EnvConfigService,
     ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
