using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiarioJulia;

namespace DiarioJulia.Controllers
{
    public class MelhoriasController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Melhorias
        public ActionResult Index()
        {
            return View(db.MelhoriaSet.ToList());
        }

        // GET: Melhorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melhoria melhoria = db.MelhoriaSet.Find(id);
            if (melhoria == null)
            {
                return HttpNotFound();
            }
            return View(melhoria);
        }

        // GET: Melhorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Melhorias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Texto,Possivel")] Melhoria melhoria)
        {
            if (ModelState.IsValid)
            {
                db.MelhoriaSet.Add(melhoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(melhoria);
        }

        // GET: Melhorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melhoria melhoria = db.MelhoriaSet.Find(id);
            if (melhoria == null)
            {
                return HttpNotFound();
            }
            return View(melhoria);
        }

        // POST: Melhorias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Texto,Possivel")] Melhoria melhoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(melhoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(melhoria);
        }

        // GET: Melhorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melhoria melhoria = db.MelhoriaSet.Find(id);
            if (melhoria == null)
            {
                return HttpNotFound();
            }
            return View(melhoria);
        }

        // POST: Melhorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Melhoria melhoria = db.MelhoriaSet.Find(id);
            db.MelhoriaSet.Remove(melhoria);
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
