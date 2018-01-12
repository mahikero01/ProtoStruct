import { Injectable } from '@angular/core';
import { Headers, Http, URLSearchParams, Jsonp } from '@angular/http';
import 'rxjs/Rx';

@Injectable()
export class ApiService {
    // private headers = new Headers({'Content-Type': 'application/json'});
    private headers = new Headers({'Content-Type': 'application/json',
        "authorization" : "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibWFoaWtlcm8iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA5LzA5L2lkZW50aXR5L2NsYWltcy9hY3RvciI6IkNvY29NIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE1MTU3MDMwNDMsImlzcyI6Imh0dHA6Ly9teWNvZGVjYW1wLm9yZiIsImF1ZCI6Imh0dHA6Ly9teWNvZGVjYW1wLm9yZiJ9.HvChNnrGtnT2TSff1AbT-60hlP9mT7xYCzfNkNdGGPs"});
    private apiUrl = '';

    constructor(private http:Http){

    }

    public  CURRENT_URL = "http://localhost:52292/api/"

    public  GETAPIURL(controller:string):string{
        return this.CURRENT_URL+controller;
    }

    // getAll(){
    //     return this.http.get("http://mdsitools.com/projectworkplace/api/leaders").retry();
    // }
    public getAll(controller:string) {  
        this.apiUrl=this.GETAPIURL(controller);
        return this.http
            .get(this.apiUrl, {headers: this.headers})
    }

    public getOne(controller:string,id:string){
        this.apiUrl=this.GETAPIURL(controller);
        const url = `${this.apiUrl}/${id}`;
        return this.http
            .get(url, {headers: this.headers})
    }  

    public postData(controller:string,data:any){
        this.apiUrl=this.GETAPIURL(controller);
        return this.http
          .post(this.apiUrl, JSON.stringify(data), {headers: this.headers})
         
    }

    public putData(controller:string,data:any,id:string){
        this.apiUrl=this.GETAPIURL(controller);
        const url = `${this.apiUrl}/${id}`;
        return this.http
            .put(url, JSON.stringify(data), {headers: this.headers})
           
    }

    public deleteData(controller:string,id:string){
        this.apiUrl=this.GETAPIURL(controller);
        const url = `${this.apiUrl}/${id}`;
        return this.http
            .delete(url, {headers: this.headers})
           
    }
}


@Injectable()
export class ApiService1 {
    // private headers = new Headers({'Content-Type': 'application/json'});
    private headers = new Headers({'Content-Type': 'application/json'});
    private apiUrl = '';

    constructor(private http:Http){

    }

    public  CURRENT_URL = "http://localhost:52292/api/"

    public  GETAPIURL(controller:string):string{
        return this.CURRENT_URL+controller;
    }

    // getAll(){
    //     return this.http.get("http://mdsitools.com/projectworkplace/api/leaders").retry();
    // }
    public getAll(controller:string) {  
        this.apiUrl=this.GETAPIURL(controller);
        console.log(localStorage.getItem('authToken'));
        this.headers.append('authentication','Bearer '+localStorage.getItem('authToken'));
        return this.http
            .get(this.apiUrl, {headers: this.headers})
    }

    public getOne(controller:string,id:string){
        this.apiUrl=this.GETAPIURL(controller);
        const url = `${this.apiUrl}/${id}`;
        return this.http
            .get(url, {headers: this.headers})
    }  

    public postData(controller:string,data:any){
        console.log(localStorage.getItem('authToken'));
        this.apiUrl=this.GETAPIURL(controller);
        this.headers.append('authentication','Bearer '+localStorage.getItem('authToken'));
        return this.http
          .post(this.apiUrl, JSON.stringify(data), {headers: this.headers})
         
    }

    public putData(controller:string,data:any,id:string){
        this.apiUrl=this.GETAPIURL(controller);
        const url = `${this.apiUrl}/${id}`;
        return this.http
            .put(url, JSON.stringify(data), {headers: this.headers})
           
    }

    public deleteData(controller:string,id:string){
        this.apiUrl=this.GETAPIURL(controller);
        const url = `${this.apiUrl}/${id}`;
        return this.http
            .delete(url, {headers: this.headers})
           
    }
}

