import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { TodolistComponent } from './Components/todolist/todolist.component';
import { ApiHttpHeadersInterceptor } from './Interceptors/api-http-headers.interceptor';
import { ApiPrefixInterceptor } from './Interceptors/api-prefix-interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    TodolistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ApiPrefixInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ApiHttpHeadersInterceptor, multi: true}
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
