import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { ProductComponent } from './product/product.component';
import { UnderConstructionComponent } from './under-construction/under-construction.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      ProductComponent,
      UnderConstructionComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
