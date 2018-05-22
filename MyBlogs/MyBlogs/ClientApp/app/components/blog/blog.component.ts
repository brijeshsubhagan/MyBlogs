import { Component, OnInit, Input } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms'; 
import { Blog } from '../../models/blog';
import { Router, ActivatedRoute } from '@angular/router';
import { BlogService } from '../../services/blogservice.service'
import { AppGlobals } from '../../app.global'
@Component({
  selector: 'blog',
    templateUrl: './blog.component.html',
    styleUrls: ['./blog.component.css'], providers: [BlogService, AppGlobals]
})
export class BlogComponent implements OnInit {
    blog: Blog | undefined;
   // id: number;
    errorMessage: any;
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _blogService: BlogService, private _globals: AppGlobals) {
        
 }

    ngOnInit() {

        this._blogService.getBlogById(this._avRoute.snapshot.params["id"], this._globals.baseAPIUrl+ "api/BlogPosts/GetPostsByID/").subscribe(
            data => this.blog = data);

  }

}
