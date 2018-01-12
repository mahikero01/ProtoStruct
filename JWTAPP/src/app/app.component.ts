import { Component } from '@angular/core';
import { AppToken } from './apptoken';
import * as appService from './api.service';
import 'rxjs/add/operator/toPromise';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {
  title = 'app';
  appToken:AppToken[]=[];
  rawdata:any=[];
  constructor(private appService:appService.ApiService,private api1:appService.ApiService1){
    appService.getAll
     //appService.getAll('getSkills').subscribe(data=>{ this.rawdata=data.json(); console.log(this.rawdata)} );

    appService.getAll('myToken').map(res => this.appToken=<AppToken[]>res.json()).subscribe(data=>{console.log(data)});
    localStorage.setItem('apiToken', this.appToken.pop().Token);
    localStorage.setItem('authToken',this.appToken.pop().Token);
    appService.getAll('skills').subscribe(data=> {console.log(data)});
    appService.postData('skills',null).subscribe(data=> {console.log(data)});
  
  }




}
