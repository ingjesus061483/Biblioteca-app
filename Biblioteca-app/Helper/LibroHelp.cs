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
        public Libro Libro { get; set; }

        /// <summary>
        /// obtiene o establece un objeto de la classe libro
        /// </summary>
        public Libro Find { get; set; }

        /// <summary>
        /// obtiene un query para ejecutar en la base de datos
        /// </summary>
              
        public IQueryable<LibroDTO> Querylibros
        {
            get
            {
                return _context.Libros.Include("Autors").
                                       Select(x => new LibroDTO
                                       {
                                           Id = x.Id,
                                           Titulo = x.Titulo,
                                           sintesis = x.sintesis,
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
            return _context.Libros .Find(id);
        }
        /// <summary>
        /// Actualiza un registro de libros
        /// </summary>
        public override void Actualizar()
        {
            Find.Titulo = Libro.Titulo;
            Find .sintesis = Libro.sintesis;
            Find.NumeroPagina = Libro.NumeroPagina;
            _context.SaveChanges();
        }
        /// <summary>
        /// Eliminar un registro de libro
        /// </summary>

        public override void Eliminar()
        {
            _context.Libros.Remove(Find);
            _context.SaveChanges();
            
        }
        /// <summary>
        /// Inserta un registro de libro
        /// </summary>
        public override void Guardar()
        {
            _context.Libros.Add(Libro);
            _context.SaveChanges();
        }
    }
}