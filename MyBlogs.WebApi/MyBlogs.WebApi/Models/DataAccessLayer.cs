using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

namespace MyBlogs.WebApi.Models
{
    public class DataAccessLayer
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BlogEntities_Conn"].ConnectionString;//  "Server= localhost; Database= Blog; Integrated Security=True;";
        public int AddEmployee(BlogUser blogUser)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddBlogUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlogUserName", blogUser.name);
                    cmd.Parameters.AddWithValue("@BlogUserPassword", blogUser.password);
                    cmd.Parameters.AddWithValue("@BlogUserEmailID", blogUser.email);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateAdminUser(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateAdminUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlogUserID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To View all employees details  
        public List<Blogs> GetAllBlogs()
        {  
            try  
            {  
                List<Blogs> lstblog = new List<Blogs>();  
  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spGetBlogs", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    con.Open();  
                    SqlDataReader rdr = cmd.ExecuteReader();  
  
                    while (rdr.Read())  
                    {
                        Blogs blog = new Blogs();

                        blog.id = Convert.ToInt32(rdr["BlogPostID"]);
                        blog.title = rdr["BlogPostTitle"].ToString();
                        blog.body = rdr["BlogPostBody"].ToString();
                        blog.date = rdr["BlogPostDate"].ToString();
                        blog.username = rdr["BlogUserName"].ToString();

                        lstblog.Add(blog);  
                    }  
                    con.Close();  
                }  
                return lstblog;  
            }  
            catch  
            {  
                throw;  
            }  
        }

        public List<AdminUser> GetAllUsers()
        {
            try
            {
                List<AdminUser> lstUser = new List<AdminUser>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllUsers", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AdminUser user = new AdminUser();

                        user.id = Convert.ToInt32(rdr["BlogUserID"]);
                        user.name = rdr["BlogUserName"].ToString();
                        user.email = rdr["BlogUserEmailID"].ToString();
                        user.isadmin= rdr["BlogIsAdmin"].ToString().ToLower();
                        lstUser.Add(user);
                    }
                    con.Close();
                }
                return lstUser;
            }
            catch
            {
                throw;
            }
        }

        public Blogs GetBlogByPostID(int PostID)
        {
            try
            {
                Blogs blog = new Blogs();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetBlogsByBlogPostID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@BlogPostID", PostID);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        blog.id = Convert.ToInt32(rdr["BlogPostID"]);
                        blog.title = rdr["BlogPostTitle"].ToString();
                        blog.body = rdr["BlogPostBody"].ToString();
                        blog.date = rdr["BlogPostDate"].ToString();
                        blog.username = rdr["BlogUserName"].ToString();

                     
                    }
                    con.Close();
                }
                return blog;
            }
            catch
            {
                throw;
            }
        }

        public UserDetails GetUserByID(string userName,string password)
        {
            try
            {
                UserDetails userDetails = new UserDetails();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetValidateUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlogUserEmailID", userName);
                    cmd.Parameters.AddWithValue("@BlogUserPassword", password);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        userDetails.id = rdr["BlogUserID"].ToString();
                        userDetails.name = rdr["BlogUserName"].ToString();
                        userDetails.email = rdr["BlogUserEmailID"].ToString();
                        userDetails.password = rdr["BlogUserPassword"].ToString();
                        userDetails.isadmin = rdr["BlogIsAdmin"].ToString();
                        userDetails.authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(rdr["BlogUserEmailID"].ToString())) + "|" + Convert.ToBase64String(Encoding.UTF8.GetBytes(rdr["BlogUserPassword"].ToString()));


                    }
                    con.Close();
                }
                return userDetails;
            }
            catch
            {
                throw;
            }
        }



    }
}