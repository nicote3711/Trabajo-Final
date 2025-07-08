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
    public class FacturaDuenoDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public void RegistrarFactura(FacturaDueno facturaDueno)
        {

            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                int idFacura = HelperD.ObtenerProximoID(tablaFacturas, "Id_Factura");
                facturaDueno.IdFactura = idFacura;
                DataRow row = tablaFacturas.NewRow();
                FacturaMAP.MapearHaciaDB(facturaDueno,row);
                tablaFacturas.Rows.Add(row);
                ds.WriteXml(rutaXml,XmlWriteMode.WriteSchema);

            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaDueno error al registrar Factura");
            }
        }

        public bool ExisteFacturaConCuilYNro(string cuilEmisor, int nroFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                return tablaFacturas.AsEnumerable().Any(row => row["Cuil_Emisor"].ToString().Equals(cuilEmisor) && Convert.ToInt32(row["Nro_Factura"]).Equals(nroFactura));
            }
            catch (Exception ex)
            {
                throw new Exception("DAL FacturaDueño error al verificar existencia de factura por CUIL y número: " + ex.Message, ex);
            }
        }
        public List<FacturaDueno> ObtenerFacturas()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                List<DataRow> rowFacturas = tablaFacturas.AsEnumerable().Where(rf=> rf.Field<int>("Id_Tipo_Factura").Equals((int)EnumTiposFactura.FacturaDueño)).ToList();
                List<FacturaDueno> LFacturasDueno = new List<FacturaDueno>(); 
                foreach(DataRow row in rowFacturas)
                {
                    FacturaDueno facturaDueno = new FacturaDueno();
                    FacturaMAP.MapearDesdeDB(facturaDueno, row);
                    LFacturasDueno.Add(facturaDueno);
                }

                return LFacturasDueno;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaDueno error al obtener Facturas: "+ex.Message,ex);
            }
        }

        public void EliminarFactura(int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                DataRow row = tablaFacturas.AsEnumerable().FirstOrDefault(r => r["Id_Factura"].Equals(idFactura));
                if (row == null) throw new Exception("No se encontro la factura a eliminar en la base de datos");

                row.Delete();

                ds.WriteXml(rutaXml,XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaDueño error al eliminar factura: "+ex.Message,ex);
            }
        }

        public FacturaDueno BuscarFacturaPorId(int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                DataRow row = tablaFacturas.AsEnumerable().FirstOrDefault(r => r["Id_Factura"].Equals(idFactura));
                if (row == null) return null;

                FacturaDueno facturaDueno = new FacturaDueno();
                FacturaMAP.MapearDesdeDB(facturaDueno, row);

                return facturaDueno;    

            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaDueño error al buscar factura por id: "+ex.Message,ex);
            }
        }
    }
}
