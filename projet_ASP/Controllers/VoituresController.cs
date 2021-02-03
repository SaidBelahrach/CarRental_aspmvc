using projet_ASP.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
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
        }

        // GET: Voitures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Where(v => v.matricule.Equals(id)).FirstOrDefault();
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // GET: Voitures/Create
        public ActionResult Create()
        {
            ViewBag.idProprietaire = new SelectList(db.Proprietaires, "idProprietaire", "type");
            return View();
        }

        // POST: Voitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection data, HttpPostedFileBase file)
        {
            /* 
             var fileName = Path.GetFileName(file.FileName);
             // store the file inside ~/App_Data/uploads folder
             var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
             file.SaveAs(path);*/
            //  return Content("innnnnn "+ data["marque"]+" -  "+ data["couleur"] + " -  " + data["model"] + " -  " + data["nbPlaces"] + " -  " + data["matricule"] + " -  " + data["coutParJour"]);
            Voiture v = new Voiture()
            {
                matricule = data["matricule"],
                marque = data["marque"],
                automatique = data["automatique"] == "auto" ? true : false,
                couleur = data["couleur"],
                model = data["model"],
                nbPlaces = Convert.ToInt32(data["nbPlaces"]),
                idProprietaire = db.Proprietaires.FirstOrDefault().idProprietaire,
                disponible = true,
                coutParJour = Convert.ToDecimal(data["coutParJour"]),
            };
            v.image = new byte[file.ContentLength];
            file.InputStream.Read(v.image, 0, file.ContentLength);
            /*           db.Voitures.Add(v);



                  db.SaveChanges();
                */
            if (ModelState.IsValid)
            {
                db.Voitures.Add(v);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Voitures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Where(v => v.matricule.Equals(id)).FirstOrDefault();
            if (voiture == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProprietaire = new SelectList(db.Proprietaires, "idProprietaire", "type", voiture.idProprietaire);
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matricule,marque,model,couleur,nbPlaces,automatique,coutParJour,disponible,imagePath,idProprietaire")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProprietaire = new SelectList(db.Proprietaires, "idProprietaire", "type", voiture.idProprietaire);
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Where(v => v.matricule.Equals(id)).FirstOrDefault();
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
            Voiture voiture = db.Voitures.Where(v => v.matricule.Equals(id)).FirstOrDefault();
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
