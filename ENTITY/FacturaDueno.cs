﻿using ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class FacturaDueno: Factura
    {
        public Dueno Dueno { get; set; }
        public List<LiquidacionDueno> ListaLiquidaciones { get; set; }
        public FacturaDueno() 
        { 
            this.TipoFactura = new TipoFactura() { IdTipoFactura = (int)EnumTiposFactura.FacturaDueño };
            
        }

        public override Persona DatosCliente()
        {
            Cliente cliente = new Cliente();

            cliente.Nombre = "Flight MRB";
            cliente.Apellido = string.Empty;
            cliente.CuitCuil = "3013549875";
            return cliente;
        }

        public override Persona DatosEmisor()
        {
            Empresa emisor = new Empresa();
            emisor.Nombre = Dueno.Nombre;
            emisor.Apellido = Dueno.Apellido;
            emisor.CuitCuil = Dueno.CuitCuil;
            return emisor;
        }

        public override List<LiquidacionDetalle> FacturaDetalles()
        {
            List<LiquidacionDetalle> detalleLiq = new List<LiquidacionDetalle>();
            foreach (LiquidacionDueno liquidacion in ListaLiquidaciones)
            {
                detalleLiq.AddRange(liquidacion.ObtenerDetalle());
            }

            return detalleLiq;
        }
    }
}
