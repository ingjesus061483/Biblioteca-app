using Biblioteca_app.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Biblioteca_app.Controllers
{
    public class LibroController : Controller
    {    
        readonly LibroHelp  _libroHelp;
        public LibroController(LibroHelp libroHelp  )
        {
            _libroHelp =libroHelp ;
        }
        
        // GET: Libro
        public ActionResult Index()
        {
            List<LibroDTO> libros = new List<LibroDTO>();

            try
            {
                int.TryParse(Request["Autor"], out int autorId);
                SelectList autors =_libroHelp.GetSelectList();
                libros = autorId != 0 ?_libroHelp .Querylibros.Where(x=>x.Autor .Id==autorId ).ToList(): 
                                       _libroHelp.Querylibros.ToList();         
                ViewBag.autors = autors;
                return View(libros);
            }
            catch(Exception ex)
            {
                ViewBag.ex = ex;
                return View("Error");
            }
        }
        // GET: Libro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            try
            {
                SelectList autors = _libroHelp.GetSelectList();
                ViewBag.autors = autors;
                return View();
            }
            catch( Exception ex)
            {
                ViewBag.ex = ex;
                return View("Error");
            }
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Create(FormCollection  libro)
        {            
            try
            {
                // TODO: Add insert logic here                
                _libroHelp.Guardar(libro);
                TempData["msg"] = "El libro se ha creado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {                
                return RedirectToAction("Index");
            }
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                SelectList autors =_libroHelp. GetSelectList();
                ViewBag.autors = autors;
                Libro libro = _libroHelp.GetLibro(id);
                if(libro==null)
                {             
                    return HttpNotFound();
                }
                return View(libro);
            }
            catch
            {                
                return RedirectToAction("Index");
            }

        }

        // POST: Libro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection  libro )
        {
            try
            {
                // TODO: Add update logic here                
                
                _libroHelp.Actualizar(id, libro);
                TempData["msg"] = "El libro se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.ex = ex;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here            
                _libroHelp.Eliminar(id);
                TempData["msg"] = "El libro se ha eliminado correctamente";

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.ex = ex;
                return View("Error");
            }
        }
    }
}
