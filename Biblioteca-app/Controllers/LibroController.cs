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
            catch
            {
               
                return View(libros  );
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
            SelectList  autors =_libroHelp. GetSelectList( );
            ViewBag.autors = autors;
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Create(Libro libro)
        {            
            try
            {
                // TODO: Add insert logic here
                _libroHelp.Libro =libro;
                _libroHelp.Guardar();
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
        public ActionResult Edit(int id, Libro libro )
        {
            try
            {
                // TODO: Add update logic here
                _libroHelp.Find = _libroHelp.GetLibro(id);
                _libroHelp.Libro = libro;
                if (_libroHelp.Find == null)
                {
                    return HttpNotFound();
                }
                _libroHelp.Actualizar();
                TempData["msg"] = "El libro se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _libroHelp .Find = _libroHelp.GetLibro(id );
                if (_libroHelp.Find == null)
                {
                    return HttpNotFound();
                }
                _libroHelp.Eliminar();
                TempData["msg"] = "El libro se ha eliminado correctamente";

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
