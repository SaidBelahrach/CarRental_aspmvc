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

            return View(loca);
        }

        public ActionResult Statistiques()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var users = db.Users.ToList();

            return View(users);
        }
    }



}