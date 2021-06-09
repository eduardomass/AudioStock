using AudioStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.AD
{
    public static class BaseDatos
    {
        public static List<Equipo> Equipos { get; set; } = new List<Equipo>();
        public static List<Usuario> Usuarios { get; set; }
        public static List<Marca> Marcas { get; set; } = new List<Marca>();
        public static List<TipoEquipo> TiposEquipos { get; set; } = new List<TipoEquipo>();

        public static TipoEquipo Buscar(int id)
        {
            foreach (TipoEquipo item in TiposEquipos)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static void IniciarBaseDatosHarcoded()
        {
            Usuarios = new List<Usuario>();
            Usuario usuario1 = new Usuario();
            Usuario usuario2 = new Usuario();
            Usuarios.Add(usuario1);
            Usuarios.Add(usuario2);

            Marca marca = new Marca();
            marca.Id = 1;
            marca.Descripcion = "Kampex";
            Marcas.Add(marca);

            Marcas.Add(new Marca() { Id = 2, Descripcion = "Madsen"});

            TiposEquipos.Add(new TipoEquipo() { Id = 1, Descripcion = "Tipo 1" });
            TiposEquipos.Add(new TipoEquipo() { Id = 2, Descripcion = "Tipo 2" });

            Equipo equipo = new Equipo()
            {
                Estado = "USO",
                Fecha = DateTime.Now,
                Marca = Marcas[0],
                Modelo = "RX90",
                Observacion = "Sin Observaciones",
                SacNumero = "123JLKDIO",
                TipoEquipo = TiposEquipos[0]
            };
            Equipo equipo2= new Equipo()
            {
                Estado = "USO",
                Fecha = DateTime.Now,
                Marca = Marcas[1],
                Modelo = "OTROGATO",
                Observacion = "Sin Observaciones",
                SacNumero = "9999999",
                TipoEquipo = TiposEquipos[0]
            };
            Equipos.Add(equipo);
            Equipos.Add(equipo2);

        }

    }
}
