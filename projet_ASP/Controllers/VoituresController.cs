using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using projet_ASP.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace projet_ASP.Controllers
{
    public class VoituresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); 
        // GET: Voitures
        public ActionResult Index()
        {
            var voitures = db.Voitures.Include(v => v.proprietaire); 
            return View(voitures.ToList());
              // return Content("userid "+ db.Users.FirstOrDefault().Id + " ,role " + db.Roles.FirstOrDefault().Name);
        }

        // GET: Voitures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // GET: Voitures/Create
        public ActionResult Create()
        {
            ViewBag.idProprietaire = new SelectList(db.Proprietaires, "idProprietaire", "ApplicationUserID");
            return View();
        }

        // POST: Voitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matricule,marque,model,couleur,coutParJour,km,idProprietaire")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Voitures.Add(voiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProprietaire = new SelectList(db.Proprietaires, "idProprietaire", "ApplicationUserID", voiture.idProprietaire);
            return View(voiture);
        }

        // GET: Voitures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProprietaire = new SelectList(db.Proprietaires, "idProprietaire", "ApplicationUserID", voiture.idProprietaire);
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matricule,marque,model,couleur,coutParJour,km,idProprietaire")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProprietaire = new SelectList(db.Proprietaires, "idProprietaire", "ApplicationUserID", voiture.idProprietaire);
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Voiture voiture = db.Voitures.Find(id);
            db.Voitures.Remove(voiture);
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
