import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/Rx';
import  { Observable } from 'rxjs/Observable'; 
@Injectable()
export class AppSettings {
    private _config: Object
    private _env: Object

    constructor(private http: Http) {
        
    }

    public simulate(){
        var obj;
        this.getJSON().subscribe(data => {
            obj=data;
            console.log(obj)
        }, error => console.log(error));
    }

    public getJSON(): Observable<any> {
        return this.http.get("src/app/environment.json")
            .map((res:any) => res.json());
    }
}