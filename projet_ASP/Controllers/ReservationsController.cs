using Microsoft.AspNet.Identity;
using projet_ASP.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace projet_ASP.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Reservations
        // [Authorize(Roles ="Locataire")]
        public ActionResult Index(string id = "")
        {

            string userid = User.Identity.GetUserId();
            if (User.IsInRole("Locataire"))
            {
                return View(db.reservations.Include(r => r.voiture)
                                           .Where(r => r.locataire.ApplicationUserID.Equals(userid)).OrderByDescending(r => r.dateReservation)
                                           .ToList());
            }
            else if (User.IsInRole("Proprietaire"))
            {
                return View(db.reservations.Include(r => r.voiture)
                                           .Where(r => r.voiture.proprietaire.ApplicationUserID.Equals(userid))
                                           .ToList());
            }
            else
            {
                var user = db.Users.Find(id).Roles.FirstOrDefault();
                if (user == null) return RedirectToAction("Propietaires", "Administrateur");

                string roleid = user.RoleId;
                if (roleid == null) return RedirectToAction("Propietaires", "Administrateur");

                if (roleid == "2")
                { //propr
                    return View(db.reservations.Include(r => r.voiture)
                                          .Where(r => r.voiture.proprietaire.ApplicationUserID.Equals(id))
                                          .ToList());
                }
                else
                {
                    if (id == "") return RedirectToAction("Locataires", "Administrateur");
                    return View(db.reservations.Include(r => r.voiture)
                                               .Where(r => r.locataire.ApplicationUserID.Equals(id)).OrderByDescending(r => r.dateReservation)
                                               .ToList());
                }


            }
        }
        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }
        // GET: Reservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idContrat,dateReservation,dateDebut,dateFin,typeDePaiement,cout,idVoiture,idLocataire")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idContrat,dateReservation,dateDebut,dateFin,typeDePaiement,cout,idVoiture,idLocataire")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.reservations.Find(id);
            db.reservations.Remove(reservation);
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
