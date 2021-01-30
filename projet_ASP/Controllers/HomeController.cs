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
            dbContext db = new dbContext();
            Proprietaire p = new Proprietaire()
            {
               email="said@sa.fe",
               adresse="des",
               idProprietaire=1,
               nomComplet="Said Belahrach",
               tel="00000"
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
               
            };
            //db.Proprietaires.Add(p);
           // db.Voitures.Add(v);
       //     db.SaveChanges();
            // List<Voiture> v = db.Voitures.ToList();
            return View(v);
        }
    }
}