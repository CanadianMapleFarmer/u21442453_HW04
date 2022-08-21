using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Web.Mvc;
using u21442453_HW04.Models;

namespace u21442453_HW04.Controllers
{
    public class OrphanageController : Controller
    {
        List<Orphan> orphans = new List<Orphan>();
        List<Donor> donors = new List<Donor>();
        List<Orphan> hOrphans = new List<Orphan>();
        List<Helper> helpers = new List<Helper>();
        List<FosterParent> fosterParents = new List<FosterParent>();
        // GET: Orphanage
        [HttpGet]
        public ActionResult addOrphan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addOrphan(string fName, string lName, int age, FormCollection fc)
        {
            string genderText = fc["gender"];
            try
            {
                string routePath = Server.MapPath("~/App_Data/Orphans.txt");

                var data = fName + "," + lName + "," + age + "," + genderText;
                using (StreamWriter sw = new StreamWriter(routePath, true))
                {
                    sw.WriteLine(data);
                }
                ViewBag.Message = $"You have successfully added: {fName} {lName}, Age: {age}, Gender: {genderText} to the system.";
                ViewBag.Style = "bg-success";
                return View();
            }
            catch
            {
                ViewBag.Message = $"An error occurred.";
                ViewBag.Style = "bg-danger";
                return View();
            }
        }

        [HttpGet]
        public ActionResult orphanageNeeds()
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
            string donorPath = Server.MapPath("~/App_Data/Donors.txt");
            using (var f = new StreamReader(donorPath))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    var temp = line.Split('*');
                    var donorTemp = temp[0];
                    var donationTemp = temp[1];
                    var donorData = donorTemp.Split(',');
                    var donationData = donationTemp.Split(',');
                    donors.Add(new Donor(donorData[0], donorData[1], Convert.ToInt32(donorData[2]), donorData[3], donorData[4], new Donation(donationData[0], Convert.ToInt32(donationData[1]))));
                }
            }
            NeedsVM nvm = new NeedsVM();
            nvm.donors = donors;
            nvm.orphans = orphans;

            return View(nvm);
        }

        [HttpGet]
        public ActionResult homeworkHelp()
        {
            string orphanPath = Server.MapPath("~/App_Data/Orphans.txt");
            using (var f = new StreamReader(orphanPath))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    hOrphans.Add(new Orphan(data[0], data[1], Convert.ToInt32(data[2]), data[3]));
                }
            }
            string donorPath = Server.MapPath("~/App_Data/Helpers.txt");
            using (var f = new StreamReader(donorPath))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    helpers.Add(new Helper(data[0], data[1], Convert.ToInt32(data[2]), data[3], data[4], data[5]));
                }
            }
            HelperVM hvm = new HelperVM();
            hvm.orphans = hOrphans;
            hvm.helpers = helpers;
            return View(hvm);
        }

        [HttpGet]
        public ActionResult fosterList()
        {
            string fosterPath = Server.MapPath("~/App_Data/FosterParents.txt");
            using (var f = new StreamReader(fosterPath))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    fosterParents.Add(new FosterParent(data[0], data[1], Convert.ToInt32(data[2]), data[3], data[4], data[5]));
                }
            }

            return View(fosterParents);
        }
        
        [HttpPost]
        public ActionResult deleteFosterParent(int index)
        {
            int c = 0;
            string line;
            string fosterPath = Server.MapPath("~/App_Data/FosterParents.txt");
            StreamReader r = new StreamReader(fosterPath);
            string temp = null;
            while((line = r.ReadLine()) != null)
            {
                if ((c + 1).Equals(index))
                {

                }
                else
                {
                    temp += line;
                }
                c++;
            }

                r.Close();

                if (System.IO.File.Exists(fosterPath))
                {
                    StreamWriter w = new StreamWriter(fosterPath);
                    w.WriteLine(temp);
                    w.Close();
                }
            
            return RedirectToAction("fosterList");
        }
    }
}