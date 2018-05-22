import { Injectable, Inject } from '@angular/core';
import { Http, Response, RequestOptions, Headers, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/toPromise';
import { AppGlobals } from '../app.global'

@Injectable()
export class BlogUserService {
    //myAppUrl: string = "";

    constructor(private _http: Http) {
        ////this.myAppUrl = "http://localhost:54803/";    
    }  
    saveblogUser(blogUser,apiUrl) {

        var headers = new Headers();
        headers.append('Access-Control-Allow-Origin', '*');
        headers.append('Access-Control-Allow-Methods', 'POST, GET, OPTIONS, PUT');
        headers.append('Accept', 'application/json');
        headers.append('content-type', 'application/json');
        let options = new RequestOptions({headers: headers});

        return this._http.post(apiUrl, blogUser, options)              
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    checkLoginUser(blogUser, apiUrl) {

        var headers = new Headers();
        headers.append('Access-Control-Allow-Origin', '*');
        headers.append('Access-Control-Allow-Methods', 'POST, GET, OPTIONS, PUT');
        headers.append('Accept', 'application/json');
        headers.append('content-type', 'application/json');
        let options = new RequestOptions({ headers: headers });

        return this._http.post(apiUrl, blogUser, options)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

     getUserDetails(userName: string, password: string, apiUrl) {
        //alert(apiUrl + userName + password);
        return this._http.get(apiUrl + userName +"/"+ password)
            .map((response: Response) => response.json()).toPromise()
            .catch(this.errorHandler)
    }
    deleteUserById(id: number, apiUrl) {


        var headers = new Headers();
        headers.append('Access-Control-Allow-Origin', '*');
        headers.append('Access-Control-Allow-Methods', 'POST, GET, OPTIONS, PUT');
        headers.append('Accept', 'application/json');
        headers.append('content-type', 'application/json');
        let options = new RequestOptions({ headers: headers });
        //alert(this.myAppUrl + "api/BlogPosts/DeletetbBlogPost/" + id);
        return this._http.delete(apiUrl + id, options)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

     updateAdminUserById(id: number, apiUrl) {

        var headers = new Headers();
        headers.append('Access-Control-Allow-Origin', '*');
        headers.append('Access-Control-Allow-Methods', 'POST, GET, OPTIONS, PUT');
        headers.append('Accept', 'application/json');
        headers.append('content-type', 'application/json');
        let options = new RequestOptions({ headers: headers });
        //alert(this.myAppUrl + "api/BlogPosts/DeletetbBlogPost/" + id);
        return this._http.put(apiUrl + id, options)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }
    errorHandler(error: Response) {
         console.log(error);
  
        return Observable.throw(error);

        
    }  


}
