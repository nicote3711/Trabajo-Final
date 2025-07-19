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
    public class SolicitudHorasBLL
    {
		SolicitudHorasDAL SolicitudHorasDAO = new SolicitudHorasDAL();


        public List<SolicitudHoras> ObtenerSolicitudesHoras()
		{
			try
			{
                ClienteBLL ClienteBLO = new ClienteBLL(); // Instancia de ClienteBLL para obtener clientes asociados a las solicitudes
                FacturaSolicitudHorasBLL FacturaSolicitudHorasBLO= new FacturaSolicitudHorasBLL(); // Instancia de FacturaSolicitudHorasBLL para manejar facturas asociadas a solicitudes

                List<SolicitudHoras> LSolicitudes = SolicitudHorasDAO.ObtenerSolicitudesHoras();
				
				foreach (SolicitudHoras solicitud in LSolicitudes)
				{

                    solicitud.Cliente = ClienteBLO.BuscarClientePorID(solicitud.Cliente.IDCliente); // Obtener el cliente asociado a la solicitud

                    ValidarSolicitudHoras(solicitud); // Validar la solicitud antes de dar de alta
                    if (solicitud.Factura == null) throw new Exception("La solicitud de horas debe tener una factura asociada.");
                    if (solicitud.Factura.IdFactura == null) throw new Exception("La solicitud de horas debe tener un ID de factura válido.");
                    if (solicitud.Factura.IdFactura <= 0) throw new Exception("El ID de factura debe ser un ID Valido.");

                    solicitud.Factura = FacturaSolicitudHorasBLO.BuscarFacturaPorId(solicitud.Factura.IdFactura);// Aca prodia buscar la factura asociada a la solicitud por Id Factura si es necesario, pero no se hace por el momento.
                }
                return LSolicitudes;
            }
			catch (Exception)
			{

				throw;
			}
		}

        public void AltaSolicitudHoras(SolicitudHoras solicitud)
        {
			try
			{

				ValidarSolicitudHoras(solicitud); // Validar la solicitud antes de dar de alta
				if(solicitud.Factura==null) throw new Exception("La solicitud de horas debe tener una factura asociada.");
				if(solicitud.Factura.IdFactura ==null) throw new Exception("La solicitud de horas debe tener un ID de factura válido.");
				if(solicitud.Factura.IdFactura<=0) throw new Exception("El ID de factura debe ser un ID Valido.");	

				SolicitudHorasDAO.AltaSolicitudHoras(solicitud); // Registrar la solicitud de horas en la base de datos o archivo XML


            }
			catch (Exception ex)
			{

				throw new Exception("BLL solicitudHoras error al dar alta de solicitud: "+ ex.Message,ex);
			}
        }

        public void ValidarSolicitudHoras(SolicitudHoras solicitud)
        {
			try
			{
				if (solicitud.CantidadHorasVuelo < 0) throw new Exception("La cantidad de horas no puede ser negativa");
				if (solicitud.CantidadHorasSimulador < 0) throw new Exception("La cantidad de horas de simulador no puede ser negativa");
				if (solicitud.CantidadHorasVuelo == 0 && solicitud.CantidadHorasSimulador == 0) throw new Exception("La cantidad de horas de vuelo y simulador no pueden ser 0 simultaneamente");
				if (solicitud.ValorHoraVuelo <= 0) throw new Exception("El valor por hora de vuelo no puede ser negativo o 0");
				if (solicitud.ValorHoraSimulador <= 0) throw new Exception("El valor por hora de simulador no puede ser negativo o 0");
				if (solicitud.Cliente == null) throw new Exception("Debe seleccionar un cliente para la solicitud de horas.");
				if (solicitud.FechaSolicitud.Date > DateTime.Now.Date) throw new Exception("la fecha no puede ser posterior a la de hoy");
            }
			catch (Exception ex)
			{
				throw new Exception("BLL Solicitud Horas error al validar solicitud: "+ex.Message,ex);
			}
        }

        public SolicitudHoras BuscarSolicitudPorIdFactura(int idFactura)
        {
			try
			{
				if(idFactura <= 0) throw new Exception("El ID de solicitud debe ser un ID válido.");
                //TODO: podria cargar el cliente de la solicitud si es necesario.
				SolicitudHoras solicitud = SolicitudHorasDAO.BuscarSolicitudPorIdFactura(idFactura);
				if (solicitud == null) throw new Exception($"no se encontro la solicitud para la factura id {idFactura}");

                ClienteBLL ClienteBLO = new ClienteBLL();
                solicitud.Cliente = ClienteBLO.BuscarClientePorID(solicitud.Cliente.IDCliente);
				if (solicitud.Cliente == null) throw new Exception($"no se encontro al cliente con id {solicitud.Cliente.IDCliente}");

				return solicitud; 
            }
			catch (Exception ex)
			{

				throw new Exception ("BLL SolicitudHoras error al buscar solicitud por id: "+ex.Message,ex);
			}
        }

		public void EliminarSolicitudHoras(SolicitudHoras solicitudHoras)
		{
			HelperTransaccion helperTransaccion = new HelperTransaccion();
			DataSet ds = helperTransaccion.DfParaTransaccion();
            try
			{
				if(solicitudHoras.Factura== null) throw new Exception("La solicitud de horas debe tener una factura asociada.");
				if(solicitudHoras.Factura.IdFactura ==null) throw new Exception("La solicitud de horas debe tener un ID de factura válido.");
				if(solicitudHoras.Factura.Transaccion!=null) throw new Exception("La factura de la solicitud ya fue cobrada y no puede darse de baja.");

                FacturaSolicitudHorasBLL FacturaSolicitudHorasBLO = new FacturaSolicitudHorasBLL(); // Instancia de FacturaSolicitudHorasBLL para manejar facturas asociadas a solicitudes
				FacturaSolicitudHorasBLO.EliminarFacturaPorId(solicitudHoras.Factura.IdFactura); // Eliminar la factura asociada a la solicitud de horas
                Resultado result = HelperFacturas.EliminarFacturaPDF((int)EnumTiposFactura.FacturaSolicitudHoras, solicitudHoras.Factura.NroFactura);
                SolicitudHorasDAO.EliminarSolicitudHorasPorId(solicitudHoras.IdSolicitudHoras); // Eliminar la solicitud de horas por ID en la base de datos o archivo XML

            }
			catch (Exception ex)
			{
				helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("BLL SolicitudHoras error al eliminar Solicitud Horas: "+ ex.Message,ex);
			}
		}
    }
}
