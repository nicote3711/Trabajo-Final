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
    public class FacturaMantenimientoDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public FacturaMantenimiento BuscarFacturaMPorId(int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                DataRow row = tablaFacturas.AsEnumerable().FirstOrDefault(r => r["Id_Factura"].Equals(idFactura));
                if (row == null) throw new Exception($"No se encontro la factura con id {idFactura}");
                FacturaMantenimiento factura = new FacturaMantenimiento();
                FacturaMAP.MapearDesdeDB(factura, row);   

                return factura;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaMantenimiento error al buscar la factura por Id: "+ex.Message,ex);
            }
        }

        public void EliminarFacturaMantenimiento(int idFactura)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                DataRow row = tablaFacturas.AsEnumerable().FirstOrDefault(r => r["Id_Factura"].Equals(idFactura));
                if (row == null) throw new Exception($"No se encontro la factura con id {idFactura}");


                tablaFacturas.Rows.Remove(row);

                ds.WriteXml(rutaXml,XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Factura Mantenimiento error al eliminar factura: "+ex.Message,ex);
            }
        }

        public List<FacturaMantenimiento> ObtenerTodos()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                List<DataRow> rows = tablaFacturas.AsEnumerable().Where(f => f["Id_Tipo_Factura"].Equals((int)EnumTiposFactura.FacturaMantenimiento)).ToList();
                List<FacturaMantenimiento> LFacturaM = new List<FacturaMantenimiento>();
                foreach (DataRow row in rows)
                {
                    FacturaMantenimiento factura = new FacturaMantenimiento();
                    FacturaMAP.MapearDesdeDB(factura, row);
                    LFacturaM.Add(factura);
                }

                return LFacturaM;   
            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaMantenimiento error al obtener todos: "+ex.Message,ex);
            }
        }

        public void RegistrarFactura(FacturaMantenimiento facturaMantenimiento)
        {
			try
			{
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                int idFacura = HelperD.ObtenerProximoID(tablaFacturas, "Id_Factura");
                facturaMantenimiento.IdFactura = idFacura;
                DataRow row = tablaFacturas.NewRow();
                FacturaMAP.MapearHaciaDB(facturaMantenimiento, row);
                tablaFacturas.Rows.Add(row);
                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
			catch (Exception ex)
			{

				throw new Exception("DAL FacturaMantenimiento error al registrar factura: "+ex.Message,ex);
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
                throw new Exception("DAL FacturaMantenimiento error al verificar existencia de factura por CUIL y número: " + ex.Message, ex);
            }
        }
    }
}
