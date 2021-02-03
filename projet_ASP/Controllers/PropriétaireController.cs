using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projet_ASP.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace projet_ASP.Controllers
{
    public class PropriétaireController : Controller
    {
        // GET: Propriétaire
        public ActionResult Index()
        {
            String userId = User.Identity.GetUserId();
            ApplicationDbContext db = new ApplicationDbContext();
            var prop = db.Proprietaires.Where(item => item.ApplicationUserID == userId).FirstOrDefault(); 
            return View(prop);
        }

        // GET: Propriétaire/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Propriétaire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propriétaire/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Propriétaire/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Propriétaire/Edit/5
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

        // GET: Propriétaire/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Propriétaire/Delete/5
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
