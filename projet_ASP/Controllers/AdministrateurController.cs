using projet_ASP.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

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

        [HttpPost]
        public ActionResult Locataires(string id)
        {


            ApplicationDbContext db = new ApplicationDbContext();
            string currentUserid = User.Identity.GetUserId();
            
           var user = db.Users.Where(item => item.Id == id).FirstOrDefault();
            var admine = db.Admins.Where(item => item.ApplicationUserID == currentUserid).FirstOrDefault();
            var ls = db.ListeNoires.Where(item => item.description == "Cheated").FirstOrDefault();

     
            if(ls == null)
            {
                ls = new ListeNoire()
                {
                    description = "Cheated"
                };
                db.ListeNoires.Add(ls);
            }
        
            if ( user.idListeNoire == null)
           {

            user.idListeNoire = ls.idListeNoire;
             db.Users.AddOrUpdate(user);
           }
           else
           {
                user.idListeNoire = null; 
           }



            db.SaveChanges();
            var count = ls.users.Count();
            return Json("ListeNoire updated");
        }


        public ActionResult Reclamations()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var reclamations = db.Reclamations.ToList();

            // return View(reclamations);
            return Content(""+db.ListeNoires.Find(3).users.Count());
        } 
        
        
        [HttpPost]
        public ActionResult Reclamations(string id)
        {
           int reclmationID =Convert.ToInt32( id);

            ApplicationDbContext db = new ApplicationDbContext();
            var rec = db.Reclamations.Where(item => item.idReclamation == reclmationID).FirstOrDefault();
            rec.valide = true;
         
         
         
            db.SaveChanges();
            return Json("reclamation updated");
        }

        public ActionResult ListeNoire()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Users.Where(item => item.ListeNoire != null);

            return View();
        }

        public ActionResult ListesDesFavoris()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string currentUserId = User.Identity.GetUserId();

            return View();
        }

/*        public ActionResult ListeNoire()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var ls = db.ListeNoires.ToList();

            return View();

        }*/

    }



}