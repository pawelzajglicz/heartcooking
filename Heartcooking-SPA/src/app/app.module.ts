import { appRoutes } from './routes';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatMenuModule } from '@angular/material/menu';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { ProductComponent } from './product/product.component';
import { AuthService } from './services/auth.service';
import { UnderConstructionComponent } from './under-construction/under-construction.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      ProductComponent,
      UnderConstructionComponent,
      RegisterComponent,
      HomeComponent
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
     AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
