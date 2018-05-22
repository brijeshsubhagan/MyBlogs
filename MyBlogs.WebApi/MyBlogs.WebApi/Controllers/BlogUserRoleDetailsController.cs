using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyBlogs.WebApi.Models;

namespace MyBlogs.WebApi.Controllers
{
    public class BlogUserRoleDetailsController : ApiController
    {
        DataAccessLayer dal = new DataAccessLayer();
        private BlogEntities db = new BlogEntities();

        //// GET: api/BlogUserRoleDetails
        //public IQueryable<tbBlogUserRoleDetail> GettbBlogUserRoleDetails()
        //{
        //    return db.tbBlogUserRoleDetails;
        //}

        //// GET: api/BlogUserRoleDetails/5
        //[ResponseType(typeof(tbBlogUserRoleDetail))]
        //public IHttpActionResult GettbBlogUserRoleDetail(int id)
        //{
        //    tbBlogUserRoleDetail tbBlogUserRoleDetail = db.tbBlogUserRoleDetails.Find(id);
        //    if (tbBlogUserRoleDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tbBlogUserRoleDetail);
        //}
        
        [Route("api/BlogUserRoleDetails/GetPostsByID/{id}")]
        [HttpGet, HttpPost]
        public Blogs GetPostsByID(int blogPostID)
        {
            return dal.GetBlogByPostID(blogPostID);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}