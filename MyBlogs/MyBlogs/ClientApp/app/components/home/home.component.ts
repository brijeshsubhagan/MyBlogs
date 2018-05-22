import { Component, OnInit } from '@angular/core';
import { Blog } from '../../models/blog';
import { BlogCardComponent } from '../blog-card/blog-card.component';
import { BlogService } from '../../services/blogservice.service';
import { AppGlobals } from '../../app.global';
@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    providers: [BlogService, AppGlobals]
})
export class HomeComponent implements OnInit {
    blogs: Blog[] | null;
    showAdmin: boolean = false;
    constructor(private blogService: BlogService, private _globals: AppGlobals) { this.blogs = null;}

    ngOnInit() {
        this.getblogs();
        let userID = sessionStorage.getItem("UserID");
        let userName = sessionStorage.getItem("Username");
        let isAdmin = sessionStorage.getItem("isAdmin");
        if (isAdmin)
            this.showAdmin = true;
       
    }

    getblogs() {

        
        this.blogService.getblogs(this._globals.baseAPIUrl + 'api/BlogPosts/GetPosts').subscribe(
           data => this.blogs = data  
        )
     
    }  


}