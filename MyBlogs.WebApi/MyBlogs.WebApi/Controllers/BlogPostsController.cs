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
    public class BlogPostsController : ApiController
    {
        private BlogEntities db = new BlogEntities();
       
        DataAccessLayer dal = new DataAccessLayer();
        // GET: api/BlogPosts
        //public IQueryable<tbBlogPost> GettbBlogPosts()
        //{
        //    return db.tbBlogPosts;
        //}
        [HttpGet]
        public List<Blogs> GetPosts()
        {
            return dal.GetAllBlogs();
        }


        [HttpGet]
        [Route("api/BlogPosts/GetPostsByID/{blogPostID}")]
        public Blogs GetPostsByID(int blogPostID)
        {
            return dal.GetBlogByPostID(blogPostID);
        }

        //// GET: api/BlogPosts/5
        //[ResponseType(typeof(tbBlogPost))]
        //public IHttpActionResult GettbBlogPost(int id)
        //{
        //    tbBlogPost tbBlogPost = db.tbBlogPosts.Find(id);
        //    if (tbBlogPost == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tbBlogPost);
        //}

        // PUT: api/BlogPosts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttbBlogPost(int id, tbBlogPost tbBlogPost)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != tbBlogPost.BlogPostID)
            {
                return BadRequest();
            }

            db.Entry(tbBlogPost).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbBlogPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BlogPosts
        [ResponseType(typeof(tbBlogPost))]

        public IHttpActionResult PosttbBlogPost(tbBlogPost tbBlogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbBlogPosts.Add(tbBlogPost);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbBlogPost.BlogPostID }, tbBlogPost);
        }

        // DELETE: api/BlogPosts/5
        [ResponseType(typeof(tbBlogPost))]
        [Route("api/BlogPosts/DeletetbBlogPost/{id}")]
        public IHttpActionResult DeletetbBlogPost(int id)
        {
            tbBlogPost tbBlogPost = db.tbBlogPosts.Find(id);
            if (tbBlogPost == null)
            {
                return NotFound();
            }

            db.tbBlogPosts.Remove(tbBlogPost);
            db.SaveChanges();

            return Ok(tbBlogPost);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbBlogPostExists(int id)
        {
            return db.tbBlogPosts.Count(e => e.BlogPostID == id) > 0;
        }
    }
}