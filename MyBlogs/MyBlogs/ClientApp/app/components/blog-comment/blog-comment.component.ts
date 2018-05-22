import { Component, OnInit, Input } from '@angular/core';
import { Blogcomment } from '../../models/Blogcomment.model';

@Component({
  selector: 'blog-comment',
  templateUrl: './blog-comment.component.html',
  styleUrls: ['./blog-comment.component.css']
})
export class BlogCommentComponent implements OnInit {
@Input('blogId') blogId:string;

blogcomments:Blogcomment[] = [
  {CommentID:1, Comment:'Blog Comments', Date:'12/12/2014'},
  {CommentID:2, Comment:'Good Blog', Date:'02/01/2015'},
  {CommentID:3, Comment:'Perfect Blog', Date:'09/10/2017'},
];
    constructor() { this.blogId = ''; }

  ngOnInit() {
  }

}
