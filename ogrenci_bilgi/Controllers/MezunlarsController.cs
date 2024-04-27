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
    public class MezunlarsController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Mezunlars
        public ActionResult Index()
        {
            return View(db.Mezunlar.ToList());
        }

        // GET: Mezunlars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // GET: Mezunlars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mezunlars/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MezunId,MezunAd,MezunSoyad,MezunBolum")] Mezunlar mezunlar)
        {
            if (ModelState.IsValid)
            {
                db.Mezunlar.Add(mezunlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mezunlar);
        }

        // GET: Mezunlars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // POST: Mezunlars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MezunId,MezunAd,MezunSoyad,MezunBolum")] Mezunlar mezunlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mezunlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mezunlar);
        }

        // GET: Mezunlars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // POST: Mezunlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            db.Mezunlar.Remove(mezunlar);
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
