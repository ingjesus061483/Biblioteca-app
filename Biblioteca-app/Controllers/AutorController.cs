using Conexion;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca_app.Controllers
{
    public class AutorController : Controller
    {
        readonly  BibliotecaDbContext _context;
        public AutorController(BibliotecaDbContext context )
        {
            _context = context;
        }
        // GET: Autor
        public ActionResult Index()
        {
            List<Autor> autors = new List<Autor>();
            try
            {
                autors = _context.Autors.ToList();
                return View(autors);
            }
            catch
            {
                return View(autors);
            }
        }

        /* GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }*/

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        public ActionResult Create(Autor  autor)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Autors.Add(autor);
                _context.SaveChanges();
                TempData["msg"] = "El autor se ha creado correctamente";
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int? id)
        {
            Autor autor = _context.Autors.Find(id);
            if (autor == null)
            {
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        // POST: Autor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Autor autor)
        {
            try
            {
                // TODO: Add update logic here
                Autor autorfind = _context.Autors.Find(id);
                autorfind.Nombre = autor.Nombre;
                autorfind.Apellido = autor.Apellido;
                _context.SaveChanges();
                TempData["msg"] = "El autor se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // POST: Autor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Autor autor = _context.Autors.Find(id);
                _context.Autors.Remove(autor);
                _context.SaveChanges();
                TempData["msg"] = "El autor se ha eliminado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
