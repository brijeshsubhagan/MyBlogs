import { Injectable, Inject } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { AppUser } from '../models/app-user';
@Injectable()
export class AdminService {
    myAppUrl: string = "";
    selecteduser: AppUser | undefined;
    appUserList: AppUser[] | undefined;

    constructor(private _http: Http) {
        //this.myAppUrl = "http://localhost:54803/";
        //this.blogList = null;
    }
    getAllUsers(apiUrl) {
        try {
            return this._http.get(apiUrl)
                .map((response: Response) => response.json())
                .catch(this.errorHandler);
        }
        catch (Error) {
            alert(Error.message);
        }

    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }


}
