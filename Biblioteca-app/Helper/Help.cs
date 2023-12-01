using Conexion;
using Model;
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
        public abstract void Guardar(FormCollection collection);
        public abstract void Actualizar(int id,FormCollection collection);
        public abstract void Eliminar(int id);


    }
}