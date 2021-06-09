using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.Models
{
    public class TipoEquipo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Descripcion Obligatoria")]
        public string Descripcion { get; set; }

        [Display(Name = "Estas son las observaciones")]
        public string Observaciones { get; set; }
    }
}
