﻿using DAL;
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

        internal void AltaSolicitudHoras(SolicitudHoras solicitud)
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
				if (solicitud.ValorHoraVuelo < 0) throw new Exception("El valor por hora de vuelo no puede ser negativo");
				if (solicitud.ValorHoraSimulador < 0) throw new Exception("El valor por hora de simulador no puede ser negativo");
				if (solicitud.Cliente == null) throw new Exception("Debe seleccionar un cliente para la solicitud de horas.");	
				
            }
			catch (Exception ex)
			{
				throw new Exception("BLL Solicitud Horas error al validar solicitud: "+ex.Message,ex);
			}
        }

        internal SolicitudHoras BuscarSolicitudPorIdFactura(int idFactura)
        {
			try
			{
				if(idFactura <= 0) throw new Exception("El ID de solicitud debe ser un ID válido.");
                //TODO: podria cargar el cliente de la solicitud si es necesario.
                return SolicitudHorasDAO.BuscarSolicitudPorIdFactura(idFactura); // Buscar la solicitud de horas por ID en la base de datos o archivo XML
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
				if(solicitudHoras.Factura.Transaccion!=null) throw new Exception("La solicitud de horas debe tener una transacción asociada a la factura.");

                FacturaSolicitudHorasBLL FacturaSolicitudHorasBLO = new FacturaSolicitudHorasBLL(); // Instancia de FacturaSolicitudHorasBLL para manejar facturas asociadas a solicitudes
				FacturaSolicitudHorasBLO.EliminarFacturaPorId(solicitudHoras.Factura.IdFactura); // Eliminar la factura asociada a la solicitud de horas
                Result result = HelperFacturas.EliminarFacturaPDF((int)EnumTiposFactura.FacturaSolicitudHoras, solicitudHoras.Factura.NroFactura);
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
