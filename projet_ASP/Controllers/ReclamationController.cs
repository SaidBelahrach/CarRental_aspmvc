using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using projet_ASP.Models;
using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_ASP.Controllers
{
    public class ReclamationController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reclamation
        public ActionResult Index()
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string id = User.Identity.GetUserId();
                var user = db.Users.Where(n => n.Id == id).FirstOrDefault();
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

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reclamation/Create
        public ActionResult Create(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index"); //Content("page not found ");
            }
            string idSender = User.Identity.GetUserId();
            ViewData["idRecevier"] = id;
            if (User.IsInRole("Locataire"))
            {
                ViewData["idSender"] = db.Locataires.Where(l => l.ApplicationUserID.Equals(idSender)).FirstOrDefault().idLocataire;
            }
            else
            {
                ViewData["idSender"] = db.Proprietaires.Where(l => l.ApplicationUserID.Equals(idSender)).FirstOrDefault().idProprietaire;
            }
            return View();
        }


        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            bool createur = false;

            if (collection["idSender"] == null || collection["idReceveir"] == null) return RedirectToAction("Index", "Proprietaire");
            int idLoc, idProp, returnId;
            if (User.IsInRole("Locataire"))
            {
                createur = false;
                idLoc = Convert.ToInt32(collection["idSender"].Trim());
                idProp = Convert.ToInt32(collection["idReceveir"].Trim());
                returnId = idProp;

            }
            else
            {
                createur = true;
                idProp = Convert.ToInt32(collection["idSender"]);
                idLoc = Convert.ToInt32(collection["idReceveir"]);
                returnId = idLoc;
            }
            Reclamation reclamation = new Reclamation()
            {
                dateCreation = DateTime.Now.ToString(),
                Createur = createur,
                description = collection["description"].Trim(),
                valide = false,
                idLocataire = idLoc,
                idProprietaire = idProp
            };
            db.Reclamations.Add(reclamation);
            db.SaveChanges();
            return RedirectToAction("Index", "Voitures");
        }
        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // POST: Reclamation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reclamation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reclamation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
