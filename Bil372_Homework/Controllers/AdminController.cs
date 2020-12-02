using Bil372_Homework.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Homework.Controllers
{
    public class AdminController : Controller
    {
        public String ConnectionString = "Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372HW;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        // GET: Admin
        public ActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM [dbo].[Users]" + LoggedUser.LoggedId, sqlCon);
                sqlDA.Fill(dataTable);
            }
            return View(dataTable);
        }


        [HttpPost]
        public ActionResult Confirm(int AuthenticationID)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE [dbo].[Users] SET Confirm = '" + 1 + "' WHERE AuthenticationID = '" + AuthenticationID+ "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Admin");
        }
    }
}