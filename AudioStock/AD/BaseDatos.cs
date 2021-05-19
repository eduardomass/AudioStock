using AudioStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.AD
{
    public static class BaseDatos
    {
        public static List<Usuario> Usuarios { get; set; }
        public static List<Marca> Marcas { get; set; } = new List<Marca>();

        public static void IniciarBaseDatosHarcoded()
        {
            Usuarios = new List<Usuario>();
            Usuario usuario1 = new Usuario(1, "eduardo", "mass");
            Usuario usuario2 = new Usuario(2, "coco", "basile");
            Usuarios.Add(usuario1);
            Usuarios.Add(usuario2);

            Marca marca = new Marca();
            marca.Id = 1;
            marca.Descripcion = "Kampex";
            Marcas.Add(marca);

            Marcas.Add(new Marca() { Id = 2, Descripcion = "Madsen"});
        }

    }
}
