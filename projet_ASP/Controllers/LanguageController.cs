using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace projet_ASP.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult SetLanguage(string name)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(name);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            var cookie = new HttpCookie("culture", name);
            cookie.Expires = DateTime.Today.AddYears(1);
            Response.SetCookie(cookie);
            return RedirectToAction("Index", "Voitures");
        }
    }
}