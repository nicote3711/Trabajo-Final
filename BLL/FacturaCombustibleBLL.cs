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
    public class FacturaCombustibleBLL
    {
		FacturaCombustibleDAL FacturaCombustibleDAO = new FacturaCombustibleDAL();

        public void EliminarFactura(FacturaCombustible facturaCombustible)
        {
			HelperTransaccion helperTransaccion = new HelperTransaccion();
			DataSet ds = helperTransaccion.DfParaTransaccion();
			try
			{
                if (facturaCombustible == null || facturaCombustible.IdFactura <= 0 ) throw new Exception("error al obtener la factura de la grilla esta es nulo o con id invalid");
				if (facturaCombustible.RecargaCombu == null || facturaCombustible.RecargaCombu.IdRecargaCombustible <= 0) throw new Exception("error al obtener la factura de la grila, no tiene recarga asociada o su id es invalido");
                if (facturaCombustible.Transaccion != null) throw new Exception("No se puede eliminar una factura ya pagada");

				FacturaCombustibleDAO.EliminarFacturaPorId(facturaCombustible.IdFactura);
				Resultado result = HelperFacturas.EliminarFacturaPDF((int)EnumTiposFactura.FacturaRecargaCombustible, facturaCombustible.NroFactura);
                RecargaCombustibleBLL RecargaCombustibleBLO = new RecargaCombustibleBLL();
				RecargaCombustibleBLO.EliminarRecargaPorIdFactura(facturaCombustible.IdFactura); // aca podria eliminar por Id Recarga simplemente ya que tengo el Id al mappear todo el objeto.

            }
			catch (Exception ex)
			{
				helperTransaccion.RollbackDfParaTransaccion(ds);
				throw new Exception("BLL FacturaCombustible error al eliminar Factura: "+ex.Message,ex);
			}
        }

        public List<FacturaCombustible> ObtenerTodos()
		{
			try
			{
				List<FacturaCombustible> LFacturasCombustible = FacturaCombustibleDAO.ObtenerTodos();
				
				RecargaCombustibleBLL RecargaCombustibleBLO = new RecargaCombustibleBLL();
 				foreach(FacturaCombustible factura in LFacturasCombustible)
				{
					RecargaCombustible recarga = RecargaCombustibleBLO.BuscarRecargaPorIdFacturaCombustible(factura.IdFactura);
					if (recarga == null) throw new Exception("La recarga de combustible de una factura no puede ser nula");
					factura.RecargaCombu = recarga;
				}

				return LFacturasCombustible;	
			}
			catch (Exception ex)
			{

				throw new Exception("BLL FacturaCombustible error al obtener todas las facturas: "+ex.Message,ex);
			}
		}


        public void RegistrarFacturaCombustible(FacturaCombustible facturaCombustible)
        {
			HelperTransaccion helperTransaccion = new HelperTransaccion();
			DataSet ds = helperTransaccion.DfParaTransaccion();

			try
			{
				CargarFacturaCombuConRecarga(facturaCombustible);

				FacturaCombustibleDAO.RegistrarFacturaCombustible(facturaCombustible);
				if (facturaCombustible.IdFactura <= 0) throw new Exception("error al obtener el id de la factura");
				facturaCombustible.RecargaCombu.FacturaCombu = new FacturaCombustible();
				facturaCombustible.RecargaCombu.FacturaCombu.IdFactura = facturaCombustible.IdFactura;	
				RecargaCombustibleBLL RecargaCombustibleBLO = new RecargaCombustibleBLL();
				RecargaCombustibleBLO.RegistrarRecargaCombustible(facturaCombustible.RecargaCombu);

				Resultado resultado = HelperFacturas.GenerarFacturaPDF(facturaCombustible);
				if (!resultado.Success) throw new Exception(resultado.Message);

            }
			catch (Exception ex)
			{
				helperTransaccion.RollbackDfParaTransaccion(ds);
				throw new Exception("BLL FacturaCombustible error al registrar factura: "+ex.Message,ex);
			}
        }

        public FacturaCombustible BuscarFacturaCombuPorIdParaTransaccion(int idFactura)
        {
            throw new NotImplementedException();
        }

        private void CargarFacturaCombuConRecarga(FacturaCombustible facturaCombustible)
        {
			try
			{
				facturaCombustible.FechaFactura = facturaCombustible.RecargaCombu.Fecha;
				facturaCombustible.CuilEmisor = facturaCombustible.RecargaCombu.ProveedorCombu.Cuit;
				decimal diff = facturaCombustible.MontoTotal- facturaCombustible.RecargaCombu.CantidadLitros * facturaCombustible.RecargaCombu.PrecioLitros;

                if (diff>0.01M) throw new Exception("inconsistencias entre litros,cantidad y precio de la factura");
				if(facturaCombustible.FechaFactura.Date > DateTime.Now.Date) throw new Exception("la factura tiene una fecha invalida superior al dia de hoy");
				if(facturaCombustible.NroFactura <= 0) throw new Exception("numero de factura invalido");
			}
			catch (Exception ex)
			{
				throw new Exception("BLL FacturaCombustible error al Cargar datos factura combustible:" +ex.Message,ex);
			}
        }
    }
}
