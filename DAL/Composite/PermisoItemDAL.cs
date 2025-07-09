using ENTITY.Composite;
using Helper;
using MAPPER.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Composite
{
    public class PermisoItemDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public List<PermisoItem> ObtenerPermisosItem()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaPermisos = ds.Tables["Permiso"];
                if (tablaPermisos == null) throw new Exception("No se encontró la tabla Permiso.");

                List<PermisoItem> LPermisoItem = new List<PermisoItem>();

                foreach (DataRow row in tablaPermisos.Rows)
                {
                    if (row.Table.Columns.Contains("Es_Item") && Convert.ToBoolean(row["Es_Item"]))
                    {
                        PermisoItem item = new PermisoItem();
                        PermisoItemMAP.MapearDesdeDB(item, row);
                        LPermisoItem.Add(item);
                    }
                }

                return LPermisoItem;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Permiso item error al obtener permisos item: "+ex.Message,ex);
            }

        }
        public void AltaPermisoItem(PermisoItem item)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaPermiso = ds.Tables["Permiso"];
                if (tablaPermiso == null) throw new Exception("No se encontró la tabla Permiso.");

                int nuevoId = HelperD.ObtenerProximoID(tablaPermiso, "Id_Permiso");
                item.IdComponente = nuevoId;

                DataRow row = tablaPermiso.NewRow();
                PermisoItemMAP.MapearHaciaDB(item, row);
                tablaPermiso.Rows.Add(row);
                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Permismo item error al dar alta permiso item: "+ex.Message,ex);
            }


           
        }
        public PermisoItem BuscarPermisoItemPorId(int id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaPermiso = ds.Tables["Permiso"];
                if (tablaPermiso == null) throw new Exception("No se encontró la tabla Permiso.");

                DataRow row = tablaPermiso.AsEnumerable().FirstOrDefault(r => r.Field<int>("Id_Permiso") == id && r.Field<bool>("Es_Item"));
                if (row == null) return null;

                PermisoItem item = new PermisoItem();
                PermisoItemMAP.MapearDesdeDB(item, row);

                return item;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Permiso item error al buscar permiso item por id: "+ex.Message,ex);
            }

        }

        public void Baja(int id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                var tablaPermiso = ds.Tables["Permiso"];
                var tablaComposicion = ds.Tables["Permiso_Composicion"];
                var tablaRolPermiso = ds.Tables["Rol_Permiso"];

                if (tablaPermiso == null || tablaComposicion == null || tablaRolPermiso == null) throw new Exception("No se encontraron las tablas necesarias.");

                // Borrar el permiso
                DataRow row = tablaPermiso.AsEnumerable().FirstOrDefault(r => r.Field<int>("Id_Permiso") == id && r.Field<bool>("Es_Item"));
                if (row != null) row.Delete();

                // Borrar de composiciones como padre o hijo
                foreach (DataRow rowComp in tablaComposicion.AsEnumerable().Where(r => r.Field<int>("Id_Permiso_Padre") == id || r.Field<int>("Id_Permiso_Hijo") == id).ToList())
                {
                    rowComp.Delete();
                }

                // Borrar de rol_permiso
                foreach (DataRow rowRolPer in tablaRolPermiso.AsEnumerable().Where(r => r.Field<int>("Id_Permiso") == id).ToList())
                {
                    rowRolPer.Delete();
                }

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Permiso item error al dar baja permiso item: "+ex.Message,ex);
            }

        }
        public PermisoItem BuscarPermisoItemPorNombre(string nombre)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaPermiso = ds.Tables["Permiso"];
                if (tablaPermiso == null) throw new Exception("No se encontró la tabla Permiso.");

                DataRow row = tablaPermiso.AsEnumerable().FirstOrDefault(r => r.Field<bool>("Es_Item") && r.Field<string>("Nombre").Equals(nombre, StringComparison.OrdinalIgnoreCase));

                if (row == null) return null;

                PermisoItem item = new PermisoItem();
                PermisoItemMAP.MapearDesdeDB(item, row);
                return item;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Permiso item error al buscar permiso item por numbre: "+ex.Message,ex);
            }

        }
    }
}
