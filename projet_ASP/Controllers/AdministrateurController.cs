using projet_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace projet_ASP.Controllers
{
    public class AdministrateurController : Controller
    {
        // GET: Administrateur
        public ActionResult Propietaires()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var prop = db.Proprietaires.Include(p => p.ApplicationUser).Include(t => t.Voitures).ToList();

            return View(prop);
        }
        public ActionResult Locataires()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var loca = db.Locataires.Include(p => p.ApplicationUser).Include(t => t.reservations).ToList();
            /*   ListeNoire ls = new ListeNoire()
              {
                  description = "dezk",
                  idAdmin = 1,

              };*/
     /*       var user = loca.FirstOrDefault().ApplicationUser;
            user.idListeNoire = 2;
            db.Users.AddOrUpdate(user);

            Admin ad = new Admin()
            {
                ApplicationUserID = "4d4e6da5-ac33-44cc-a686-c0c0ef67983c",
            };
            db.Admins.Add(ad);
            db.SaveChanges();*/
            return View(loca);
        }

        public ActionResult Reclamations()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var reclamations = db.Reclamations.ToList();

            return View(reclamations);
        }
    }



}