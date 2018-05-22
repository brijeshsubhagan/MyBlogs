import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BlogCreateService } from '../../services/blogcreateservice.service'; 
import { AppGlobals } from '../../app.global';
@Component({
    selector: 'blog-create',
    templateUrl: './blog-create.component.html',
    styleUrls: ['./blog-create.component.css'], providers: [BlogCreateService, AppGlobals]
})
export class BlogCreateComponent implements OnInit {
    blogCreateForm: FormGroup;
    errorMessage:any
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _blogUserService: BlogCreateService, private _router: Router, private _globals: AppGlobals) {
        this.blogCreateForm = this._fb.group({
            BlogPostTitle: ['', [Validators.required]],
            BlogPostBody: ['', [Validators.required]],
            BlogPostByUserID: 2,
            BlogPostDate: new Date()
        })

    }

    ngOnInit() {
    }
    save() {
      /*  var string1 = JSON.stringify(this.blogCreateForm.value);
        alert(string1);*/
       
        this._blogUserService.saveblogpost(this.blogCreateForm.value, this._globals.baseAPIUrl + 'api/BlogPosts')
            .subscribe((data) => {
                this._router.navigate(['/home']);




            }, error => this.errorMessage = error)
    }
}
