using projet_ASP.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace projet_ASP.Controllers
{
    [Authorize(Roles = "Proprietaire")]
    public class RetourVoituresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RetourVoitures
        public ActionResult Index()
        {
            return View(db.RetourVoitures.ToList());
        }

        // GET: RetourVoitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Reservations");
            }
            RetourVoiture retourVoiture = db.RetourVoitures.Where(r => r.idContrat == id).FirstOrDefault();
            if (retourVoiture == null)
            {
                return RedirectToAction("Index", "Reservations");
            }
            return View(retourVoiture);
        }

        // GET: RetourVoitures/Create
        public ActionResult Create(string idContrat)
        {
            Session["idContrat"] = idContrat;
            if (idContrat == "" || idContrat == null) return RedirectToAction("Index", "Reservations");
            return View();
        }

        // POST: RetourVoitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RetourVoiture retourVoiture)
        {
            //  retourVoiture.amende = retourVoiture.pinalise ? retourVoiture.amende : 0;
            retourVoiture.idContrat = Convert.ToInt32(Session["idContrat"]);
            if (ModelState.IsValid)
            {
                var reser = db.reservations.Find(retourVoiture.idContrat);
                if (reser == null) return RedirectToAction("Index");
                reser.doesCarReturned = true;
                db.reservations.AddOrUpdate(reser);
                var voi = reser.voiture;
                voi.disponible = true;
                db.Voitures.AddOrUpdate(voi);
                db.RetourVoitures.Add(retourVoiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(retourVoiture);
        }

        // GET: RetourVoitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetourVoiture retourVoiture = db.RetourVoitures.Find(id);
            if (retourVoiture == null)
            {
                return HttpNotFound();
            }
            return View(retourVoiture);
        }

        // POST: RetourVoitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RetourVoiture retourVoiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retourVoiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(retourVoiture);
        }

        // GET: RetourVoitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetourVoiture retourVoiture = db.RetourVoitures.Find(id);
            if (retourVoiture == null)
            {
                return HttpNotFound();
            }
            db.RetourVoitures.Remove(retourVoiture);
            db.SaveChanges();
            return RedirectToAction("Index");
            // return View(retourVoiture);
        }

        // POST: RetourVoitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RetourVoiture retourVoiture = db.RetourVoitures.Find(id);
            db.RetourVoitures.Remove(retourVoiture);
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
