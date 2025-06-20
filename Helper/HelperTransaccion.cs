﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class HelperTransaccion
    {
        public  DataSet DfParaTransaccion()
        {
            try
            {
                if (!File.Exists(HelperD.ObtenerConexionXMl())) throw new FileNotFoundException("No se encontró el archivo XML principal.");

                DataSet dsRollBack = new DataSet();
                dsRollBack.ReadXml(HelperD.ObtenerConexionXMl(), XmlReadMode.ReadSchema);
                return dsRollBack;
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        public void RollbackDfParaTransaccion(DataSet dsRollBack)
        {
            if (dsRollBack == null) throw new ArgumentNullException(nameof(dsRollBack), "El DataSet para rollback no puede ser nulo.");
            try
            {
                dsRollBack.WriteXml(HelperD.ObtenerConexionXMl(), XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el rollback del DataSet: " + ex.Message, ex);
            }
        }
    }
}
