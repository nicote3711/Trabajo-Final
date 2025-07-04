using DAL;
using ENTITY;
using ENTITY.Enum;
using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacturaDuenoBLL
    {
		FacturaDuenoDAL FacturaDuenoDAO= new FacturaDuenoDAL();
        public void RegistrarFacturaDueno(FacturaDueno facturaDueno)
        {	
		    HelperTransaccion helperTransaccion = new HelperTransaccion();
			DataSet ds = helperTransaccion.DfParaTransaccion();
			try
			{
				if (facturaDueno == null) throw new ArgumentNullException("La factura no puede ser nula");
				if (facturaDueno.ListaLiquidaciones == null || facturaDueno.ListaLiquidaciones.Count <= 0) throw new ArgumentNullException("La lista de liquidaciones de la factura no puede estar vacia o ser nula");
				if (facturaDueno.MontoTotal <= 0) throw new Exception("El monto total no puede ser 0 o menor a 0");
				if (string.IsNullOrEmpty(facturaDueno.CuilEmisor)) throw new Exception("El cuit no puede ser nulo o vacio");

				FacturaDuenoDAO.RegistrarFactura(facturaDueno);
				if (facturaDueno.IdFactura == null || facturaDueno.IdFactura <= 0) throw new Exception("el id de la factura es nulo o invalido");

                LiquidacionDuenoBLL LiquidacionDuenoBLO = new LiquidacionDuenoBLL();
                foreach (LiquidacionDueno liquidacion in facturaDueno.ListaLiquidaciones)
				{
					liquidacion.IdFactura = facturaDueno.IdFactura;
					LiquidacionDuenoBLO.AsignarIdFacturaALiquidacion(liquidacion);	
				}

                //Generar FacturaPDF
                Resultado result = HelperFacturas.GenerarFacturaPDF(facturaDueno);
                if (!result.Success)
                    throw new Exception(result.Message);
            }
			catch (Exception ex)
			{
				helperTransaccion.RollbackDfParaTransaccion(ds);
				throw new Exception("BLL FacturaDueño error al registrar factura dueño: "+ex.Message,ex);
			}
        }

		public List<FacturaDueno> ObtenerFacturas()
		{
			try
			{
				List<FacturaDueno> LFacturasDueno = FacturaDuenoDAO.ObtenerFacturas();

				TransaccionFinancieraBLL TransaccionFinancieraBLO = new TransaccionFinancieraBLL();
				LiquidacionDuenoBLL LiquidacionDuenoBLO = new LiquidacionDuenoBLL();
				
				foreach(FacturaDueno factura in LFacturasDueno)
				{
					factura.ListaLiquidaciones = LiquidacionDuenoBLO.BuscarLiquidacionesPorIdFactura(factura.IdFactura);
					TransaccionFinanciera transaccionFinanciera = TransaccionFinancieraBLO.BuscarTransaccionPorIdFactura(factura.IdFactura);
					if(transaccionFinanciera != null)
					{
						factura.Transaccion = transaccionFinanciera;
					}
				}
				

				//Aca completar objetos si quisera como por ejemplo la lista de liquidaciones, con metodo de buscar liquidacion por Id. O lo que haga falta
				return LFacturasDueno; 
			}
			catch (Exception ex)
			{

				throw new Exception("BLL FacturaDueño error al obtener Facturas: "+ex.Message,ex);
			}
		}

        public void EliminarFactura(FacturaDueno factura)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();
            try
			{
				if (factura.IdFactura == null || factura.IdFactura <= 0) throw new Exception("Id de factura nulo o invalido.");
				if (factura.ListaLiquidaciones == null || factura.ListaLiquidaciones.Count <= 0) throw new Exception("Lista de liquidaciones de la factura nula o vacia");

				FacturaDuenoDAO.EliminarFactura(factura.IdFactura);
                Resultado result = HelperFacturas.EliminarFacturaPDF((int)EnumTiposFactura.FacturaDueño, factura.NroFactura);

                LiquidacionDuenoBLL LiquidacionDuenoBLO = new LiquidacionDuenoBLL();
				foreach(LiquidacionDueno liquidacion in factura.ListaLiquidaciones)
				{
					LiquidacionDuenoBLO.QuitarIdFacturaALiquidacion(liquidacion);
				}
			}
			catch (Exception ex)
			{

                helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("BLL FacturaDueño error al eliminar factura dueño: " + ex.Message, ex);
            }
        }

        public FacturaDueno BuscarFacturaDuenoPorIdParaTransaccion(int idFactura)
        {
			try
			{
				if (idFactura <= 0) throw new Exception("id de factura invalido");
				FacturaDueno facturaDueno = FacturaDuenoDAO.BuscarFacturaPorId(idFactura);
				if (facturaDueno == null) throw new Exception("error factura nula y esta debe existir para una transaccion");

                LiquidacionDuenoBLL LiquidacionDuenoBLO = new LiquidacionDuenoBLL();
                facturaDueno.ListaLiquidaciones = LiquidacionDuenoBLO.BuscarLiquidacionesPorIdFactura(facturaDueno.IdFactura);

                return facturaDueno;
			}
			catch (Exception ex)
			{

				throw new Exception("BLL FacturaDueño error al buscar factura por id para transaccion: "+ex.Message,ex);
			}
        }
    }
}
