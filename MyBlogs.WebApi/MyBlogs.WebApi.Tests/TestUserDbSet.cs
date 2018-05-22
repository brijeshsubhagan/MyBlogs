using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogs.WebApi.Models;
namespace MyBlogs.WebApi.Tests
{
    class TestUserDbSet : TestDbSet<tbBlogUser>
    {
        public override tbBlogUser Find(params object[] keyValues)
        {
            return this.SingleOrDefault(tbBlogUser => tbBlogUser.BlogUserName == (string)keyValues.Single());
        }
    }
}
