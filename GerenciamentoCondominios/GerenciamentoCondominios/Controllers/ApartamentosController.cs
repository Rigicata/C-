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
    public class ApartamentosController : Controller
    {
        private GerenciamentoCondominiosContext db = new GerenciamentoCondominiosContext();

        // GET: Apartamentos
        public ActionResult Index()
        {
            var apartamentoes = db.Apartamentoes.Include(a => a.Bloco);
            return View(apartamentoes.ToList());
        }

        // GET: Apartamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartamento apartamento = db.Apartamentoes.Find(id);
            if (apartamento == null)
            {
                return HttpNotFound();
            }
            return View(apartamento);
        }

        // GET: Apartamentos/Create
        public ActionResult Create()
        {
            ViewBag.Fk_Bloco = new SelectList(db.Blocoes, "BlocoId", "Numero");
            return View();
        }

        // POST: Apartamentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pk_Apartamento,NomeDono,Andar,Fk_Bloco")] Apartamento apartamento)
        {
            if (ModelState.IsValid)
            {
                db.Apartamentoes.Add(apartamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fk_Bloco = new SelectList(db.Blocoes, "BlocoId", "Numero", apartamento.Fk_Bloco);
            return View(apartamento);
        }

        // GET: Apartamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartamento apartamento = db.Apartamentoes.Find(id);
            if (apartamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_Bloco = new SelectList(db.Blocoes, "BlocoId", "Numero", apartamento.Fk_Bloco);
            return View(apartamento);
        }

        // POST: Apartamentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pk_Apartamento,NomeDono,Andar,Fk_Bloco")] Apartamento apartamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Bloco = new SelectList(db.Blocoes, "BlocoId", "Numero", apartamento.Fk_Bloco);
            return View(apartamento);
        }

        // GET: Apartamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartamento apartamento = db.Apartamentoes.Find(id);
            if (apartamento == null)
            {
                return HttpNotFound();
            }
            return View(apartamento);
        }

        // POST: Apartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apartamento apartamento = db.Apartamentoes.Find(id);
            db.Apartamentoes.Remove(apartamento);
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
