using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CountryCityApp.Models;

namespace CountryCityApp.Controllers
{
    public class CountryController : Controller
    {
        CountryGateway aCountryGateway=new CountryGateway();
        //
        // GET: /Country/
        public ActionResult Save()
        {
            ViewBag.countries = aCountryGateway.GetAllCountry().OrderBy(x => x.Name).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Country aCountry, HttpPostedFileBase picture)
        {
            try
            {
                string fileName = Path.GetFileName(picture.FileName);
                string path = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                picture.SaveAs(path);
                aCountry.Picture = "/Pictures/" + fileName;
            }
            catch
            {
                
            }
            aCountryGateway.Save(aCountry);
            ViewBag.countries = aCountryGateway.GetAllCountry().OrderBy(x => x.Name).ToList();
            return View();

        }

        public JsonResult CheckName(string name)
        {
            Country aCountry = aCountryGateway.GetAllCountry().FirstOrDefault(x => x.Name == name);
            if (aCountry == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
	}
}