using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyBlogs.Models
{
    public class DataAccessLayer
    {
        string connectionString = "Server= localhost; Database= Blog; Integrated Security=True;";
        //public int AddEmployee(BlogUser blogUser)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand("spAddBlogUser", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@BlogUserName", blogUser.name);
        //            cmd.Parameters.AddWithValue("@BlogUserPassword", blogUser.password);
        //            cmd.Parameters.AddWithValue("@BlogUserEmailID", blogUser.email);
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        return 1;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}
