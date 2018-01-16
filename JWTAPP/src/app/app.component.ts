import { Component } from '@angular/core';
import { AppToken } from './apptoken';
import * as appService from './api.service';
import { AppSettings } from './app.settings';
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
  constructor(private appService:appService.ApiService,
    private appsettings : AppSettings,
    private api1:appService.ApiService1){
  
     //appService.getAll('getSkills').subscribe(data=>{ this.rawdata=data.json(); console.log(this.rawdata)} );

   
    
    //this.simulate();
    this.getJsonFile();
  }

  getJsonFile(){
    this.appsettings.simulate();
  }

  public async simulate(){
    await this.appService.getAll('myToken').toPromise().then(
      res=>{ this.appToken=<AppToken[]>res.json();
      console.log(this.appToken.length);
    });
    await localStorage.setItem('apiToken', this.appToken.find(x=>x.tokenName=='ApiToken').token);
    await localStorage.setItem('authToken', this.appToken.find(x=>x.tokenName=='AuthToken').token);
    await this.api1.getAll('skills').subscribe(data=> {console.log(data)});
    await this.api1.postData('skills',null).subscribe(data=> {console.log(data)});
  }




}
