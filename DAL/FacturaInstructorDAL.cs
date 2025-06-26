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
    public class FacturaInstructorDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

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

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaInstructor error al eliminar factura: "+ex.Message,ex);
            } 
        }

        public  List<FacturaInstructor> ObtenerFacturas()
        {
			try
			{
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                List<DataRow> rowFacturas = tablaFacturas.AsEnumerable().Where(rf => rf.Field<int>("Id_Tipo_Factura").Equals((int)EnumTiposFactura.FacturaInstructor)).ToList();

                List<FacturaInstructor> LFacturaInstructores = new List<FacturaInstructor>();
                foreach (DataRow row in rowFacturas)
                {
                    FacturaInstructor facturaInstructor = new FacturaInstructor();
                    FacturaMAP.MapearDesdeDB(facturaInstructor,row);
                    LFacturaInstructores.Add(facturaInstructor);
                }

                return LFacturaInstructores;
            }
			catch (Exception ex)
			{

				throw new Exception("DAL FacturaInstructor error al obtener facturas: "+ex.Message,ex);
			}
        }

        public void RegistrarFactura(FacturaInstructor facturaInstructor)
        {

            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaFacturas = ds.Tables["Factura"];
                if (tablaFacturas == null) throw new Exception("No se encontró la tabla Factura.");

                int idFacura = HelperD.ObtenerProximoID(tablaFacturas, "Id_Factura");
                facturaInstructor.IdFactura = idFacura;
                DataRow row = tablaFacturas.NewRow();
                FacturaMAP.MapearHaciaDB(facturaInstructor, row);
                tablaFacturas.Rows.Add(row);
                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);

            }
            catch (Exception ex)
            {

                throw new Exception("DAL FacturaDueno error al registrar Factura");
            }
        }
    }
}
