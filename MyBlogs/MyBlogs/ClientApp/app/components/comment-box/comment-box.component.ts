import { Component, OnInit, Input } from '@angular/core';
import { Blogcomment } from '../../models/Blogcomment.model';

@Component({
  selector: 'comment-box',
  templateUrl: './comment-box.component.html',
  styleUrls: ['./comment-box.component.css']
})
export class CommentBoxComponent implements OnInit {
    @Input('blogComment') blogComment: Blogcomment | undefined;
    constructor() {  }

  ngOnInit() {
  }

}
