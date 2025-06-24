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
    public class FacturaSolicitudHorasDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();


        public List<FacturaSolicitudHoras> ObtenerFacturas()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");
                List<DataRow> rowFacturas = tablaFacturas.AsEnumerable().Where(f => f.Field<int>("Id_Tipo_Factura").Equals((int)EnumTiposFactura.FacturaSolicitudHoras)).ToList();
                List<FacturaSolicitudHoras> facturas = new List<FacturaSolicitudHoras>();
                
                foreach (DataRow row in rowFacturas)
                {
                    FacturaSolicitudHoras factura = new FacturaSolicitudHoras();
                    FacturaMAP.MapearDesdeDB(factura, row);
                    facturas.Add(factura);
                }
                
                return facturas;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL FacturaSolicitud error al obtener facturas por tipo: " + ex.Message, ex);
            }
        }
        public int ObtenerNumeroFactura(int idTipoFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");
                DataRow[] filasFiltradas = tablaFacturas.Select($"Id_Tipo_Factura = {idTipoFactura}");
                int nroFactura = 1;
                if (filasFiltradas.Length > 0)
                {
                    nroFactura = filasFiltradas.Select(f => Convert.ToInt32(f["Nro_Factura"])).Max() + 1;
                }
                return nroFactura;
            }
            catch (Exception ex)
            {
                throw new Exception("DALL FacturaSolicitudHoras error al obtener numero factura :" + ex.Message, ex);
            }
        }

        public void RegistrarFactura(FacturaSolicitudHoras factura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                int nuevoId = HelperD.ObtenerProximoID(tablaFacturas, "Id_Factura");
                factura.IdFactura = nuevoId;

                DataRow row = tablaFacturas.NewRow();
                FacturaMAP.MapearHaciaDB(factura, row);
                tablaFacturas.Rows.Add(row);

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaSolicitud error al registrar factura: " + ex.Message, ex);
            }
        }

        public FacturaSolicitudHoras BuscarFacturaPorId(int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                DataRow row = tablaFacturas.AsEnumerable().FirstOrDefault(f => f.Field<int>("Id_Factura") == idFactura);
                if (row == null) return null; // O lanzar una excepción si se prefiere
                FacturaSolicitudHoras factura = new FacturaSolicitudHoras();
                FacturaMAP.MapearDesdeDB(factura, row);
                return factura;

            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaSolicitud error al obtener factura por Id: " + ex.Message, ex);
            }
        }

        public void EliminarFacturaPorId(int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                DataRow row = tablaFacturas.AsEnumerable().FirstOrDefault(f => f.Field<int>("Id_Factura") == idFactura);
                if (row == null) throw new Exception($"No se encontró la factura con ID {idFactura}."); 

                row.Delete(); // Marca la fila para eliminación
                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema); // Guarda los cambios en el archivo XML
            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaSolicud error al eliminar factura por Id: "+ex.Message,ex);
            }
        }
    }
}
