//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBlogs.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbBlogComment
    {
        public int BlogCommentID { get; set; }
        public int BlogCommentParentID { get; set; }
        public int BlogPostID { get; set; }
        public string BlogComment { get; set; }
        public int BlogCommentByUserID { get; set; }
        public System.DateTime BlogCommentDate { get; set; }
    
        public virtual tbBlogPost tbBlogPost { get; set; }
        public virtual tbBlogUser tbBlogUser { get; set; }
    }
}
