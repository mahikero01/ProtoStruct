import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ApiService,ApiService1 } from './api.service';

import { HttpModule,JsonpModule } from '@angular/http';
import { AppComponent } from './app.component';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,HttpModule
  ],
  providers: [ApiService,ApiService1],
  bootstrap: [AppComponent]
})
export class AppModule { }
