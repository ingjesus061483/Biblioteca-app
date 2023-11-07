using Biblioteca_app.Helper;
using Model;
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
            catch
            {
                List<Autor> autors = new List<Autor>();
                return View(autors);
            }
        }
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
                _autorhelp.Autor = autor;             
                _autorhelp.Guardar();
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
            Autor autor = _autorhelp.GetAutor(id);
            if (autor == null)
            {
                return HttpNotFound();
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
                _autorhelp.Autorfind = _autorhelp.GetAutor(id);
                _autorhelp.Autor = autor;
                _autorhelp.Actualizar();
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
                _autorhelp.Autorfind = _autorhelp.GetAutor(id);
                if(_autorhelp.Autorfind == null)
                { 
                    HttpNotFound();
                }
                _autorhelp.Eliminar();
                TempData["msg"] = "El autor se ha eliminado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
