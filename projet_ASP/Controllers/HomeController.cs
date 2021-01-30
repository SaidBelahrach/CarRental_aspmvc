using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projet_ASP.Models;

namespace projet_ASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var db = new ApplicationDbContext();
            Proprietaire p = new Proprietaire()
            { 
               adresse="des",
               idProprietaire=1,
               nomComplet="Said Belahrach", 
               ApplicationUserID= "892b2686-05a5-4e29-a11d-dd71eea99385"
            };
            
            Voiture v = new Voiture()
            {
                couleur = "e",
                coutParJour = 7,
                marque = "e",
                km = 88,
                matricule = "rrde",
                model = "8s8",
                idProprietaire=1
               
            };/**/
            //db.Proprietaires.Add(p);
            //db.Voitures.Add(v);
            //db.SaveChanges();
            // List<Voiture> v = db.Voitures.ToList();
            return View(v);
           // return Content(db.Proprietaires.FirstOrDefault().ApplicationUser.Email);
        }
    }
}