using ENTITY.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER.Composite
{
    public class PermisoMAP
    {
        public static Componente MapearDesdeDB(DataRow row)
        {
            int id = Convert.ToInt32(row["Id_Permiso"]);
            string nombre = row["Nombre"].ToString();
            bool esItem = Convert.ToBoolean(row["Es_Item"]);

            Componente componente;

            if (esItem)
                componente = new PermisoItem();
            else
                componente = new Permiso(); // compuesto

            componente.IdComponente = id;
            componente.NombreComponente = nombre;

            return componente;
        }

        public static void MapearHaciaDB(Componente componente, DataRow row)
        {
            row["Id_Permiso"] = componente.IdComponente;
            row["Nombre"] = componente.NombreComponente;
            row["Es_Item"] = componente.EsHoja(); // true para PermisoItem, false para Permiso
        }
    }
}
