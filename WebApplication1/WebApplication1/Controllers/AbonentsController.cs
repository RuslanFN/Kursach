using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Dal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AbonentsController : Controller
    {
        private TelComContext db = new TelComContext();

        // GET: Abonents
        public ActionResult Index()
        {
            return View(db.Abonents.ToList());
        }

        // GET: Abonents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonent abonent = db.Abonents.Find(id);
            if (abonent == null)
            {
                return HttpNotFound();
            }
            return View(abonent);
        }

        // GET: Abonents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abonents/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,INN,TelDot,schet")] Abonent abonent)
        {
            if (ModelState.IsValid)
            {
                db.Abonents.Add(abonent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abonent);
        }

        // GET: Abonents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonent abonent = db.Abonents.Find(id);
            if (abonent == null)
            {
                return HttpNotFound();
            }
            return View(abonent);
        }

        // POST: Abonents/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,INN,TelDot,schet")] Abonent abonent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abonent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abonent);
        }

        // GET: Abonents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abonent abonent = db.Abonents.Find(id);
            if (abonent == null)
            {
                return HttpNotFound();
            }
            return View(abonent);
        }

        // POST: Abonents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abonent abonent = db.Abonents.Find(id);
            db.Abonents.Remove(abonent);
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
