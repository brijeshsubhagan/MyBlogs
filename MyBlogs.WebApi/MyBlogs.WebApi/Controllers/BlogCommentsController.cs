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
    public class BlogCommentsController : ApiController
    {
        private BlogEntities db = new BlogEntities();

        // GET: api/BlogComments
        public IQueryable<tbBlogComment> GettbBlogComments()
        {
            return db.tbBlogComments;
        }

        // GET: api/BlogComments/5
        [ResponseType(typeof(tbBlogComment))]
        public IHttpActionResult GettbBlogComment(int id)
        {
            tbBlogComment tbBlogComment = db.tbBlogComments.Find(id);
            if (tbBlogComment == null)
            {
                return NotFound();
            }

            return Ok(tbBlogComment);
        }

        // PUT: api/BlogComments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttbBlogComment(int id, tbBlogComment tbBlogComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbBlogComment.BlogCommentID)
            {
                return BadRequest();
            }

            db.Entry(tbBlogComment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbBlogCommentExists(id))
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

        // POST: api/BlogComments
        [ResponseType(typeof(tbBlogComment))]
        public IHttpActionResult PosttbBlogComment(tbBlogComment tbBlogComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbBlogComments.Add(tbBlogComment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbBlogComment.BlogCommentID }, tbBlogComment);
        }

        // DELETE: api/BlogComments/5
        [ResponseType(typeof(tbBlogComment))]
        public IHttpActionResult DeletetbBlogComment(int id)
        {
            tbBlogComment tbBlogComment = db.tbBlogComments.Find(id);
            if (tbBlogComment == null)
            {
                return NotFound();
            }

            db.tbBlogComments.Remove(tbBlogComment);
            db.SaveChanges();

            return Ok(tbBlogComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbBlogCommentExists(int id)
        {
            return db.tbBlogComments.Count(e => e.BlogCommentID == id) > 0;
        }
    }
}