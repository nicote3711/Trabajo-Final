using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RecargaCombustibleBLL
    {
		RecargarCombustibleDAL RecargarCombustibleDAO = new RecargarCombustibleDAL();
		ProveedorCombustibleBLL ProveedorCombustibleBLO = new ProveedorCombustibleBLL();
		DepositoCombustibleBLL DepositoCombustibleBLO = new DepositoCombustibleBLL();
        public RecargaCombustible BuscarRecargaPorIdFacturaCombustible(int IdFactura)
        {
			try
			{
				RecargaCombustible recarga = RecargarCombustibleDAO.BuscarRecargaCOmbuPorIdFactura(IdFactura);
				if (recarga == null) throw new Exception("no se encontro una recarga de combustible asociada a ese numero de factura");
				if (recarga.IdRecargaCombustible == null || recarga.IdRecargaCombustible <= 0) throw new Exception("id de recagar nulo o invalido");
				if (recarga.ProveedorCombu == null|| recarga.IdRecargaCombustible<=0) throw new Exception("proveedor nulo o id proveedor invalido");
				if (recarga.DepositoCombu == null || recarga.DepositoCombu.IdDepositoCombustible <= 0) throw new Exception("deposito combustible nulo o id deposito invalido");
				
				ProveedorCombustible proveedorCombustible = ProveedorCombustibleBLO.BuscarProveedorPorId(recarga.ProveedorCombu.IdProveedorCombustible);
				if (proveedorCombustible == null) throw new Exception("no se encontro proveedor combustible por id");
				recarga.ProveedorCombu = proveedorCombustible;

				DepositoCombustible depositoCombustible = DepositoCombustibleBLO.BuscarDepositoCombuPorId(recarga.DepositoCombu.IdDepositoCombustible);
				if (depositoCombustible == null) throw new Exception("no se encontro deposito de combustible por id");
				recarga.DepositoCombu = depositoCombustible;


				return recarga;

			}
			catch (Exception ex)
			{

				throw new Exception("BLL RecargarCombustible error al Buscar recarga por id factur: "+ex.Message,ex);
			}
        }

        public void RegistrarRecargaCombustible(RecargaCombustible recargaCombu)
        {
			try
			{
				if (recargaCombu.FacturaCombu == null || recargaCombu.FacturaCombu.IdFactura <= 0) throw new Exception("la recarga no tiene el id de factura correspondiente o esta es nula");
				if (recargaCombu.ProveedorCombu == null|| recargaCombu.ProveedorCombu.IdProveedorCombustible<=0) throw new Exception("el proveedor de la recarga no puede ser nulo o su id invalido");
				if (recargaCombu.DepositoCombu == null || recargaCombu.DepositoCombu.IdDepositoCombustible <= 0) throw new Exception("el deposito de la recarga no puede ser nulo o su id invalido");
				if (recargaCombu.PrecioLitros <= 0) throw new Exception(" el precio debe ser positivo");
				if (recargaCombu.CantidadLitros <= 0) throw new Exception("la cantidad de litros debe ser positiva ");

			    RecargarCombustibleDAO.RegistrarRecargaCombu(recargaCombu);

			}
			catch (Exception ex)
			{

				throw new Exception("BLL RecargarCombustible error al registra recarga: "+ex.Message,ex);
			}
        }
    }
}
