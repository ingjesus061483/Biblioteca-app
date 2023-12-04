using Conexion;
using Model;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca_app.Helper
{
    public abstract class Help
    {     
        protected BibliotecaDbContext _context;
        public List<Autor> Autors
        {
            get
            {
                return _context.Autors.ToList();
            }
        }
        public byte[] Convertbypdf(string html,PdfPageSize pageSize,PdfPageOrientation pdfOrientation,int webPageWidth)
        {          
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();
            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            // converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(html);

            // save pdf document            
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();
            return pdf;
        }
        public abstract void Guardar(FormCollection collection);
        public abstract void Actualizar(int id,FormCollection collection);
        public abstract void Eliminar(int id);


    }
}