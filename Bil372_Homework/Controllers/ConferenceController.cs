using Bil372_Homework.Data;
using Bil372_Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Homework.Controllers
{
    public class ConferenceController : Controller
    {

        private AppDbContext dbContext;
        public ConferenceController()
        {
            dbContext = new AppDbContext("Server=tcp:databaseadmin.database.windows.net,1433;Initial Catalog=Bil372HW;Persist Security Info=False;User ID=databaseadmin;Password=admindatabase_9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        // GET: Conference
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (dbContext)
            {
                List<Conference> conferences = dbContext.Conferences.ToList<Conference>();
                return Json(new { data = conferences }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
    }
}