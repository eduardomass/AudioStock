using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        public string Modelo { get; set; }
        public string SacNumero { get; set; }

        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }

        public int? TipoEquipoId { get; set; }
        public TipoEquipo TipoEquipo { get; set; }


        public int? MarcaId { get; set; }
        public Marca Marca { get; set; }

        //[NotMapped]
        //public int IdMarcaSeleccionada { get; set; } //esto va aca?
        //[NotMapped]
        //public int IdTipoEquipoSeleccionado { get; set; } //esto va aca?

        //public Consultorio Consultorio { get; set; }

        
        



    }
}
