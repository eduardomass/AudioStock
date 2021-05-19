using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.Models
{
    public class Usuario
    {
        public string NombreUsuario { get; set; } = "";

        public string Password { get; set; } = "";
        public int Id { get; set; }
        public Usuario()
        {
        }
        public Usuario(int id, string nombre, string password)
        {
            this.Id = id;
            this.NombreUsuario = nombre;
            this.Password = password;
        }
    }
}
