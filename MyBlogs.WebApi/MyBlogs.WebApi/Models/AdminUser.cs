using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogs.WebApi.Models
{
    public class AdminUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public string isadmin { get; set; }

        
    }
}