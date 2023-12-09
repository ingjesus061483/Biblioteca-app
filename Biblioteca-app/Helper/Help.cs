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
        public HtmlToPdf GetHtmlToPdf( PdfPageSize pageSize, PdfPageOrientation pdfOrientation,
                                   int webPageWidth)
        {
            HtmlToPdf htmlToPdf = new HtmlToPdf();
            htmlToPdf.Options.PdfPageSize = pageSize;
            htmlToPdf.Options.PdfPageOrientation = pdfOrientation;
            htmlToPdf.Options.WebPageWidth = webPageWidth;
            return htmlToPdf;
        }
        public byte[] ConvertPdfToByte(string html, HtmlToPdf htmlToPdf)        
        {         
            PdfDocument pdfDocument = htmlToPdf.ConvertHtmlString(html);
            byte[] bytes = pdfDocument.Save();
            pdfDocument.Close();
            return bytes;
        }
        public abstract void Guardar(FormCollection collection);
        public abstract void Actualizar(int id,FormCollection collection);
        public abstract void Eliminar(int id);


    }
}