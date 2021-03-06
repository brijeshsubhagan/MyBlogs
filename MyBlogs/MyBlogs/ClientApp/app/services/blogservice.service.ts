﻿import { Injectable, Inject } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw'; 

import { Blog } from '../models/blog';
@Injectable()
export class BlogService {
   // myAppUrl: string = "";
    selectedEmployee: Blog|undefined;
    blogList: Blog[]|undefined;

    constructor(private _http: Http) {
        //this.myAppUrl = "http://localhost:54803/";
        //this.blogList = null;
        
    }
    getblogs(apiUrl) {
        return this._http.get(apiUrl)
        .map((response: Response) => response.json())
        .catch(this.errorHandler);
        
    }  

    getBlogById(id: number,apiUrl) {
        //alert(this.myAppUrl + "api/BlogPosts/GetPostsByID/" + id);
        return this._http.get(apiUrl + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

        deleteBlogById(id: number,apiUrl) {
            //alert(this.myAppUrl + "api/BlogPosts/DeletetbBlogPost/" + id);
            return this._http.delete(apiUrl + id)
                .map((response: Response) => response.json())
                .catch(this.errorHandler)


           
    }  


    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }


}