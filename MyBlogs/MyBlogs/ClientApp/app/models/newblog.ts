export class Blog {
    BlogPostID: number;
    BlogPostTitle: string;
    BlogPostBody: string;
    BlogPostDate: Date;
    BlogPostByUserID: number;

    constructor() {
        this.BlogPostID = 0;
        this.BlogPostTitle = '';
        this.BlogPostBody = '';
        this.BlogPostDate = new Date();
        this.BlogPostByUserID =2;
    };
}