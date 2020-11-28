using Bil372_Homework.Data;
using Bil372_Homework.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Homework.Controllers
{
    public class SignInController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        AppDbContext  dbContext;
        // GET: SignIn
        public SignInController()
        {
            dbContext = new AppDbContext("Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372Odev;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372Odev;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO [dbo].[User] VALUES( '" + user.UserName + "', '" + user.Password + "')";
            com.ExecuteNonQuery();
            return View("Login");
        }
    }
}