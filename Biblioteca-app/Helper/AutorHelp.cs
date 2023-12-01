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
        public Autor Autor { get; set; }
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
        public override void Actualizar(int id ,FormCollection collection)
        {
            Autor = GetAutor(id);
            Autor.Nombre =collection["Nombre"];
            Autor.Apellido =collection["Apellido"];
            _context.SaveChanges();
        }
        /// <summary>
        /// Eliminar un registro de autor
        /// </summary>
        public override void Eliminar(int id)
        {
            Autor = GetAutor(id);
            _context.Autors.Remove(Autor);
            _context.SaveChanges();

        }
        /// <summary>
        /// Inserta un registro de autor
        /// </summary>
        public override void Guardar(FormCollection collection )
        {
            Autor = new Autor
            {
                Nombre = collection["Nombre"],
                Apellido = collection["Apellido"],
            };
            _context.Autors.Add(Autor);
            _context.SaveChanges();
        }
    }
}