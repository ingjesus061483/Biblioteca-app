﻿using Biblioteca_app.Extensions;
using Biblioteca_app.Helper;
using Model;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Biblioteca_app.Controllers
{
    public class LibroController : Controller
    {    
        readonly LibroHelp  _libroHelp;
        public LibroController(LibroHelp libroHelp )
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
                libros = autorId != 0 ?_libroHelp .QuerylibrosDTO.Where(x=>x.Autor .Id==autorId ).ToList(): 
                                       _libroHelp.QuerylibrosDTO.ToList();         
                ViewBag.autors = autors;
                ViewBag.autorid = autorId;
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
                Libro libro = _libroHelp.QueryLibro.Where(x=>x.Id==id).FirstOrDefault();
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
        public ActionResult PdfReport()
        {          
            int.TryParse(Request["autorid"], out int autorId);
            List<LibroDTO> libros = autorId != 0 ? _libroHelp.QuerylibrosDTO.Where(x => x.Autor.Id == autorId).ToList() : _libroHelp.QuerylibrosDTO.ToList ();           
            string htmlString = this.RenderRazorViewToString("FormatPdf", libros );
            PdfPageSize pageSize = PdfPageSize.A4;
            PdfPageOrientation pdfOrientation = PdfPageOrientation.Portrait;
            int webPageWidth = 1500;
            HtmlToPdf htmlToPdf  = _libroHelp.GetHtmlToPdf(pageSize, pdfOrientation, webPageWidth);
            byte[] pdf =_libroHelp.ConvertPdfToByte (htmlString ,htmlToPdf );
            return File(pdf, "application/pdf");
        }

    }
}
