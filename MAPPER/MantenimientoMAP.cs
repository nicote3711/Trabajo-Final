using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPPER
{
    public class MantenimientoMAP
    {

        public static void MapearDesdeDB(Mantenimiento mantenimiento, DataRow row)
        {
            mantenimiento.IdMantenimiento = Convert.ToInt32(row["Id_Mantenimiento"]);
            mantenimiento.Fecha = DateTime.ParseExact(row["Fecha"].ToString(), "dd/MM/yyyy", null);
            mantenimiento.Detalle = row["Detalle"].ToString();

            mantenimiento.Aeronave = new Aeronave { IdAeronave = Convert.ToInt32(row["Id_Aeronave"]) };

            mantenimiento.Mecanico = string.IsNullOrEmpty(row["Id_Mecanico"].ToString())? null: new Mecanico { IdMecanico = Convert.ToInt32(row["Id_Mecanico"]) };

            mantenimiento.TipoMantenimiento = new TipoMantenimiento { IdTipoMantenimiento = Convert.ToInt32(row["Id_Tipo_Mantenimiento"]) };

            mantenimiento.FacturaMantenimientio = string.IsNullOrEmpty(row["Id_Factura"].ToString())? null:new FacturaMantenimiento { IdFactura = Convert.ToInt32(row["Id_Factura"]) };

            mantenimiento.EstadoMantenimiento = new EstadoMantenimiento { IdEstadoMantenimiento = Convert.ToInt32(row["Id_Estado_Mantenimiento"]) };
        }

        public static void MapearHaciaDB(Mantenimiento mantenimiento, DataRow row)
        {
            row["Id_Mantenimiento"] = mantenimiento.IdMantenimiento;
            row["Fecha"] = mantenimiento.Fecha.ToString("dd/MM/yyyy");
            row["Detalle"] = mantenimiento.Detalle;

            row["Id_Aeronave"] = mantenimiento.Aeronave.IdAeronave;

            row["Id_Mecanico"] = mantenimiento.Mecanico == null? DBNull.Value: mantenimiento.Mecanico.IdMecanico;

            row["Id_Tipo_Mantenimiento"] = mantenimiento.TipoMantenimiento.IdTipoMantenimiento;

            row["Id_Factura"] = mantenimiento.FacturaMantenimientio == null? DBNull.Value:mantenimiento.FacturaMantenimientio.IdFactura;

            row["Id_Estado_Mantenimiento"] = mantenimiento.EstadoMantenimiento.IdEstadoMantenimiento;
        }


    }
}
