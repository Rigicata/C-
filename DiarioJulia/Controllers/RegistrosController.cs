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
    public class RegistrosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Registros
        public ActionResult Index()
        {
            var registroSet = db.RegistroSet.Include(r => r.Local);
            return View(registroSet.ToList());
        }

        // GET: Registros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.RegistroSet.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: Registros/Create
        public ActionResult Create()
        {
            ViewBag.LocalId = new SelectList(db.LocalSet, "Id", "Nome");
            ViewBag.PersonagemId = new SelectList(db.PersonagemSet, "Id", "Nome");

         return View();
        }

        // POST: Registros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,Titulo,Classificacao,Conteudo,LocalId")] Registro registro,List<int> PersonagemID)// Pegando a lista de ids que vem da tela
        {
            if (ModelState.IsValid)
            {
                db.RegistroSet.Add(registro);
                db.SaveChanges();
                foreach(var idPersonagem in PersonagemID){
               Registro_Personagem rp = new Registro_Personagem();
               rp.RegistroId = registro.Id; //Pegando o id do registro dessa tela e adicionando ao id do registro_persoganem
               rp.PersonagemId = idPersonagem; //Pegando a variável idPersonagem e que está carregada com a lista que veio da tela por meio do list e adicionando ao id_personagem da tabela registro_personagem
               db.Registro_PersonagemSet.Add(rp); //Adicionando ao banco de dados





            }
            db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalId = new SelectList(db.LocalSet, "Id", "Nome", registro.LocalId);
            return View(registro);
        }

        // GET: Registros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.RegistroSet.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalId = new SelectList(db.LocalSet, "Id", "Nome", registro.LocalId);
            return View(registro);
        }

        // POST: Registros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Titulo,Classificacao,Conteudo,LocalId")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalId = new SelectList(db.LocalSet, "Id", "Nome", registro.LocalId);
            return View(registro);
        }

        // GET: Registros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.RegistroSet.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro registro = db.RegistroSet.Find(id);
            db.RegistroSet.Remove(registro);
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
