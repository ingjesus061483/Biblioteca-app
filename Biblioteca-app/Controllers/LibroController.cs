using Conexion;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca_app.Controllers
{
    public class LibroController : Controller
    {    
        readonly  BibliotecaDbContext _context;
        public LibroController(BibliotecaDbContext context)
        {
            _context =context;
        }
        IQueryable<LibroDTO> GetLibros(int autor)
        {
            return autor != 0 ? _context.Libros.Include("Autors").Where(x => x.AutorId == autor).
            Select(x => new LibroDTO
            {
                Id = x.Id,
                Titulo = x.Titulo,
                sintesis = x.sintesis,
                Autor = x.Autor,
                NumeroPagina = x.NumeroPagina
            }) :
            _context.Libros.Include("Autors").
            Select(x => new LibroDTO
            {
                Id = x.Id,
                Titulo = x.Titulo,
                sintesis = x.sintesis,
                Autor = x.Autor,
                NumeroPagina = x.NumeroPagina
            });
        }
        public static SelectList GetSelectList(List<Autor> table)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            try
            {
                foreach (Autor row in table)
                {
                    SelectListItem item = new SelectListItem                    
                    {
                        Text = row.NombreCompleto,
                        Value = row.Id.ToString(),
                    };
                    result.Add(item);              
                }
            }
            catch
            {
                result = new List<SelectListItem>();
            }

            return new SelectList(result, "Value", "Text");
        }

        // GET: Libro
        public ActionResult Index()
        {
            List<LibroDTO> libros = new List<LibroDTO>();
            try
            {
                int.TryParse(Request["Autor"], out int autorId);
                SelectList autors = GetSelectList(_context.Autors.ToList());
                libros = GetLibros(autorId).ToList();         
                ViewBag.autors = autors;
                return View(libros);
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
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
            SelectList  autors = GetSelectList( _context.Autors.ToList());
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
                _context.Libros.Add(libro);
                _context.SaveChanges();
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
                SelectList autors = GetSelectList(_context.Autors.ToList());
                ViewBag.autors = autors;
                Libro libro = _context.Libros.Find(id);
                if(libro==null)
                {             
                    return RedirectToAction("Index");
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
        public ActionResult Edit(int id, Libro libroUp )
        {
            try
            {
                // TODO: Add update logic here
                Libro libro = _context.Libros.Find(id);
                libro.Titulo = libroUp.Titulo;
                libro.sintesis = libroUp.sintesis;
                libro.NumeroPagina = libroUp.NumeroPagina;
                _context.SaveChanges();
                TempData["msg"] = "El libro se ha editado correctamente";

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return RedirectToAction("Index");
            }
        }

        /* GET: Libro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: Libro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Libro libro = _context.Libros.Find(id);
                _context.Libros.Remove(libro);
                _context.SaveChanges();
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
