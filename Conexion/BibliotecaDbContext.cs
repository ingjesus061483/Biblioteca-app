using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class BibliotecaDbContext:DbContext
    {
        public BibliotecaDbContext() : base(ConfigurationManager.ConnectionStrings["Biblioteca"].ConnectionString)
        {

        }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Libro>Libros { get; set; }
    }
}
