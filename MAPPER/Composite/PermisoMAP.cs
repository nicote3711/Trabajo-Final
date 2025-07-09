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
            try
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
            catch (Exception ex)
            {

                throw new Exception("MAP permiso error: "+ex.Message,ex);
            }
           
        }

        public static void MapearHaciaDB(Componente componente, DataRow row)
        {
            try
            {
                row["Id_Permiso"] = componente.IdComponente;
                row["Nombre"] = componente.NombreComponente;
                row["Es_Item"] = componente.EsHoja(); // true para PermisoItem, false para Permiso
            }
            catch (Exception ex)
            {
                throw new Exception("MAP permiso error: " + ex.Message, ex);
            }
           
        }
    }
}
