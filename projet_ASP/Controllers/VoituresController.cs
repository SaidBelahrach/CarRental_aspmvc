using Microsoft.AspNet.Identity;
using projet_ASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            string userid = User.Identity.GetUserId();
            List<Voiture> voitures = db.Voitures.Include(v => v.proprietaire).ToList();
            /*  if (User.IsInRole("Proprietaire"))
              {
                  voitures.Clear();
                  voitures.AddRange(db.Voitures.Where(v => v.proprietaire.ApplicationUserID.Equals(userid)).ToList());
              } */
            return View(voitures);
        }
        [HttpPost]
        public ActionResult Index(string key)
        {
            string userid = User.Identity.GetUserId();
            key = key.Trim();
            if (key.Length == 0) return View(db.Voitures.ToList());
            List<Voiture> voitures = db.Voitures.Where(v => v.marque.ToLower().Contains(key.ToLower()) ||
                                                          v.model.ToLower().Contains(key.ToLower()) ||
                                                          v.couleur.ToLower().Contains(key.ToLower()) ||
                                                          v.coutParJour.ToLower().Contains(key.ToLower()) ||
                                                          v.proprietaire.ApplicationUser.nomComplet.ToLower().Contains(key.ToLower()) ||
                                                          v.proprietaire.ApplicationUser.adresse.ToLower().Contains(key.ToLower()) ||
                                                          v.proprietaire.ApplicationUser.PhoneNumber.ToLower().Contains(key.ToLower())
                                                       )
                                                .ToList();
            return View(voitures);
        }
        //les voitures de propritaire actuel
        public ActionResult VoituresProprietaire()
        {
            if (User.IsInRole("Proprietaire"))
            {
                string userid = User.Identity.GetUserId();
                List<Voiture> voitures = db.Voitures.Where(v => v.proprietaire.ApplicationUserID.Equals(userid)).ToList();
                return View(voitures);
            }
            return RedirectToAction("Index");
        }

        // GET: Voitures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Where(v => v.idVoiture.ToString().Equals(id)).FirstOrDefault();
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }
        [Authorize(Roles = "Proprietaire")]
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

            String userId = User.Identity.GetUserId();
            ApplicationDbContext db = new ApplicationDbContext();
            var prop = db.Proprietaires.Where(item => item.ApplicationUserID == userId).FirstOrDefault();
            Voiture v = new Voiture()
            {
                matricule = data["matricule"],
                marque = data["marque"],
                automatique = data["automatique"] == "auto" ? true : false,
                couleur = data["couleur"],
                model = data["model"],
                nbPlaces = Convert.ToInt32(data["nbPlaces"]),
                idProprietaire = prop.idProprietaire,// db.Proprietaires.FirstOrDefault().idProprietaire,
                disponible = true,
                coutParJour = data["coutParJour"],
            };
            v.image = new byte[file.ContentLength];
            file.InputStream.Read(v.image, 0, file.ContentLength);
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
            Voiture car = db.Voitures.Where(v => v.idVoiture.ToString().Equals(id)).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProprietaire = new SelectList(db.Proprietaires, "idProprietaire", "type", car.idProprietaire);
            return View(car);
        }

        // POST: Voitures/Edit/id 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Voiture voiture, HttpPostedFileBase file)
        {
            Voiture oldcar = db.Voitures.Where(v => v.idVoiture.Equals(voiture.idVoiture)).FirstOrDefault();
            if (file != null)
            {
                voiture.image = new byte[file.ContentLength];
                file.InputStream.Read(voiture.image, 0, file.ContentLength);
            }
            else voiture.image = oldcar.image;
            if (ModelState.IsValid)
            {
                db.Voitures.AddOrUpdate(voiture);
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
            Voiture voiture = db.Voitures.Where(v => v.idVoiture.ToString().Equals(id)).FirstOrDefault();
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
            Voiture voiture = db.Voitures.Where(v => v.idVoiture.ToString().Equals(id)).FirstOrDefault();
            db.Voitures.Remove(voiture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET /api/cars 
        public ActionResult searchCars(string key)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var cars = db.Voitures.ToList<Voiture>();
            db.SaveChanges();
            //  return Content("fic "+key);
            return Json(cars, JsonRequestBehavior.AllowGet);
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
