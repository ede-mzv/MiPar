using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiParcialito.Models;

namespace MiParcialito.Controllers
{
    public class cursosController : Controller
    {
        private AV100520Entities db = new AV100520Entities();


        public ActionResult Index()
        {
            if (Session["IsAdmin"] != null)
            {
                if (Session["IsAdmin"].ToString() == "True")
                {
                    var cursos = db.cursos.Include(c => c.docentes);
                    return View(cursos.ToList());
                }
                else if (Session["IsAdmin"].ToString() == "False")
                {
                    return RedirectToAction("Index", "Access");
                }
                else
                {
                    return RedirectToAction("AccessDenied", "Home");
                }
            }
            else
            {

                return RedirectToAction("Index", "Access");
            }
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cursos cursos = db.cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }


        public ActionResult Create()
        {
            ViewBag.idDocente = new SelectList(db.docentes, "idDocente", "nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cursoID,nombreCurso,idDocente")] cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDocente = new SelectList(db.docentes, "idDocente", "nombre", cursos.idDocente);
            return View(cursos);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cursos cursos = db.cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDocente = new SelectList(db.docentes, "idDocente", "nombre", cursos.idDocente);
            return View(cursos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cursoID,nombreCurso,idDocente")] cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDocente = new SelectList(db.docentes, "idDocente", "nombre", cursos.idDocente);
            return View(cursos);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cursos cursos = db.cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cursos cursos = db.cursos.Find(id);
            db.cursos.Remove(cursos);
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
