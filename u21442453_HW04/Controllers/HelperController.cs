using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using u21442453_HW04.Models;

namespace u21442453_HW04.Controllers
{
    public class HelperController : Controller
    {
        List<Orphan> orphans = new List<Orphan>();
        // GET: Helper
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult becomeHelper()
        {
            string orphanPath = Server.MapPath("~/App_Data/Orphans.txt");
            using (var f = new StreamReader(orphanPath))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    orphans.Add(new Orphan(data[0], data[1], Convert.ToInt32(data[2]), data[3]));
                }
            }
            return View(orphans);
        }

        [HttpPost]
        public ActionResult becomeHelper(string fName, string lName, int age, string email, string phoneNumber, FormCollection fc)
        {
            string grade = fc["grade"];
            try
            {
                string routePath = Server.MapPath("~/App_Data/Helpers.txt");

                var data = $"{fName},{lName},{age},{email},{phoneNumber},{grade}";
                using (StreamWriter sw = new StreamWriter(routePath, true))
                {
                    sw.WriteLine(data);
                }
                ViewBag.Message = $"Thank you, {fName} {lName} for helping a {grade} orphan.";
                ViewBag.Style = "bg-success";
                return View();
            }
            catch
            {
                ViewBag.Message = $"An error occurred";
                ViewBag.Style = "bg-danger";
                return View();
            }
        }
    }
}