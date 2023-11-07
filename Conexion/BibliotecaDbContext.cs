using Model;
using System.Configuration;
using System.Data.Entity;
namespace Conexion
{
    /// <summary>
    /// Modelado de la base de datos de biblioteca. 
    /// esta caracteristica fue desarrollada en code first
    /// </summary>
    public class BibliotecaDbContext:DbContext
    {
        public BibliotecaDbContext() : base(ConfigurationManager.ConnectionStrings["Biblioteca"].ConnectionString)
        {

        }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Libro>Libros { get; set; }
    }
}
