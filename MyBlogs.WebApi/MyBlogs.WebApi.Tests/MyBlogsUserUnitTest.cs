using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlogs.WebApi.Controllers;
using MyBlogs.WebApi.Models;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace MyBlogs.WebApi.Tests
{
    [TestClass]
    public class MyBlogsUserUnitTest
    {
        [TestMethod]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            var testUsers = GetDemoUser();
            var controller = new BlogUsersController();

            var result = controller.GettbBlogUser(1) as List<BlogUser>;
            Assert.AreEqual(testUsers.Count, result.Count);
        }

        private List<BlogUser> GetDemoUser()
        {
            var testProducts = new List<BlogUser>();
            testProducts.Add(new BlogUser { name = "Demo User1", password = "Demo", email = "abc@abc.com" });
            testProducts.Add(new BlogUser { name = "Demo User2", password = "Demo", email = "abc@abc.com" });
            return testProducts;
        }

    }
}
