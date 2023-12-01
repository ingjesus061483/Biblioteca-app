using Biblioteca_app.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
namespace Biblioteca_app.Controllers
{
    public class AutorController : Controller
    {
        readonly  AutorHelp _autorhelp;
        public AutorController(AutorHelp autorHelp )
        {
            _autorhelp = autorHelp;
        }
        // GET: Autor
        public ActionResult Index()
        {            
            try
            {
               
                return View(_autorhelp.Autors);
            }
            catch(Exception ex)
            {
                ViewBag.ex = ex;
                return View("Error");
            }
        }
        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        public ActionResult Create(FormCollection autor)
        {
            try
            { 
                // TODO: Add insert logic here
                
                _autorhelp.Guardar(autor);
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
            try
            {
                Autor autor = _autorhelp.GetAutor(id);
                if (autor == null)
                {
                    return HttpNotFound();
                }
                return View(autor);
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }

        // POST: Autor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection autor)
        {
            try
            {
                // TODO: Add update logic here
        
        
                _autorhelp.Actualizar(id ,autor);
                TempData["msg"] = "El autor se ha editado correctamente";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.ex = ex;
                return View("Error");
            }
        }
        // POST: Autor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                
                _autorhelp.Eliminar(id);
                TempData["msg"] = "El autor se ha eliminado correctamente";
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
