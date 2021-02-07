using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projet_ASP.Models;

namespace projet_ASP.Controllers
{
    public class LocatairesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Locataires
        public ActionResult Index()
        {
            var locataires = db.Locataires.Include(l => l.ApplicationUser);
            return View(locataires.ToList());
        }

        // GET: Locataires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locataire locataire = db.Locataires.Find(id);
            if (locataire == null)
            {
                return HttpNotFound();
            }
            return View(locataire);
        }

        // GET: Locataires/Create
        public ActionResult Create()
        {
            /*ViewBag.ApplicationUserID = new SelectList(db.ApplicationUsers, "Id", "nomComplet");*/
            return View();
        }

        // POST: Locataires/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLocataire,Npermis,ApplicationUserID")] Locataire locataire)
        {
            if (ModelState.IsValid)
            {
                db.Locataires.Add(locataire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

          /*  ViewBag.ApplicationUserID = new SelectList(db.ApplicationUsers, "Id", "nomComplet", locataire.ApplicationUserID);*/
            return View(locataire);
        }

        // GET: Locataires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locataire locataire = db.Locataires.Find(id);
            if (locataire == null)
            {
                return HttpNotFound();
            }
          /*  ViewBag.ApplicationUserID = new SelectList(db.ApplicationUsers, "Id", "nomComplet", locataire.ApplicationUserID);*/
            return View(locataire);
        }

        // POST: Locataires/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLocataire,Npermis,ApplicationUserID")] Locataire locataire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locataire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          /*  ViewBag.ApplicationUserID = new SelectList(db.ApplicationUsers, "Id", "nomComplet", locataire.ApplicationUserID);*/
            return View(locataire);
        }

        // GET: Locataires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locataire locataire = db.Locataires.Find(id);
            if (locataire == null)
            {
                return HttpNotFound();
            }
            return View(locataire);
        }

        // POST: Locataires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locataire locataire = db.Locataires.Find(id);
            db.Locataires.Remove(locataire);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
