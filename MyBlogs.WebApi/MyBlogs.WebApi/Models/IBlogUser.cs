using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogs.WebApi.Models
{
    public interface IBlogUser:IDisposable
    {
        DbSet<tbBlogUser> tbBlogUsers { get; }
        int SaveChanges();
        void MarkAsModified(tbBlogUser item);

    }
}
