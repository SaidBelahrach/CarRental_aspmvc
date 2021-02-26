using projet_ASP.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

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


        [HttpPost]
        public ActionResult Propietaires(string id)
        {


            ApplicationDbContext db = new ApplicationDbContext();
            string currentUserid = User.Identity.GetUserId();

            var user = db.Users.Where(item => item.Id == id ).FirstOrDefault();
      
            var admine = db.Admins.Where(item => item.ApplicationUserID == currentUserid).FirstOrDefault();
            Favoris Newfavori = new Favoris { idAdmin = admine.idAdmin, ApplicationUserID = id };
            var favori = db.Favoris.Where(item => item.idAdmin == admine.idAdmin && item.ApplicationUserID == id).FirstOrDefault();
            if (favori == null)
            {
                db.Favoris.AddOrUpdate(Newfavori);
            }
            else
            {
                return Json("Deja favoris");
            }
            db.SaveChanges();


            return Json("Favoris updated");

        }

        [HttpPost]
        public ActionResult SearchProp(String key)
        {
            List<Proprietaire> proprietaires;
            ApplicationDbContext db = new ApplicationDbContext();
            if (String.IsNullOrEmpty(key))
            {
                proprietaires = db.Proprietaires.ToList();
            }
            else
            {
                key = key.Trim();
                if (key.Length == 0) return View(db.Locataires.ToList());
                proprietaires = db.Proprietaires.Where(v => v.ApplicationUser.nomComplet.ToLower().Contains(key.ToLower())).ToList();
            }


            return View("Propietaires", proprietaires);
        }

        public ActionResult Locataires()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var loca = db.Locataires.Include(p => p.ApplicationUser).Include(t => t.reservations).ToList();

            return View(loca);
        }

        [HttpPost]
        public ActionResult Locataires(string id)
        {


            ApplicationDbContext db = new ApplicationDbContext();
            string currentUserid = User.Identity.GetUserId();

            var user = db.Users.Where(item => item.Id == id).FirstOrDefault();
            var admine = db.Admins.Where(item => item.ApplicationUserID == currentUserid).FirstOrDefault();
            Favoris Newfavori = new Favoris { idAdmin = admine.idAdmin, ApplicationUserID = id };
            var favori = db.Favoris.Where(item => item.idAdmin == admine.idAdmin && item.ApplicationUserID == id).FirstOrDefault();
            if(favori==null )
            { 
            db.Favoris.AddOrUpdate(Newfavori);
            }
            else
            {
                return Json("Deja favoris");
            }
            db.SaveChanges();


            return Json("Favoris updated");
        }
       
        [HttpPost]
        public ActionResult SearchLoc(String key)
        {
            List<Locataire> locataires;
            ApplicationDbContext db = new ApplicationDbContext();
            string userid = User.Identity.GetUserId();
            if(String.IsNullOrEmpty(key))
            {
             locataires = db.Locataires.Include(v => v.reservations).ToList();
            }
            else
            { 
            key = key.Trim();
            if (key.Length == 0) return View(db.Locataires.ToList());
            locataires = db.Locataires.Where(v => v.ApplicationUser.nomComplet.ToLower().Contains(key.ToLower())).Include(v => v.reservations).ToList();
            }


            return View("Locataires", locataires);
        }

            public ActionResult AjoutALaLiteNoire(string id)
        {

            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);

        }
        [HttpPost]
        public ActionResult AjoutALaLiteNoire(String id, String Desc)
        {

            if (Desc == "")
            {
                Desc = "Unjustifié";
            }
            ApplicationDbContext db = new ApplicationDbContext();
            string currentUserid = User.Identity.GetUserId();

            var user = db.Users.Where(item => item.Id == id).FirstOrDefault();
            var admine = db.Admins.Where(item => item.ApplicationUserID == currentUserid).FirstOrDefault();
            var ls = db.ListeNoires.Where(item => item.description == Desc && item.idAdmin == admine.idAdmin).FirstOrDefault();


            if (ls == null)
            {
                ls = new ListeNoire()
                {
                    description = Desc,
                    idAdmin = admine.idAdmin
                };
                db.ListeNoires.Add(ls);
            }

            if (user.idListeNoire == null)
            {

                user.idListeNoire = ls.idListeNoire;
                db.Users.AddOrUpdate(user);
            }
            else
            {
                user.idListeNoire = null;
                db.Users.AddOrUpdate(user);
            }



            db.SaveChanges();

            return RedirectToAction("ListeNoire", "Administrateur");

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
            int reclmationID = Convert.ToInt32(id);

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
            var Blacklist = db.Users.Where(item => item.idListeNoire != null).Include(item => item.ListeNoire).ToList();

            return View(Blacklist);
        }

        [HttpPost]
        public ActionResult ListeNoire(String id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.Find(id);
            user.idListeNoire = null;
            db.SaveChanges();
            return Json("ListeNoire Updated");
        }

        public ActionResult ListesDesFavoris()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string currentUserId = User.Identity.GetUserId();
            var admine = db.Admins.Where(item => item.ApplicationUserID == currentUserId).FirstOrDefault();
            var ListDesfavories = db.Favoris.Where(item => item.idAdmin == admine.idAdmin).ToList();
            List<ApplicationUser> users = new List<ApplicationUser>();
            foreach (var item in ListDesfavories)
            {
                users.Add(item.ApplicationUser);
            }

            return View(users);
        }

        [HttpPost]
        public ActionResult ListesDesFavoris(String id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.Find(id);
            string currentUserId = User.Identity.GetUserId();
            var admine = db.Admins.Where(item => item.ApplicationUserID == currentUserId).FirstOrDefault();
            var favori=db.Favoris.Where(item => item.idAdmin == admine.idAdmin && item.ApplicationUserID == id).FirstOrDefault();
            db.Favoris.Remove(favori);
            db.SaveChanges();
            return Json("Favoris Updated");
        }


    }
}