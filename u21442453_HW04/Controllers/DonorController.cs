using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace u21442453_HW04.Controllers
{
    public class DonorController : Controller
    {
        // GET: Donor
        [HttpGet]
        public ActionResult makeDonation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult makeDonation(string fName, string lName, int age, string email, string phoneNumber, int quantity, FormCollection fc)
        {
            string type = fc["type"];
            try
            {
                string routePath = Server.MapPath("~/App_Data/Donors.txt");

                var data = $"{fName},{lName},{age},{email},{phoneNumber}*{type},{quantity}";
                using (StreamWriter sw = new StreamWriter(routePath, true))
                {
                    sw.WriteLine(data);
                }
                ViewBag.Message = $"Thank you, {fName} {lName} for donation {quantity} units of {type} products.";
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