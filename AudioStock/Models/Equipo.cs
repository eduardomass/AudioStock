using System;
using System.Collections.Generic;
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
        public TipoEquipo TipoEquipo { get; set; }
        public Marca Marca { get; set; }

        public int MarcaId { get; set; } //esto va aca?
        //public Consultorio Consultorio { get; set; }


    }
}
