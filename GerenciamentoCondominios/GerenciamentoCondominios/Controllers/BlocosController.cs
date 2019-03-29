using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciamentoCondominios.Models;

namespace GerenciamentoCondominios.Controllers
{
    public class BlocosController : Controller
    {
        private GerenciamentoCondominiosContext db = new GerenciamentoCondominiosContext();

        // GET: Blocos
        public ActionResult Index()
        {
            return View(db.Blocoes.ToList());
        }

        // GET: Blocos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocoes.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        // GET: Blocos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blocos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlocoId,Numero,Taxa")] Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                db.Blocoes.Add(bloco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloco);
        }

        // GET: Blocos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocoes.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        // POST: Blocos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlocoId,Numero,Taxa")] Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloco);
        }

        // GET: Blocos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocoes.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        // POST: Blocos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bloco bloco = db.Blocoes.Find(id);
            db.Blocoes.Remove(bloco);
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
