﻿using Bil372_Homework.Data;
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
    public class UserController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        private AppDbContext dbContext;
        public UserController()
        {
            dbContext = new AppDbContext("Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372HW;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            var viewModel = new UserViewModel();
            viewModel.Users = dbContext.Users.ToList();
            return View(viewModel);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult Info()
        {
            connectionString();
            con.Open();
            com.Connection = con;
            List<UserInfo> model = new List<UserInfo>();
            com.CommandText = "SELECT * FROM [dbo].[UserInfoes] WHERE AuthenticationID = (SELECT AuthenticationID FROM [dbo].[Users] Where UserName ='" + LoggedUser.LoggedUserName + "' and Password ='" + LoggedUser.LoggedPassword + "')";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                var UserInf = new UserInfo();
                UserInf.AuthenticationID = (int)dr["AuthenticationID"];
                UserInf.Title = dr["Title"].ToString();
                UserInf.Name = dr["Name"].ToString();
                UserInf.Affilation = dr["Affilation"].ToString();
                UserInf.primaryEmail = dr["primaryEmail"].ToString();
                UserInf.secondaryEmail = dr["secondaryEmail"].ToString();
                UserInf.password = dr["password"].ToString();
                UserInf.Phone = dr["Phone"].ToString();
                UserInf.fax = dr["fax"].ToString();
                UserInf.URL = dr["URL"].ToString();
                UserInf.Address = dr["Address"].ToString();
                UserInf.City = dr["City"].ToString();
                UserInf.Country = dr["Country"].ToString();
                UserInf.Record = dr["Record"].ToString();
                UserInf.CreationDate = (DateTime)dr["CreationDate"];
                model.Add(UserInf);

            }
            con.Close();
            return View(model);
        }

        void connectionString()
        {
            con.ConnectionString = "Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372HW;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        [HttpPost]
        public ActionResult Verify(User user)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT AuthenticationID, Confirm FROM [dbo].[Users] WHERE UserName ='" + user.UserName + "' and Password ='" + user.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                int Confirm = (int)dr["Confirm"];
                if(Confirm == 0)
                {
                    con.Close();
                    return View("NotConfirm");
                }
                dr.Close();

                List<UserInfo> model = new List<UserInfo>();
                com.CommandText = "SELECT * FROM [dbo].[UserInfoes] WHERE AuthenticationID = (SELECT AuthenticationID FROM [dbo].[Users] Where UserName ='" + user.UserName + "' and Password ='" + user.Password + "')";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    var UserInf = new UserInfo();
                    UserInf.AuthenticationID = (int)dr["AuthenticationID"];
                    LoggedUser.LoggedId = (int)dr["AuthenticationID"];
                    UserInf.Title = dr["Title"].ToString(); 
                    UserInf.Name = dr["Name"].ToString(); 
                    UserInf.Affilation = dr["Affilation"].ToString(); 
                    UserInf.primaryEmail = dr["primaryEmail"].ToString(); 
                    UserInf.secondaryEmail = dr["secondaryEmail"].ToString(); 
                    UserInf.password = dr["password"].ToString(); 
                    UserInf.Phone = dr["Phone"].ToString(); 
                    UserInf.fax = dr["fax"].ToString(); 
                    UserInf.URL = dr["URL"].ToString(); 
                    UserInf.Address = dr["Address"].ToString(); 
                    UserInf.City = dr["City"].ToString(); 
                    UserInf.Country = dr["Country"].ToString(); 
                    UserInf.Record = dr["Record"].ToString(); 
                    UserInf.CreationDate = (DateTime)dr["CreationDate"];
                    model.Add(UserInf);

                }
                LoggedUser.LoggedUserName = user.UserName;
                LoggedUser.LoggedPassword = user.Password;
                con.Close();
                if(LoggedUser.LoggedUserName ==  "admin")
                {
                    DataTable dataTable = new DataTable();
                    using (SqlConnection sqlCon = new SqlConnection("Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372HW;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                    {
                        sqlCon.Open();
                        SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM [dbo].[Users]", sqlCon);
                        sqlDA.Fill(dataTable);
                    }
                    return View("Admin", dataTable);
                }
                return View("Info",model);
            }
            else
            {
                con.Close();
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO [dbo].[Users] VALUES( '" + user.UserName + "', '" + user.Password + "', " + 0 + ")";
            com.ExecuteNonQuery();
            com.CommandText = "SELECT AuthenticationID FROM [dbo].[Users] Where UserName ='" + user.UserName + "' and Password ='" + user.Password + "'";
            dr = com.ExecuteReader();
            int authenticationId = 0;
            while (dr.Read())
            {
                authenticationId = (int)dr["AuthenticationID"]; 
            }
            dr.Close();
            com.CommandText = "INSERT INTO [dbo].[UserInfoes] VALUES ('"+ authenticationId +"','','','','','','" + user.Password + "' , '','','','','','','','')";
            com.ExecuteNonQuery();
            con.Close();
            return View("Login");
        }
        [HttpGet,HttpPost]
        public ActionResult IInfo()
        {
            connectionString();
            con.Open();
            com.Connection = con;
            List<UserInfo> model = new List<UserInfo>();
            com.CommandText = "SELECT * FROM [dbo].[UserInfoes] WHERE AuthenticationID = (SELECT AuthenticationID FROM [dbo].[Users] Where UserName ='" + LoggedUser.LoggedUserName + "' and Password ='" + LoggedUser.LoggedPassword + "')";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                    var UserInf = new UserInfo();
                    UserInf.AuthenticationID = (int)dr["AuthenticationID"];
                    UserInf.Title = dr["Title"].ToString();
                    UserInf.Name = dr["Name"].ToString();
                    UserInf.Affilation = dr["Affilation"].ToString();
                    UserInf.primaryEmail = dr["primaryEmail"].ToString();
                    UserInf.secondaryEmail = dr["secondaryEmail"].ToString();
                    UserInf.password = dr["password"].ToString();
                    UserInf.Phone = dr["Phone"].ToString();
                    UserInf.fax = dr["fax"].ToString();
                    UserInf.URL = dr["URL"].ToString();
                    UserInf.Address = dr["Address"].ToString();
                    UserInf.City = dr["City"].ToString();
                    UserInf.Country = dr["Country"].ToString();
                    UserInf.Record = dr["Record"].ToString();
                    UserInf.CreationDate = (DateTime)dr["CreationDate"];
                    model.Add(UserInf);

            }
            con.Close();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserInfo userInfo)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "UPDATE [dbo].[UserInfoes] SET Title = '" + userInfo.Title + "', Name = '" + userInfo.Name + "', Affilation = '" + userInfo.Affilation + "', primaryEmail = '" + userInfo.primaryEmail + "', secondaryEmail = '" + userInfo.secondaryEmail +
                "', password = '" + userInfo.password + "', Phone = '" + userInfo.Phone + "', fax = '" + userInfo.fax + "', URL = '" + userInfo.URL + "', Address = '" + userInfo.Address + "', City = '" + userInfo.City + "', Country = '" + userInfo.Country + "', Record = '" + userInfo.Record +
                "' WHERE AuthenticationID = " + userInfo.AuthenticationID;
            com.ExecuteNonQuery();
            con.Close();

            connectionString();
            con.Open();
            com.Connection = con;
            List<UserInfo> model = new List<UserInfo>();
            com.CommandText = "SELECT * FROM [dbo].[UserInfoes] WHERE AuthenticationID = (SELECT AuthenticationID FROM [dbo].[Users] Where UserName ='" + LoggedUser.LoggedUserName + "' and Password ='" + LoggedUser.LoggedPassword + "')";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                var UserInf = new UserInfo();
                UserInf.AuthenticationID = (int)dr["AuthenticationID"];
                UserInf.Title = dr["Title"].ToString();
                UserInf.Name = dr["Name"].ToString();
                UserInf.Affilation = dr["Affilation"].ToString();
                UserInf.primaryEmail = dr["primaryEmail"].ToString();
                UserInf.secondaryEmail = dr["secondaryEmail"].ToString();
                UserInf.password = dr["password"].ToString();
                UserInf.Phone = dr["Phone"].ToString();
                UserInf.fax = dr["fax"].ToString();
                UserInf.URL = dr["URL"].ToString();
                UserInf.Address = dr["Address"].ToString();
                UserInf.City = dr["City"].ToString();
                UserInf.Country = dr["Country"].ToString();
                UserInf.Record = dr["Record"].ToString();
                UserInf.CreationDate = (DateTime)dr["CreationDate"];
                model.Add(UserInf);

            }
            con.Close();
            return View("Info",model);
        }

        public ActionResult UserConference()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (AppDbContext db = new AppDbContext("Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372HW;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                List<Conference> empList = db.Conferences.ToList<Conference>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Conference());
            else
            {
                using (AppDbContext db = new AppDbContext("Server = tcp:databaseadmin.database.windows.net,1433; Initial Catalog = Bil372HW; Persist Security Info = False; User ID = databaseadmin; Password = admindatabase_9; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; "))
                {
                    return View(db.Conferences.Where(x => x.CreatorUser == LoggedUser.LoggedId).FirstOrDefault<Conference>());
                }
            }
        }
        public ActionResult Admin()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection("Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372HW;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM [dbo].[Users]" , sqlCon);
                sqlDA.Fill(dataTable);
            }
            return View(dataTable);
        }

        public ActionResult Confirm(String AuthenticationID)
        {
            using (SqlConnection sqlCon = new SqlConnection("Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372HW;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "UPDATE [dbo].[Users] SET Confirm = '" + 1 + "' WHERE AuthenticationID = " + AuthenticationID;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Admin");
        }
    }
}