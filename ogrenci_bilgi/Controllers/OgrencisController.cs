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
    public class OgrencisController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Ogrencis
        public ActionResult Index()
        {
            return View(db.Ogrenci.ToList());
        }

        // GET: Ogrencis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenci.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        // GET: Ogrencis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ogrencis/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrId,OgrAd,OgrSoyad,OgrBolum,OgrNo,OgrKredi")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Ogrenci.Add(ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenci);
        }

        // GET: Ogrencis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenci.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        // POST: Ogrencis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrId,OgrAd,OgrSoyad,OgrBolum,OgrNo,OgrKredi")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }

        // GET: Ogrencis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenci.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        // POST: Ogrencis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogrenci ogrenci = db.Ogrenci.Find(id);
            db.Ogrenci.Remove(ogrenci);
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
