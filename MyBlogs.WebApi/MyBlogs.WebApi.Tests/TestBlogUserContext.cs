using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogs.WebApi.Models;
using System.Data.Entity;

namespace MyBlogs.WebApi.Tests
{
    public class TestBlogUserContext:IBlogUser
    {
        public TestBlogUserContext()
        {
            this.tbBlogUsers = new TestUserDbSet();
        }

        public DbSet<tbBlogUser> tbBlogUsers { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(tbBlogUser item) { }
        public void Dispose() { }
    }
}
