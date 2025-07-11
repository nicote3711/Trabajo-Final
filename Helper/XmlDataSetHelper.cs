using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class XmlDataSetHelper
    {
        private static readonly string rutaXml = HelperD.ObtenerConexionXMl(); 
        private static DataSet _dataSet = null;

        public static DataSet DataSetEnMemoria
        {
            get
            {
                if (_dataSet == null)
                {
                    CargarDataSet();
                }
                return _dataSet;
            }
        }

        public static void CargarDataSet()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                _dataSet = new DataSet();
                _dataSet.ReadXml(rutaXml, XmlReadMode.ReadSchema);
            }
            catch (Exception ex)
            {

                throw new Exception("XmlDataSetHelper error al cargar el DataSet: " + ex.Message, ex);
            }          
        }

        public static void GuardarCambios()
        {
            try
            {
                if (_dataSet == null) throw new Exception("No hay datos cargados en memoria para guardar.");
                _dataSet.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
                CargarDataSet(); // recargar para reflejar cambios correctamente
            }
            catch (Exception ex)
            {
                throw new Exception("XmlDataSetHelper error al guardar cambios en el DataSet: " + ex.Message, ex);
            }
          
        }

        public static void ForzarRecarga()
        {
            CargarDataSet();
        }
    }
}

