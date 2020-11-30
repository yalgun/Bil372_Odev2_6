using Bil372_Homework.Data;
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
    public class ConferenceController : Controller
    {

        public String ConnectionString = "Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372HW;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        // GET: Conference
        public ActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM [dbo].[Conferences] WHERE CreatorUser = " + LoggedUser.LoggedId  , sqlCon);
                sqlDA.Fill(dataTable);
            }
            return View(dataTable);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Conference());
        }

        [HttpPost]
        public ActionResult Create(Conference conference)
        {
            using(SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO [dbo][Conferences] VALUES('_" + conference.ShortName + "_" + conference.Year + "', " + conference.CreationDateTime + "','" +
                    conference.Name + "','" + conference.ShortName + "','" + conference.Year + "','" + conference.StartDate + "','" + conference.EndDate + "','" + 
                    conference.SubmisionDeadline + "','" + LoggedUser.LoggedId + "','" + conference.WebSite + "')";
                SqlCommand sqlCommand = new SqlCommand(query,sqlCon);
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

    }
}