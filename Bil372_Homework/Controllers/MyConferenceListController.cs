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
    public class MyConferenceListController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: MyConferenceList
        public ActionResult Index()
        {
            connectionString();
            con.Open();
            com.Connection = con;
            List<Conference> model = new List<Conference>();
            com.CommandText = "SELECT * FROM [dbo].[Conferences] WHERE CreatorUser = (SELECT AuthenticationID FROM [dbo].[ConferenceRoles] Where ConferenceRole =0)";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                var ConInf = new Conference();
                ConInf.ConfID =dr["ConfID"].ToString();
                ConInf.CreationDateTime = (DateTime)dr["CreationDateTime"];
                ConInf.Name = dr["Name"].ToString();
                ConInf.ShortName = dr["ShortName"].ToString();
                ConInf.Year =(int)dr["Year"];
                ConInf.StartDate = (DateTime)dr["StartDate"];
                ConInf.EndDate = (DateTime)dr["EndDate"];
                ConInf.SubmisionDeadline = (DateTime)dr["SubmisionDeadline"];
                ConInf.CreatorUser = (int)dr["CreatorUser"];
                ConInf.WebSite = dr["WebSite"].ToString();
                model.Add(ConInf);

            }
            con.Close();
            return View(model);
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372HW;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}