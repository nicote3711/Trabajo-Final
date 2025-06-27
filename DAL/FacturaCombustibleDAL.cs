using ENTITY;
using ENTITY.Enum;
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
    public class FacturaCombustibleDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public List<FacturaCombustible> ObtenerTodos()
        {
            try
            {
                if (!File.Exists(rutaXml))throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Factura"];
                if (tabla == null)throw new Exception("No se encontró la tabla Factura.");

                List<DataRow> rows = tabla.AsEnumerable().Where(r => r["Id_Tipo_Factura"].Equals((int)EnumTiposFactura.FacturaRecargaCombustible)).ToList();
                List<FacturaCombustible> LFacturasCombu = new List<FacturaCombustible>();

                foreach (DataRow row in rows)
                {                   
                    FacturaCombustible factura = new FacturaCombustible();
                    FacturaMAP.MapearDesdeDB(factura, row);
                    LFacturasCombu.Add(factura);
                }

                return LFacturasCombu;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL FacturaCombustible  error al obtener todas las facturas: " + ex.Message, ex);
            }
        }

        public void RegistrarFacturaCombustible(FacturaCombustible facturaCombustible)
        {

            try
            {
                if (!File.Exists(rutaXml))throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Factura"];
                if (tabla == null)throw new Exception("No se encontró la tabla Factura.");

                facturaCombustible.IdFactura = HelperD.ObtenerProximoID(tabla, "Id_Factura");

                DataRow row = tabla.NewRow();
                FacturaMAP.MapearHaciaDB(facturaCombustible, row);
                tabla.Rows.Add(row);

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL FacturaCombustible error al registrar factura: "+ex.Message,ex);
            }
        }

            

    }
}
