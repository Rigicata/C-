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
    public class Registro_PersonagensController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Registro_Personagens
        public ActionResult Index()
        {
            var registro_PersonagemSet = db.Registro_PersonagemSet.Include(r => r.Personagem).Include(r => r.Registro);
            return View(registro_PersonagemSet.ToList());
        }

        // GET: Registro_Personagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Personagem registro_Personagem = db.Registro_PersonagemSet.Find(id);
            if (registro_Personagem == null)
            {
                return HttpNotFound();
            }
            return View(registro_Personagem);
        }

        // GET: Registro_Personagens/Create
        public ActionResult Create()
        {
            ViewBag.PersonagemId = new SelectList(db.PersonagemSet, "Id", "GrauParentesco");
            ViewBag.RegistroId = new SelectList(db.RegistroSet, "Id", "Data");
            return View();
        }

        // POST: Registro_Personagens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonagemId,RegistroId")] Registro_Personagem registro_Personagem)
        {
            if (ModelState.IsValid)
            {
                db.Registro_PersonagemSet.Add(registro_Personagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonagemId = new SelectList(db.PersonagemSet, "Id", "GrauParentesco", registro_Personagem.PersonagemId);
            ViewBag.RegistroId = new SelectList(db.RegistroSet, "Id", "Data", registro_Personagem.RegistroId);
            return View(registro_Personagem);
        }

        // GET: Registro_Personagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Personagem registro_Personagem = db.Registro_PersonagemSet.Find(id);
            if (registro_Personagem == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonagemId = new SelectList(db.PersonagemSet, "Id", "GrauParentesco", registro_Personagem.PersonagemId);
            ViewBag.RegistroId = new SelectList(db.RegistroSet, "Id", "Data", registro_Personagem.RegistroId);
            return View(registro_Personagem);
        }

        // POST: Registro_Personagens/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PersonagemId,RegistroId")] Registro_Personagem registro_Personagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro_Personagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonagemId = new SelectList(db.PersonagemSet, "Id", "GrauParentesco", registro_Personagem.PersonagemId);
            ViewBag.RegistroId = new SelectList(db.RegistroSet, "Id", "Data", registro_Personagem.RegistroId);
            return View(registro_Personagem);
        }

        // GET: Registro_Personagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Personagem registro_Personagem = db.Registro_PersonagemSet.Find(id);
            if (registro_Personagem == null)
            {
                return HttpNotFound();
            }
            return View(registro_Personagem);
        }

        // POST: Registro_Personagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro_Personagem registro_Personagem = db.Registro_PersonagemSet.Find(id);
            db.Registro_PersonagemSet.Remove(registro_Personagem);
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
