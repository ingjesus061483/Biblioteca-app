using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    /// <summary>
    /// Modelado de autor
    /// </summary>
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo nombre es requerido")]
        [MaxLength(50,ErrorMessage ="Campo nombre no puede tener mas de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo Apellido es requerido")]
        [MaxLength(50, ErrorMessage = "Campo Apellido no puede tener mas de 50 caracteres")]
        public string Apellido { get; set; }

        [Display(Name = "Nombre completo")]
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }
        public List <Libro> Libros { get; set; }

    }
}
