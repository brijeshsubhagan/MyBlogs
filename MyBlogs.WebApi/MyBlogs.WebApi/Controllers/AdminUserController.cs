using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using MyBlogs.WebApi.Models;


namespace MyBlogs.WebApi.Controllers
{
    public class AdminUserController : ApiController
    {
        DataAccessLayer dal = new DataAccessLayer();
        [HttpGet]
        public List<AdminUser> GetPosts()
        {
            return dal.GetAllUsers();
        }

        [HttpGet]
        [Route("api/AdminUser/GetUserByID/{username}/{password}")]
        public UserDetails GetUserByID(string username, string password)
        {
            byte[] dataUserName = Convert.FromBase64String(username);
            string decodedUserName = Encoding.UTF8.GetString(dataUserName);
            byte[] dataPassword = Convert.FromBase64String(password);
            string decodedPassword = Encoding.UTF8.GetString(dataPassword);
            return dal.GetUserByID(decodedUserName, decodedPassword);
        }
        [HttpPut]
        [Route("api/AdminUser/GetUserByID/{id}")]
        public void updateAdminUser(int id)
        {
            dal.UpdateAdminUser(id);
        }


    }
}
