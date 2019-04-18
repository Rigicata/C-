﻿using System;
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
    public class PersonagensController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Personagens
        public ActionResult Index()
        {
            return View(db.PersonagemSet.ToList());
        }

        // GET: Personagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.PersonagemSet.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // GET: Personagens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personagens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GrauParentesco,Idade,Nota,Nome")] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                db.PersonagemSet.Add(personagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personagem);
        }

        // GET: Personagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.PersonagemSet.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // POST: Personagens/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GrauParentesco,Idade,Nota,Nome")] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personagem);
        }

        // GET: Personagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.PersonagemSet.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // POST: Personagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personagem personagem = db.PersonagemSet.Find(id);
            db.PersonagemSet.Remove(personagem);
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
