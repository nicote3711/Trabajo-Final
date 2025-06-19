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
    public class EstadoAeronaveDAL
    {

        private readonly string rutaXml = HelperD.ObtenerConexionXMl();
        public List<EstadoAeronave> ObtenerEstadosAeronave()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML de datos.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                DataTable tablaEstados = ds.Tables["Estado_Aeronave"];
                if (tablaEstados == null) throw new Exception("No se encontró la tabla de Estados de Aeronave en el XML.");
                List<EstadoAeronave> listaEstadosAeronave = new List<EstadoAeronave>();
                foreach (DataRow row in tablaEstados.Rows)
                {
                    EstadoAeronave estado = new EstadoAeronave();
                    EstadoAeronaveMAP.MapearDesdeDB(estado, row);
                    listaEstadosAeronave.Add(estado);
                }
                return listaEstadosAeronave;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EstadoAeronave BuscarEstadoPorId(int idEstado)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML de datos.");
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                DataTable tablaEstados = ds.Tables["Estado_Aeronave"];
                if (tablaEstados == null) throw new Exception("No se encontró la tabla de Estados de Aeronave en el XML.");
                DataRow row = tablaEstados.AsEnumerable().FirstOrDefault(r => r.Field<int>("Id_Estado_Aeronave") == idEstado);
                if (row == null) return null;
                EstadoAeronave estado = new EstadoAeronave();
                EstadoAeronaveMAP.MapearDesdeDB(estado, row);
                return estado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EstadoAeronave BuscarPorDescripcion(string descripcion)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            DataTable tabla = ds.Tables["Estado_Aeronave"];
            if (tabla == null) throw new Exception("No se encontró la tabla Estado_Aeronave.");

            DataRow row = tabla.AsEnumerable().FirstOrDefault(r => r.Field<string>("Descripcion") == descripcion);

            if (row == null) return null;

            EstadoAeronave estado = new EstadoAeronave();
            EstadoAeronaveMAP.MapearDesdeDB(estado, row);
            return estado;
        }
    }
}
