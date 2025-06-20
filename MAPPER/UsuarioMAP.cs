using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class UsuarioMAP
    {
        public static void MapearDesdeDB(Usuario usuario, DataRow row)
        {
            usuario.IdUsuario = Convert.ToInt32(row["Id_Usuario"]);
            usuario.NombreUsuario = row["Nombre_Usuario"].ToString();
            usuario.Contrasena = row["Password"].ToString(); // Encriptada
            usuario.DNI = Convert.ToInt64(row["DNI"]);
            usuario.Nombre = row["Nombre"].ToString();
            usuario.Apellido = row["Apellido"].ToString();
            usuario.Activo = Convert.ToBoolean(row["Activo"]);

            // No se mapean roles acá; se delega a UsuarioDAL si es necesario
        }

        public static void MapearHaciaDB(Usuario usuario, DataRow row)
        {
            row["Id_Usuario"] = usuario.IdUsuario;
            row["Nombre_Usuario"] = usuario.NombreUsuario;
            row["DNI"] = usuario.DNI;
            row["Nombre"] = usuario.Nombre;
            row["Apellido"] = usuario.Apellido;
            row["Password"] = usuario.Contrasena; // Ya encriptada
            row["Activo"] = usuario.Activo;
        }
    }
}

