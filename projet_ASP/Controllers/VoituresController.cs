using Microsoft.AspNet.Identity;
using projet_ASP.Models;
using System;
using System.Collections.Generic;
using System.Collections;
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

        public bool DateGt(DateTime a, DateTime b)
        {
            int result = DateTime.Compare(a, b);
            if (result < 0)
                return false;
            else if (result == 0)
                return true;
            else
                return true;
        }

       
        [HttpPost]
        public ActionResult filter(FormCollection data)
        {
        
            bool debutTest = false, finTest = false;
            if(data["startdate"]==null && data["enddate"] ==null) RedirectToAction("Index");
            DateTime debut = (data["startdate"]!=null&& data["startdate"]!="")? DateTime.Parse(data["startdate"]): DateTime.Now;
            debutTest = (data["startdate"]!=null&& data["startdate"]!="")? true: false;
            DateTime fin = (data["enddate"] !=null&& data["enddate"] !="")? DateTime.Parse(data["enddate"]): DateTime.Now.AddYears(5);
            finTest = (data["enddate"] !=null&& data["enddate"] !="") ? true : false;
            string ville = data["Ville"]==null? "": data["Ville"];
            int min=0;//= data["min"] == null ? 0 : Convert.ToInt32(data["min"]);
            int max=20000;// = data["max"] == null ? 90000 : Convert.ToInt32(data["max"]);
            if (data["min"] != null && data["min"] != "" ) min = Convert.ToInt32(data["min"]);
            if (data["max"] != null && data["max"] != "") max = Convert.ToInt32(data["max"]);
            Console.WriteLine("min " + min + "max " + max);
;            List<Voiture> voi=new List<Voiture>();
            List<Reservation> searchResv = new List<Reservation>();
            foreach (var r in db.reservations.ToList())
            {
                if (r.dateDebut.Date >= debut.Date && r.dateFin.Date <= fin.Date) searchResv.Add(r); 
            }
            List<int> idVoituresNonDispo = searchResv.Select(a => a.idVoiture).ToList();
      /*      foreach (var v in db.Voitures.ToList())
            {
                if (((Convert.ToInt32(v.coutParJour) <= max && Convert.ToInt32(v.coutParJour) >= min) && v.proprietaire.ApplicationUser.adresse.ToLower().Contains(ville.ToLower()))
                       &&(v.disponible == true *//*|| v.reservations.Where(r => r.dateDebut < debut).Count()==0*//*))
                    voi.Add(v);
            } */
            if(!finTest && !debutTest)
            {
                foreach (var v in db.Voitures.ToList())
                {
                    if (((Convert.ToInt32(v.coutParJour) <= max && Convert.ToInt32(v.coutParJour) >= min)) && v.proprietaire.ApplicationUser.adresse.ToLower().Contains(ville.ToLower()) && v.disponible)
                        voi.Add(v);
                }

            }
            else
            {
                foreach (var v in db.Voitures.ToList())
                {
                    if (((Convert.ToInt32(v.coutParJour) <= max && Convert.ToInt32(v.coutParJour) >= min)) && !idVoituresNonDispo.Contains(v.idVoiture)
                        && v.proprietaire.ApplicationUser.adresse.ToLower().Contains(ville.ToLower()) && v.disponible)
                        voi.Add(v);
                }
            }

            /*  List<Voiture> voi  = db.Voitures
                                              .Where(v =>((Convert.ToInt32(v.coutParJour)<max && Convert.ToInt32(v.coutParJour)>min )&&v.proprietaire.ApplicationUser.adresse.Contains(ville) )&&
                                                          (v.disponible == true || v.reservations.Where(r=>r.dateDebut<=debut && r.dateFin>=fin).Count()>0 ) )
                                              .ToList<Voiture>();
            */
         
            return View("Index",  voi );
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
       // [Authorize(Roles = "Locataire")]
        public ActionResult Details(string id)
        { 
            if (id == null)
            {
                return RedirectToAction("Index"); //Content("page not found ");
            }
            Voiture voiture = db.Voitures.Include(r=>r.reservations).Where(v => v.idVoiture.ToString().Equals(id)).FirstOrDefault();
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }
        [Authorize]
        public JsonResult reserver_voiture(string carId, string userID, string debut, string fin)
        {
            if (carId == null)
            {
                return Json("car not found");
            }
            Voiture voiture = db.Voitures.Where(v => v.idVoiture.ToString().Equals(carId)).FirstOrDefault();
            Locataire locataire = db.Locataires.Where(v => v.ApplicationUserID.ToString().Equals(userID)).FirstOrDefault();
            if (voiture == null || locataire == null)
            {
                return Json("user or car not found");//RedirectToAction("Details", "Voitures", new { id = carId });
            } 
            DateTime date_debut = DateTime.Parse(debut);
            DateTime date_fin = DateTime.Parse(fin);
            Reservation reservation = new Reservation()
            {
                cout = Convert.ToInt32(voiture.coutParJour) * Convert.ToInt32(date_fin.Subtract(date_debut).TotalDays),//*nbjours
                dateReservation = DateTime.Now,
                idLocataire = locataire.idLocataire,
                idVoiture = voiture.idVoiture,
                typeDePaiement = "visa",
                dateDebut = date_debut,
                dateFin = date_fin,
            };
            db.reservations.Add(reservation);
            voiture.disponible = false;
            db.Voitures.AddOrUpdate(voiture);
            db.SaveChanges();
            return Json("OK"); 
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
                return RedirectToAction("VoituresProprietaire");
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
                return RedirectToAction("VoituresProprietaire");
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
