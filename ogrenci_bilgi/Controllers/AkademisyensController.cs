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
    public class AkademisyensController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Akademisyens
        public ActionResult Index()
        {
            return View(db.Akademisyen.ToList());
        }

        // GET: Akademisyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Akademisyen akademisyen = db.Akademisyen.Find(id);
            if (akademisyen == null)
            {
                return HttpNotFound();
            }
            return View(akademisyen);
        }

        // GET: Akademisyens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Akademisyens/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AkdId,AkdAd,AkdSoyad,AkdBolum")] Akademisyen akademisyen)
        {
            if (ModelState.IsValid)
            {
                db.Akademisyen.Add(akademisyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(akademisyen);
        }

        // GET: Akademisyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Akademisyen akademisyen = db.Akademisyen.Find(id);
            if (akademisyen == null)
            {
                return HttpNotFound();
            }
            return View(akademisyen);
        }

        // POST: Akademisyens/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AkdId,AkdAd,AkdSoyad,AkdBolum")] Akademisyen akademisyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(akademisyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(akademisyen);
        }

        // GET: Akademisyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Akademisyen akademisyen = db.Akademisyen.Find(id);
            if (akademisyen == null)
            {
                return HttpNotFound();
            }
            return View(akademisyen);
        }

        // POST: Akademisyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Akademisyen akademisyen = db.Akademisyen.Find(id);
            db.Akademisyen.Remove(akademisyen);
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
