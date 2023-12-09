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
    /// Repositorio de autor
    /// </summary>
    public class AutorHelp : Help
    {
        /// <summary>
        /// obtiene o establece un objeto de la classe autor
        /// </summary>
        public IQueryable< Autor>QueryAutor 
        {
            get
            {
                return _context.Autors.AsQueryable();
            }
        }
        public AutorHelp(BibliotecaDbContext context)
        {
            _context = context;
        }

        
        /// <summary>
        /// Actualiza un registro de autor
        /// </summary>
        public override void Actualizar(int id ,FormCollection collection)
        {
            var  Autor = QueryAutor.Where(x=>x.Id==id).FirstOrDefault();
            Autor.Nombre =collection["Nombre"];
            Autor.Apellido =collection["Apellido"];
            _context.SaveChanges();
        }
        /// <summary>
        /// Eliminar un registro de autor
        /// </summary>
        public override void Eliminar(int id)
        {
            var Autor = QueryAutor.Where(x => x.Id == id).FirstOrDefault();
            _context.Autors.Remove(Autor);
            _context.SaveChanges();

        }
        /// <summary>
        /// Inserta un registro de autor
        /// </summary>
        public override void Guardar(FormCollection collection )
        {
           var Autor = new Autor
            {
                Nombre = collection["Nombre"],
                Apellido = collection["Apellido"],
            };
            _context.Autors.Add(Autor);
            _context.SaveChanges();
        }
    }
}