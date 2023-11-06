using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LibroDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Titulo es requerido")]
        [MaxLength(50, ErrorMessage = "Campo Titulo no puede tener mas de 50 caracteres")]
        public string Titulo { get; set; }

        [MaxLength(255, ErrorMessage = "Campo Titulo no puede tener mas de 255 caracteres")]
        public string sintesis { get; set; }

        [Required(ErrorMessage = "Campo Titulo es requerido")]
        [Display(Name = "Numero de paginas")]
        public int NumeroPagina { get; set; }

        [Required(ErrorMessage = "Campo Autor es requerido")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
