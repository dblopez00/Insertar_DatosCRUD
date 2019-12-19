using CRUD_Curso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Curso.Controllers
{
    public class CursosController : Controller
    {
        // GET: Cursos
        public ActionResult Index()
        {
            try
            {
                using (var db = new Cursos_CRUDEntities())
                {
                    return View(db.Alumnos.ToList());
                }
            }
            catch(Exception)
            {

            }
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Alumnos a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new Cursos_CRUDEntities())
                {
                    db.Alumnos.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error al crear", ex);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new Cursos_CRUDEntities())
            {
                //Alumnos al = db.Alumnos.Where(a => a.id_alumno == id).FirstOrDefault();
                Alumnos al2 = db.Alumnos.Find(id);
                return View(al2);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alumnos a)
        {
            try
            {
                using (var db = new Cursos_CRUDEntities())
                {
                    Alumnos al2 = db.Alumnos.Find(a.id_alumno);
                    al2.Nombres = a.Nombres;
                    al2.Apellidos = a.Apellidos;
                    al2.Sexo = a.Sexo;
                    al2.Edad = a.Edad;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

            }
            return View();
        }

        public ActionResult Details(int id)
        {
            using (var db = new Cursos_CRUDEntities())
            {
                Alumnos al = db.Alumnos.Find(id);
                return View(al);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new Cursos_CRUDEntities())
            {
                Alumnos al = db.Alumnos.Find(id);
                db.Alumnos.Remove(al);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}