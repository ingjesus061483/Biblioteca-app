using Conexion;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public Autor Autor { get; set; }

        /// <summary>
        /// obtiene o establece un objeto de la classe autor
        /// </summary>
        public Autor Autorfind { get; set; }  
        public AutorHelp(BibliotecaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene un autor por clave primaria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Autor GetAutor(int? id)
        {
            return _context.Autors.Find(id);
        }
        /// <summary>
        /// Actualiza un registro de autor
        /// </summary>
        public override void Actualizar()
        {
            Autorfind.Nombre = Autor.Nombre;
            Autorfind.Apellido = Autor.Apellido;
            _context.SaveChanges();
        }
        /// <summary>
        /// Eliminar un registro de autor
        /// </summary>
        public override void Eliminar()
        {
            _context.Autors.Remove(Autorfind);
            _context.SaveChanges();

        }
        /// <summary>
        /// Inserta un registro de autor
        /// </summary>
        public override void Guardar()
        {
            _context.Autors.Add(Autor);
            _context.SaveChanges();
        }
    }
}