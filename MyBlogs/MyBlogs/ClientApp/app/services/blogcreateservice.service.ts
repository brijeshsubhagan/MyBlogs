import { Injectable, Inject } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class BlogCreateService {
    //myAppUrl: string = "";

    constructor(private _http: Http) {
        //this.myAppUrl = "http://localhost:54803/";
    }
    saveblogpost(blogCreate,apiUrl) {

        var headers = new Headers();
        headers.append('Access-Control-Allow-Origin', '*');
        headers.append('Access-Control-Allow-Methods', 'POST, GET, OPTIONS, PUT');
        headers.append('Accept', 'application/json');
        headers.append('content-type', 'application/json');
        let options = new RequestOptions({ headers: headers });


        return this._http.post(apiUrl, blogCreate, options)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    errorHandler(error: Response) {
        console.log(error);

        return Observable.throw(error);


    }


}
