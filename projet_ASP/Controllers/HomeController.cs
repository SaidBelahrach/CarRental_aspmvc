using projet_ASP.Models;
using System.Web.Mvc;
using System.Linq;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;



namespace projet_ASP.Controllers
{
    public class HomeController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public ActionResult Index()
        {

            /* ApplicationDbContext db = new ApplicationDbContext();
         ApplicationSignInManager _signInManager;
         RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
         var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
         userManager.AddToRole(db.Users.FirstOrDefault().Id, "Locataire"); 
          if (!roleManager.RoleExists("Locataire"))
              {
                  var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                  role.Name = "Locataire";
                  roleManager.Create(role);
                  return Content("created");
              }
              else
              {
                  return Content("already");
              }*/

     
            return RedirectToAction("Index", "Voitures");
        }

        public JsonResult RemoveNotif(string id)
        {
            int notifId = Convert.ToInt32(id);
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var notif = db.Notifications.Where(n => n.idNotification == notifId).FirstOrDefault();
                if (notif != null)
                {
                    db.Notifications.Remove(notif);
                    db.SaveChanges();
                }

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Json("Deleted" + id);
        }

        public JsonResult unviewedAllNotif()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string id = User.Identity.GetUserId();
            var notifs = db.Notifications.Where(n => n.ApplicationUserID == id).ToList();
            notifs.ForEach(n => n.vu = true);
            db.SaveChanges();
            return Json("");
        }
        public ActionResult EspaceNotif()
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string id2 = User.Identity.GetUserId();
                var user = db.Users.Where(n => n.Id == id2).FirstOrDefault();
                if (user.idListeNoire != null)
                {
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    var listenoir = db.ListeNoires.Where(l => l.idListeNoire == user.idListeNoire).FirstOrDefault();
                    ViewData["msg"] = listenoir.description;
                    return RedirectToAction("BlokcedUser", "Account");


                }
            }
            catch (Exception) { }


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
                idProprietaire = 1,
                ApplicationUserID = "892b2686-05a5-4e29-a11d-dd71eea99385"
            };

            Voiture v = new Voiture()
            {
                couleur = "e",
                coutParJour = "7",
                marque = "e",
                matricule = "rrde",
                model = "8s8",
                idProprietaire = 1

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