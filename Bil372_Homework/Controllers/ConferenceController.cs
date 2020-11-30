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
                string query = "INSERT INTO [dbo].[Conferences] VALUES('_" + conference.ShortName + "_" + conference.Year + "', '" + conference.CreationDateTime + "','" +
                    conference.Name + "','" + conference.ShortName + "'," + conference.Year + ",'" + conference.StartDate + "','" + conference.EndDate + "','" + 
                    conference.SubmisionDeadline + "'," + LoggedUser.LoggedId + ",'" + conference.WebSite + "')";
                SqlCommand sqlCommand = new SqlCommand(query,sqlCon);
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(String ConfID)
        {
            Conference conference = new Conference();
            DataTable dtable = new DataTable();
            //ConfID = ConfID.Substring(1, ConfID.Length - 1);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM [dbo].[Conferences] WHERE ConfID ='"  + ConfID + "'";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(dtable);
                if(dtable.Rows.Count == 1)
                {
                    conference.ConfID = dtable.Rows[0][0].ToString();
                    conference.CreationDateTime = Convert.ToDateTime(dtable.Rows[0][1].ToString());
                    conference.Name = dtable.Rows[0][2].ToString();
                    conference.ShortName= dtable.Rows[0][3].ToString();
                    conference.Year = Convert.ToInt32(dtable.Rows[0][4].ToString());
                    conference.StartDate = Convert.ToDateTime(dtable.Rows[0][5].ToString());
                    conference.EndDate= Convert.ToDateTime(dtable.Rows[0][6].ToString());
                    conference.SubmisionDeadline= Convert.ToDateTime(dtable.Rows[0][7].ToString());
                    conference.CreatorUser = Convert.ToInt32(dtable.Rows[0][8].ToString());
                    conference.WebSite = dtable.Rows[0][9].ToString();
                    return View(conference);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Conference conference)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE [dbo].[Conferences] SET CreationDateTime = '" + conference.CreationDateTime + "',Name = '" +
                    conference.Name + "', ShortName = '" + conference.ShortName + "',Year = " + conference.Year + ", StartDate ='" + conference.StartDate + "',EndDate = '" + conference.EndDate + "', SubmisionDeadline = '" +
                    conference.SubmisionDeadline + "',WebSite = '" + conference.WebSite + "' WHERE ConfID = '" + conference.ConfID + "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String ConfID)
        {
            using(SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM [dbo].[Conferences] WHERE ConfID = '" + ConfID + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

    }
}