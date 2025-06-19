using ENTITY;
using ENTITY.Bitacora;
using Helper;
using MAPPER.MAPBitacora;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALBitacora
{
    public class BitacoraDAL
    {
        private readonly string archivoXml = HelperD.ObtenerConexionBitacora();

        public List<Bitacora> ObtenerTodos()
        {
            if (!File.Exists(archivoXml)) throw new FileNotFoundException("El archivo de bitácora no existe.");

            List<Bitacora> LBitacora = new List<Bitacora>();
            DataSet ds = new DataSet();


            ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);
            if (ds.Tables.Contains("R_Bitacora"))
            {
                foreach (DataRow row in ds.Tables["R_Bitacora"].Rows)
                {
                    Bitacora bitacora = new Bitacora();
                    BitacoraMAP.MapearDesdeDB(bitacora, row);
                    LBitacora.Add(bitacora);
                }
            }


            return LBitacora;
        }

        public void GuardarBitacora(Bitacora bitacora)
        {
            if (bitacora == null) throw new ArgumentNullException(nameof(bitacora), "La bitácora no puede ser nula.");
            DataSet ds = new DataSet();
            if (!File.Exists(archivoXml)) throw new FileNotFoundException("El archivo de bitácora no existe.");
            ds.ReadXml(archivoXml, XmlReadMode.ReadSchema);
            
            DataTable tabla = ds.Tables["R_Bitacora"];
            if (tabla == null) throw new Exception("No se encontró la tabla de Bitácora.");

            if (bitacora.Descripcion == null || bitacora.Descripcion.Trim() == "")throw new ArgumentException("La descripción de la bitácora no puede estar vacía.");
            if(bitacora.Descripcion!= "BackUp" && bitacora.Descripcion != "Restore")throw new ArgumentException("La descripción de la bitácora debe ser 'BackUp' o 'Restore'.");
            

            int nuevoId = HelperD.ObtenerProximoID(tabla, "Id_Bitacora");
            bitacora.IdBitacora = nuevoId;
            DataRow row = tabla.NewRow();
            BitacoraMAP.MapearHaciaDB(bitacora, row);
            tabla.Rows.Add(row);
            if (bitacora.Descripcion == "BackUp")
            {
                HelperD.RealizarBackUp(bitacora.FechaRegistro);
            }
            ds.WriteXml(archivoXml, XmlWriteMode.WriteSchema);
        }

        public void RealizarRestore(Bitacora BackUp, Bitacora Restore)
        {
            try
            {
                if (BackUp == null || Restore == null) throw new ArgumentNullException("Los objetos BackUp y Restore no pueden ser nulos.");
                if (BackUp.Descripcion != "BackUp" || Restore.Descripcion != "Restore") throw new ArgumentException("Las descripciones deben ser 'BackUp' y 'Restore' respectivamente.");
                GuardarBitacora(Restore);
                HelperD.RealizarRestore(BackUp.FechaRegistro);
                
            }
            catch (Exception ex)
            {

                throw;
            }
           
            
        }


    }

}
