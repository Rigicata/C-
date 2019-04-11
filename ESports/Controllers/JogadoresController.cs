using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESports.Models;

namespace ESports.Controllers
{
    public class JogadoresController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Jogadores
        public ActionResult Index()
        {
            var jogadorSet = db.JogadorSet.Include(j => j.Time);
            return View(jogadorSet.ToList());
        }

        // GET: Jogadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = db.JogadorSet.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        // GET: Jogadores/Create
        public ActionResult Create()
        {
            ViewBag.TimeId = new SelectList(db.TimeSet, "Id", "Nome");
            return View();
        }

        // POST: Jogadores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Elo,Lane,TimeId")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                db.JogadorSet.Add(jogador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeId = new SelectList(db.TimeSet, "Id", "Nome", jogador.TimeId);
            return View(jogador);
        }

        // GET: Jogadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = db.JogadorSet.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            ViewBag.TimeId = new SelectList(db.TimeSet, "Id", "Nome", jogador.TimeId);
            return View(jogador);
        }

        // POST: Jogadores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Elo,Lane,TimeId")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TimeId = new SelectList(db.TimeSet, "Id", "Nome", jogador.TimeId);
            return View(jogador);
        }

        // GET: Jogadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = db.JogadorSet.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        // POST: Jogadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogador jogador = db.JogadorSet.Find(id);
            db.JogadorSet.Remove(jogador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



      // GET: Jogadores/Edit/5
      public ActionResult EscolhaTime()
      {
       
       
         ViewBag.TimeId = new SelectList(db.TimeSet, "Id", "Nome");
         ViewBag.Id = new SelectList(db.JogadorSet, "Id", "Nome");
         return View();
      }

      // POST: Jogadores/Edit/5
      // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
      // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult EscolhaTime([Bind(Include = "Id,Nome,Elo,Lane,TimeId")] Jogador jogador)
      {
         if (ModelState.IsValid)
         {
            db.Entry(jogador).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
         }
         ViewBag.TimeId = new SelectList(db.TimeSet, "Id", "Nome", jogador.TimeId);
         return View(jogador);
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
