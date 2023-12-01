using System;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    /// <summary>
    /// Modelado de libro
    /// </summary>
    public class Libro
    {
        public int Id { get; set; } 
        
        [Required(ErrorMessage = "Campo Titulo es requerido")]
        [MaxLength(50, ErrorMessage = "Campo Titulo no puede tener mas de 50 caracteres")]
        public string Titulo { get; set; }

        [MaxLength(255, ErrorMessage = "Campo sintesis no puede tener mas de 255 caracteres")]
        public string Sintesis { get; set; }

        [Required(ErrorMessage = "Campo numero de pagina es requerido")]
        [Display( Name ="Numero de paginas")]
        public int NumeroPagina { get; set; }

        [Required(ErrorMessage = "Campo Autor es requerido")]
        [Display(Name = "Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }


    }
}
