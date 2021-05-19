using AudioStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.AD
{
    public static class BaseDatos
    {
        public static List<Usuario> ListaUsuarios { get; set; }

        public static void IniciarUsuario()
        {
            if (ListaUsuarios == null)
            {
                ListaUsuarios = new List<Usuario>();
                Usuario usuario1 = new Usuario(1, "eduardo", "mass");
                Usuario usuario2 = new Usuario(2, "coco", "basile");
                ListaUsuarios.Add(usuario1);
                ListaUsuarios.Add(usuario2);
            }
        }


    }
}
