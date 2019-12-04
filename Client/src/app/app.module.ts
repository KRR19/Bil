import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {AlertsModule} from 'angular-alert-module';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {
  MatFormFieldModule,
  MatInputModule,
  MatOptionModule,
  MatPaginatorModule,
  MatSelectModule,
  MatSliderModule,
  MatTableModule
} from '@angular/material';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { ProductComponent } from './product/product.component';
import { CategoryComponent } from './category/category.component';
import {HttpClient, HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    CategoryComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    AlertsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatInputModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatTableModule,
    ReactiveFormsModule,
    FormsModule,
    MatOptionModule,
    MatSelectModule
  ],

  providers: [HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule {
}
