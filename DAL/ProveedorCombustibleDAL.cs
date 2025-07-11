using ENTITY;
using Helper;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProveedorCombustibleDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        

        public  List<ProveedorCombustible> ObtenerTodos()
        {

            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

               
                DataTable tabla = ds.Tables["Proveedor_Combustible"];
                if (tabla == null) throw new Exception("No se encontro la tabla Proveedor Combustible.");

                List<ProveedorCombustible> LProveedoresCombu = new List<ProveedorCombustible>();
                foreach (DataRow row in tabla.Rows)
                {
                    ProveedorCombustible proveedor = new ProveedorCombustible();
                    ProveedorCombustibleMAP.MapearDesdeDB(proveedor, row);
                    LProveedoresCombu.Add(proveedor);
                }

                return LProveedoresCombu;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL ProveedorCombustible error al obtener todos los proveedores: "+ex.Message,ex);
            }            
        }

        public ProveedorCombustible BuscarPorId(int idProveedor)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
                //ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Proveedor_Combustible"];
                if (tabla == null) throw new Exception("No se encontró la tabla Proveedor_Combustible.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Proveedor_Combustible"]).Equals(idProveedor));
                if (row == null) return null;

                ProveedorCombustible proveedor = new ProveedorCombustible();
                ProveedorCombustibleMAP.MapearDesdeDB(proveedor, row);
                return proveedor;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL ProveedorCombustible error al buscar por Id: " + ex.Message, ex);
            }
        }
    }
}
