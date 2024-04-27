using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ogrenci_bilgi.Models;

namespace ogrenci_bilgi.Controllers
{
    public class idaresController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: idares
        public ActionResult Index()
        {
            return View(db.idare.ToList());
        }

        // GET: idares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idare idare = db.idare.Find(id);
            if (idare == null)
            {
                return HttpNotFound();
            }
            return View(idare);
        }

        // GET: idares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: idares/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdariId,IdariBirimAd,IdariAd")] idare idare)
        {
            if (ModelState.IsValid)
            {
                db.idare.Add(idare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idare);
        }

        // GET: idares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idare idare = db.idare.Find(id);
            if (idare == null)
            {
                return HttpNotFound();
            }
            return View(idare);
        }

        // POST: idares/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdariId,IdariBirimAd,IdariAd")] idare idare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idare);
        }

        // GET: idares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idare idare = db.idare.Find(id);
            if (idare == null)
            {
                return HttpNotFound();
            }
            return View(idare);
        }

        // POST: idares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            idare idare = db.idare.Find(id);
            db.idare.Remove(idare);
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
