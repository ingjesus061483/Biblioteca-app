using Conexion;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca_app.Helper
{
    /// <summary>
    /// Repositorio de libros
    /// </summary>
    public class LibroHelp : Help
    {
        /// <summary>
        /// obtiene o establece un objeto de la classe libro
        /// </summary>
        public IQueryable<Libro> QueryLibro 
        {
            get
            {
                return _context.Libros.AsQueryable();
            } 
        }

     

        /// <summary>
        /// obtiene un query para ejecutar en la base de datos
        /// </summary>
              
        public IQueryable<LibroDTO> QuerylibrosDTO
        {
            get
            {
                return _context.Libros.Include("Autors").
                                       Select(x => new LibroDTO
                                       {
                                           Id = x.Id,
                                           Titulo = x.Titulo,
                                           Sintesis = x.Sintesis,
                                           Autor = x.Autor,
                                           NumeroPagina = x.NumeroPagina
                                       });            
            }            
        }
        public LibroHelp(BibliotecaDbContext context )
        {
            _context = context;
        }
        /// <summary>
        /// options de autores
        /// </summary>
        /// <returns></returns>
        public SelectList GetSelectList()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            try
            {
                foreach (Autor row in Autors)
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
        /// <summary>
        /// Obtiene un libro por clave primaria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Libro GetLibro(int? id)
        {
            return _context.Libros.Find(id);
        }
        /// <summary>
        /// Actualiza un registro de libros
        /// </summary>
        public override void Actualizar(int id,FormCollection collection )
        {
            var  Libro = QueryLibro .Where (x=>x.Id==id).FirstOrDefault();
            Libro .Titulo = collection["Titulo"];
            Libro .Sintesis =collection["sintesis"];
            Libro .NumeroPagina =int.Parse( collection["NumeroPagina"]);
            _context.SaveChanges();
        }
        /// <summary>
        /// Eliminar un registro de libro
        /// </summary>

        public override void Eliminar(int id)
        {
            var Libro = QueryLibro.Where(x=>x.Id==id).FirstOrDefault();
            _context.Libros.Remove(Libro );
            _context.SaveChanges();
            
        }
        /// <summary>
        /// Inserta un registro de libro
        /// </summary>
        public override void Guardar(FormCollection collection )
        {
           var Libro = new Libro
            {
                Titulo = collection["Titulo"],
                Sintesis = collection["sintesis"],
                NumeroPagina = int.Parse(collection["NumeroPagina"]),
                AutorId=int .Parse (collection["AutorId"])
            };
            _context.Libros.Add(Libro);
            _context.SaveChanges();
        }
    }
}