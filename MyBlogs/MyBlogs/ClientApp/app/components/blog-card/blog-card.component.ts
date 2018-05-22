import { Component, OnInit, Input } from '@angular/core';
import { Blog } from '../../models/blog';
import { Router, ActivatedRoute } from '@angular/router';
import { BlogService } from '../../services/blogservice.service'
import { HomeComponent } from '../home/home.component';
import { AppGlobals } from '../../app.global'
@Component({
    selector: 'blog-card',
    templateUrl: './blog-card.component.html',
    styleUrls: ['./blog-card.component.css'],
    providers: [BlogService, AppGlobals]
})
export class BlogCardComponent implements OnInit {
    @Input('blog') blog: Blog;
    errorMessage: any
    showAdmin: boolean = false;
    constructor(private _router: Router, private _blogService: BlogService,
        private _homeComponent: HomeComponent, private _globals: AppGlobals) { this.blog = new Blog(); }

    ngOnInit() {
       let isAdmin = sessionStorage.getItem("isAdmin");
        if (isAdmin)
            this.showAdmin = true;
    }

    deleteBlog() {
        /*  var string1 = JSON.stringify(this.blogCreateForm.value);
          alert(string1);*/
        var ans = confirm("Do you want to delete blog with Id: " + this.blog.id);
        if (ans) {
            
            this._blogService.deleteBlogById(this.blog.id, this._globals.baseAPIUrl + "api/BlogPosts/DeletetbBlogPost/")
                .subscribe((data) => {
                    this._homeComponent.getblogs();
                    this._router.navigate(['/home']);
                }, error => this.errorMessage = error)
        }
    }

}