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
    public class BlogUsersController : ApiController
    {
       private BlogEntities db = new BlogEntities();
        // modify the type of the db field
         //private IBlogUser db = new BlogEntities();
        List<tbBlogUser> lstBlogUsers = new List<tbBlogUser>();

        DataAccessLayer dal = new DataAccessLayer();
        
        public BlogUsersController()
        {
           
        }
       
        //public BlogUsersController(List<tbBlogUser> lsttbBlogUsers)
        //{ lstBlogUsers = lsttbBlogUsers; }

        //// GET: api/BlogUsers
        //public IQueryable<tbBlogUser> GettbBlogUsers()
        //{
        //    return db.tbBlogUsers;
        //}

        [HttpGet]
        public string get()
        {
            return "Value";
        }

        [HttpPost]
        public int Create([FromBody] BlogUser blogUser)
        {
            return dal.AddEmployee(blogUser);
        }

        // GET: api/BlogUsers/5
        [ResponseType(typeof(tbBlogUser))]
        public IHttpActionResult GettbBlogUser(int id)
        {
            tbBlogUser tbBlogUser = db.tbBlogUsers.Find(id);
            if (tbBlogUser == null)
            {
                return NotFound();
            }

            return Ok(tbBlogUser);
        }

        // PUT: api/BlogUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttbBlogUser(int id, tbBlogUser tbBlogUser)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != tbBlogUser.BlogUserID)
            {
                return BadRequest();
            }

           db.Entry(tbBlogUser).State = EntityState.Modified;

             //db.MarkAsModified(tbBlogUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbBlogUserExists(id))
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

        //// POST: api/BlogUsers
        //[ResponseType(typeof(tbBlogUser))]
        //public IHttpActionResult PosttbBlogUser(tbBlogUser tbBlogUser)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    db.tbBlogUsers.Add(tbBlogUser);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = tbBlogUser.BlogUserID }, tbBlogUser);
        //}

        // DELETE: api/BlogUsers/5
        [ResponseType(typeof(tbBlogUser))]
        [Route("api/BlogUsers/DeletetbBlogUser/{id}")]
        public IHttpActionResult DeletetbBlogUser(int id)
        {
            tbBlogUser tbBlogUser = db.tbBlogUsers.Find(id);
            if (tbBlogUser == null)
            {
                return NotFound();
            }

            db.tbBlogUsers.Remove(tbBlogUser);
            db.SaveChanges();

            return Ok(tbBlogUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbBlogUserExists(int id)
        {
            return db.tbBlogUsers.Count(e => e.BlogUserID == id) > 0;
        }
    }
}