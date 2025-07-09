using ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class HelperD
    {
        public static int ObtenerProximoID(DataTable tabla, string nombreColumnaID)
        {
            try
            {
                if (tabla == null || tabla.Rows.Count == 0)
                    return 1;

                var valores = tabla.AsEnumerable()
                                   .Where(row => row[nombreColumnaID] != DBNull.Value)
                                   .Select(row => Convert.ToInt32(row[nombreColumnaID]));

                return valores.Any() ? valores.Max() + 1 : 1;
            }
            catch (Exception ex)
            {

                throw new Exception("HelperD error al obtener proximo id");
            }

        }

        public static int ObtenerProximoNumeroFactura(DataTable tabla, int tipoFactura)
        {
            try
            {
                if (tabla == null || tabla.Rows.Count == 0)
                    return 1;

                var valores = tabla.AsEnumerable().Where(row => Convert.ToInt32(row["Id_Tipo_Factura"]).Equals(tipoFactura));

                return valores.Any() ? valores.Max(row => Convert.ToInt32(row["Nro_Factura"])) + 1 : 1;
            }
            catch (Exception ex)
            {

                throw new Exception("HelperD error al obtener proximo numero para factura");
            }
         
        }

        public static string ObtenerConexionXMl()
        {
            return "GestionEscuelaVuelo_FINAL.xml";
        }
        public static string ObtenerConexionBitacora()
        {
            return "Bitacora.xml";
        }
        public static bool ExisteRelacion(DataTable tabla, Dictionary<string, object> condiciones)
        {
            try
            {
                if (tabla == null || condiciones == null || condiciones.Count == 0) return false;
                var query = tabla.AsEnumerable().Where(row => condiciones.All(cond => row.Field<object>(cond.Key)?.Equals(cond.Value) ?? false));
                return query.Any();
            }
            catch (Exception ex)
            {
                throw new Exception("HelperD eror a ver si existe relacion: "+ex.Message,ex);
            }
        
        }

        public static void RealizarBackUp(DateTime fechaRegistro)
        {
           
            string backupDir = @"BackUp";
            try
            {
                //    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                if (!Path.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }
                File.Copy(ObtenerConexionXMl(), Path.Combine(backupDir, fechaRegistro.ToString("dd-MM-yyyy HH.mm") + "_Backup.xml"), true);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void RealizarRestore(DateTime fechaRegistro)
        {
            {
                string backupDir = @"BackUp";
                string nombreArchivo = fechaRegistro.ToString("dd-MM-yyyy HH.mm") + "_BackUp.xml";
                string origen = Path.Combine(backupDir, nombreArchivo);
                string destino = ObtenerConexionXMl(); // Ruta del archivo principal de datos XML

                try
                {
                    // Verificar que el archivo de respaldo existe
                    if (!File.Exists(origen))throw new FileNotFoundException($"No se encontró el archivo de backup: {nombreArchivo}");
                    

                    // Restaurar: reemplazar el archivo actual por el backup
                    File.Copy(origen, destino, true);
                }
                catch (Exception ex)
                {
                    throw new Exception("HelperD Error al realizar el restore: " + ex.Message, ex);
                }
            }
        }

        public static bool ExisteBackUp(DateTime fechaRegistro)
        {

            string backupDir = @"BackUp";
            string nombreArchivo = fechaRegistro.ToString("dd-MM-yyyy HH.mm") + "_BackUp.xml";
            string rutaCompleta = Path.Combine(backupDir, nombreArchivo);

            return File.Exists(rutaCompleta);
        }


    }

}
