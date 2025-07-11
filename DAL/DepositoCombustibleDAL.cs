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
    public class DepositoCombustibleDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();

        public List<DepositoCombustible> ObtenerTodos()
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
               // ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);
                DataTable tabla = ds.Tables["Deposito_Combustible"];
                if (tabla == null) throw new Exception("No se encontro la tabla Deposito Combustible");

                List<DepositoCombustible> LDepositosCombu = new List<DepositoCombustible>();

                if (tabla != null)
                {
                    foreach (DataRow row in tabla.Rows)
                    {
                        DepositoCombustible deposito = new DepositoCombustible();
                        DepositoCombustibleMAP.MapearDesdeDB(deposito, row);
                        LDepositosCombu.Add(deposito);
                    }
                }

                return LDepositosCombu;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL Deposito Combustible error al obtener todos los depositos: " + ex.Message, ex);
            }
        }


        public DepositoCombustible BuscarPorId(int idDeposito)
        {
            try
            {
                //if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                DataSet ds = XmlDataSetHelper.DataSetEnMemoria;
               // ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Deposito_Combustible"];
                if (tabla == null) throw new Exception("No se encontró la tabla Deposito_Combustible.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Deposito_Combustible"]).Equals(idDeposito));
                if (row == null) return null;

                DepositoCombustible deposito = new DepositoCombustible();
                DepositoCombustibleMAP.MapearDesdeDB(deposito, row);
                return deposito;
            }
            catch (Exception ex)
            {
                throw new Exception("DAL DepositoCombustible  error al buscar por Id: " + ex.Message, ex);
            }
        }
    }
}
