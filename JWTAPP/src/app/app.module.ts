import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ApiService,ApiService1 } from './api.service';
import { AppSettings } from './app.settings';
import { HttpModule,JsonpModule } from '@angular/http';
import { AppComponent } from './app.component';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,HttpModule
  ],
  providers: [ApiService,ApiService1,AppSettings],
  bootstrap: [AppComponent]
})
export class AppModule { }
