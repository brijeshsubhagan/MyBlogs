using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogs.WebApi.Models
{
    public class Blogs
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string date { get; set; }
        public string username { get; set; }
      
    }
}