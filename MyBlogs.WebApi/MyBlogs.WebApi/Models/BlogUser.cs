using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogs.WebApi.Models
{
    public class BlogUser
    {
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}