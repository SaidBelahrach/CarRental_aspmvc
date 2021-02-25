using projet_ASP.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;
using System;
using Microsoft.AspNet.Identity;

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
            string ID =id;
            
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.Where(item => item.Id == ID).FirstOrDefault();
            if(user.ListeNoire != null)
            {
               
            }
            db.SaveChanges();
            return Json("ListeNoire updated");
        }

        public ActionResult Reclamations()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var reclamations = db.Reclamations.ToList();

            return View(reclamations);
        } 
        
        
        [HttpPost]
        public ActionResult Reclamations(string id)
        {
           int reclmationID =Convert.ToInt32( id);

            ApplicationDbContext db = new ApplicationDbContext();
            var rec = db.Reclamations.Where(item => item.idReclamation == reclmationID).FirstOrDefault();
            rec.valide = true;
            string nomReclamer = "";
            string idAppUser = "";
            if (rec.Createur == true)
            {
                idAppUser = db.Locataires.Where(l => l.idLocataire == rec.idLocataire).FirstOrDefault().ApplicationUserID;
                nomReclamer = db.Users.Where(u => u.Id == idAppUser).FirstOrDefault().nomComplet;
            }else
            {
                idAppUser = db.Proprietaires.Where(l => l.idProprietaire == rec.idProprietaire).FirstOrDefault().ApplicationUserID;
                nomReclamer = db.Users.Where(u => u.Id == idAppUser).FirstOrDefault().nomComplet;
            }
                Notification notification = new Notification()
                {
                    type = "r",
                    hint ="Votre réclamtion sur "+nomReclamer+" est valider" ,
                    ApplicationUserID = idAppUser,
                    vu = false,
                    cliked = false,
                };
                db.Notifications.Add(notification);
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
            var users_ListesFavoris = db.Users.Where(item => item.Favoris.admin.ApplicationUserID == currentUserId);

            return View(users_ListesFavoris);
        }

    }



}