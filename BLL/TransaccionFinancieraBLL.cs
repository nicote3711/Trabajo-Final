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
using System.Transactions;

namespace BLL
{
    public class TransaccionFinancieraBLL
    {
		TransaccionFinancieraDAL TransaccionFinancieraDAO = new TransaccionFinancieraDAL();
        public void RegistrarCobroHoras(TransaccionFinanciera transaccionFinanciera)
        {
			HelperTransaccion helperTransaccion = new HelperTransaccion();
			DataSet ds = helperTransaccion.DfParaTransaccion();
			try
			{
				ValidarTransaccion(transaccionFinanciera);


                TipoTransaccionBLL TipoTransaccionBLO = new TipoTransaccionBLL();
				TipoTransaccion tipoTransaccion = TipoTransaccionBLO.BuscarPorId((int)EnumTipoTransaccion.CobroSolictudHoras);
				if (tipoTransaccion == null) throw new Exception("no se encontro el tipo de transaccion para cobro de horas");

				transaccionFinanciera.TipoTransaccion = tipoTransaccion;
				transaccionFinanciera.IdFactura = transaccionFinanciera.Factura.IdFactura;


                FacturaSolicitudHoras facturaSolicitud = (FacturaSolicitudHoras)transaccionFinanciera.Factura; // se podria validar.
				if (facturaSolicitud.Solicitud.Cliente==null || facturaSolicitud.Solicitud.Cliente.IDCliente<=0) throw new Exception("no se encontro al cliente para acreditar el saldo abonado");
				ClienteBLL ClienteBLO = new ClienteBLL();
				if(facturaSolicitud.Solicitud.CantidadHorasVuelo>0)
				{
                    ClienteBLO.AcreditarSaldoVuelo(facturaSolicitud.Solicitud.Cliente.IDCliente, facturaSolicitud.Solicitud.CantidadHorasVuelo);
                }
				if(facturaSolicitud.Solicitud.CantidadHorasSimulador>0)
				{
					ClienteBLO.AcreditarSaldoSimulador(facturaSolicitud.Solicitud.Cliente.IDCliente,facturaSolicitud.Solicitud.CantidadHorasSimulador);
				}

				

                TransaccionFinancieraDAO.RegistrarTransaccion(transaccionFinanciera);

			}
			catch (Exception ex)
			{
				helperTransaccion.RollbackDfParaTransaccion(ds);
				throw new Exception("BLL TransaccionFinanciera error al registrar cobro horas: "+ex.Message,ex);
			}
        }

		public TransaccionFinanciera BuscarTransaccionPorIdFactura(int IdFactura)
		{
			try
			{
                TransaccionFinanciera transaccion = TransaccionFinancieraDAO.BuscarTransaccionPorIdFactura(IdFactura);
				if (transaccion == null) return null;

                FormaPagoBLL FormaPagoBLO = new FormaPagoBLL();
                FormaPago formaPago = FormaPagoBLO.BuscarFormaPagoPorId(transaccion.FormaPago.IdFormaPago);
                if (formaPago == null) throw new Exception("error al obtener la forma de pago de la transaccion");
				transaccion.FormaPago = formaPago;

				TipoTransaccionBLL TipoTransaccionBLO = new TipoTransaccionBLL();
				TipoTransaccion tipoTransaccion = TipoTransaccionBLO.BuscarPorId(transaccion.TipoTransaccion.IdTipoTransaccion);
				if (tipoTransaccion == null) throw new Exception("error al obtener el tipo de la transaccion");
				transaccion.TipoTransaccion = tipoTransaccion;

                return transaccion;
            }
			catch (Exception ex)
			{

				throw new Exception("BLL TransaccionFinanciera error al buscar transaccion por id factura: "+ex.Message,ex);
			}
	
		}

        public List<TransaccionFinanciera> ObtenerTodas()
        {
			try
			{
				List<TransaccionFinanciera> LTransaccionesF = TransaccionFinancieraDAO.ObtenerTodas();

                TipoTransaccionBLL TipoTransaccionBLO = new TipoTransaccionBLL();
                FormaPagoBLL FormaPagoBLO = new FormaPagoBLL();
                FacturaSolicitudHorasBLL facturaSolicitudHorasBLO = new FacturaSolicitudHorasBLL();

                foreach (TransaccionFinanciera  transaccion in LTransaccionesF)
				{
                    
                    FormaPago formaPago = FormaPagoBLO.BuscarFormaPagoPorId(transaccion.FormaPago.IdFormaPago);
                    if (formaPago == null) throw new Exception("error al obtener la forma de pago de la transaccion");
                    transaccion.FormaPago = formaPago;

                    
                    TipoTransaccion tipoTransaccion = TipoTransaccionBLO.BuscarPorId(transaccion.TipoTransaccion.IdTipoTransaccion);
                    if (tipoTransaccion == null) throw new Exception("error al obtener el tipo de la transaccion");
                    transaccion.TipoTransaccion = tipoTransaccion;

					

					Factura factura = BuscarFacturaParaTransaccionPorId(transaccion.IdFactura, transaccion.TipoTransaccion);
					if (factura == null) throw new Exception("no se econtro la factura de la transaccion");
					
					transaccion.Factura = factura;

                }
				return LTransaccionesF;
			}
			catch (Exception ex)
			{

				throw new Exception("BLL TransaccionFinanciera error al obtener todas: "+ex.Message,ex);
			}
        }

        private Factura BuscarFacturaParaTransaccionPorId(int idFactura, TipoTransaccion tipoTransaccion)
        {
			try
			{
				if(tipoTransaccion==null || tipoTransaccion.IdTipoTransaccion<=0) throw new Exception("el tipo de transaccion es nulo o invalido");

                switch (tipoTransaccion.IdTipoTransaccion)
                {
                   
                    case (int)EnumTipoTransaccion.PagoInstructor:
                        FacturaInstructorBLL FacturaInstructorBLO = new FacturaInstructorBLL();
                        return FacturaInstructorBLO.BuscarFacturaInstructorPorIdParaTransaccion(idFactura);

                    case (int)EnumTipoTransaccion.PagoDueño:
                        FacturaDuenoBLL FacturaDuenoBLO = new FacturaDuenoBLL();
                        return FacturaDuenoBLO.BuscarFacturaDuenoPorIdParaTransaccion(idFactura);

                    case (int)EnumTipoTransaccion.CobroSolictudHoras:
                        FacturaSolicitudHorasBLL FacturaSolicitudHorasBLO = new FacturaSolicitudHorasBLL();
                        return FacturaSolicitudHorasBLO.BuscarFacturaSolicitudPorIdParaTransaccion(idFactura);

                    case (int)EnumTipoTransaccion.PagoMantenimientoMecanico:
                        FacturaMantenimientoBLL FacturaMantenimientoBLO = new FacturaMantenimientoBLL();
                        return FacturaMantenimientoBLO.BuscarFacturaMantPorIdParaTransaccion(idFactura);

                    case (int)EnumTipoTransaccion.PagoCombustible:
                        FacturaCombustibleBLL FacturaCombustibleBLO = new FacturaCombustibleBLL();
                        return FacturaCombustibleBLO.BuscarFacturaCombuPorIdParaTransaccion(idFactura);

                    default:
                        throw new Exception("Tipo de transacción no soportado.");
                }


            }
			catch (Exception ex)
			{

				throw new Exception("BLL TransaccionFinanciera error al buscar la factura para la transaccion por id: "+ex.Message,ex);
			}
        }

        public void EliminarCobroHoras(TransaccionFinanciera transaccionFinanciera)
        {
			HelperTransaccion helperTransaccion = new HelperTransaccion();
			DataSet ds = helperTransaccion.DfParaTransaccion();
			try
			{
				if (transaccionFinanciera == null || transaccionFinanciera.IdTransaccionFinanciera <= 0) throw new Exception("la transaccion que desea eliminar es nula o su id es invalido");
				if (transaccionFinanciera.Factura == null || transaccionFinanciera.Factura.IdFactura != transaccionFinanciera.IdFactura || transaccionFinanciera.IdFactura <= 0) throw new Exception("error factura nula , o incongruencia de id factura con objeto id factura o id factura invalido");	
				if (!(transaccionFinanciera.Factura is FacturaSolicitudHoras fsh)) throw new Exception("la factura asociada ala transaccion no es del tipo correcto");
				if (fsh.Solicitud == null || fsh.Solicitud.IdSolicitudHoras<=0) throw new Exception("error en la factura solicitud, la solictud es nula oo su id invalidos");
				if (fsh.Solicitud.Cliente == null || fsh.Solicitud.Cliente.IDCliente <= 0) throw new Exception("erro en solicitud, su cliente es nulo o su id es invalido");

				TransaccionFinancieraDAO.EliminarTransaccionPorId(transaccionFinanciera.IdTransaccionFinanciera);
				ClienteBLL ClienteBLO = new ClienteBLL();
				if(fsh.Solicitud.CantidadHorasVuelo>0)
				{
					ClienteBLO.DescontarSaldoVuelo(fsh.Solicitud.Cliente.IDCliente,fsh.Solicitud.CantidadHorasVuelo);
				}
				if(fsh.Solicitud.CantidadHorasSimulador>0)
				{
					ClienteBLO.DescontarHorasSimulador( fsh.Solicitud.Cliente.IDCliente, fsh.Solicitud.CantidadHorasSimulador);
				}
			}
			catch (Exception ex)
			{
				helperTransaccion.RollbackDfParaTransaccion(ds);
				throw new Exception("BLL TransaccionFinanciera error al eliminar cobro horas: "+ex.Message,ex);
			}
        }

        public void RegistrarPagoDueno(TransaccionFinanciera transaccionFinanciera)
        {
			try
            {
                ValidarTransaccion(transaccionFinanciera);

                TipoTransaccionBLL TipoTransaccionBLO = new TipoTransaccionBLL();
                TipoTransaccion tipoTransaccion = TipoTransaccionBLO.BuscarPorId((int)EnumTipoTransaccion.PagoDueño);
                if (tipoTransaccion == null) throw new Exception("no se encontro el tipo de transaccion para pago dueño");

                transaccionFinanciera.TipoTransaccion = tipoTransaccion;
                transaccionFinanciera.IdFactura = transaccionFinanciera.Factura.IdFactura;

                TransaccionFinancieraDAO.RegistrarTransaccion(transaccionFinanciera);

            }
            catch (Exception ex)
			{

				throw new Exception("BLL TransaccionFinanciera error al regitrar paro dueño: "+ex.Message,ex);
			}
        }

        private  void ValidarTransaccion(TransaccionFinanciera transaccionFinanciera)
        {
			try
			{
                if (transaccionFinanciera.Factura == null || transaccionFinanciera.Factura.IdFactura <= 0) throw new Exception("la factura de la transaccion es nula o su id es invalido");
                if (transaccionFinanciera.FechaTransaccion.Date < transaccionFinanciera.Factura.FechaFactura.Date) throw new Exception("la fecha de la transaccion no puede ser anterior a la factura");
                if (transaccionFinanciera.MontoTransaccion <= 0) throw new Exception("el monto de la transaccion debe ser un monto valido");
                if (transaccionFinanciera.ReferenciaExterna == null && transaccionFinanciera.FormaPago.IdFormaPago.Equals((int)EnumFormaPago.Transferencia)) throw new Exception("las transacciones por transferencia refquieren el numero de referencia externa");
                if (transaccionFinanciera.ReferenciaExterna != null && transaccionFinanciera.FormaPago.IdFormaPago.Equals((int)EnumFormaPago.Efectivo)) throw new Exception("las opereciones en efectivo no poseen referencia externa");

				TransaccionFinanciera trf = TransaccionFinancieraDAO.BuscarTransaccionPorIdFactura(transaccionFinanciera.Factura.IdFactura);
				if (trf != null) throw new Exception($"ya existe una transaccion para el id de factura {transaccionFinanciera.Factura.IdFactura}");
            }
			catch (Exception ex)
			{

				throw new Exception("erro al validar transaccion: "+ex.Message,ex);
			}
    
        }

        public void EliminarPagoDueno(TransaccionFinanciera transaccionFinanciera)
        {
			try
			{
                if (transaccionFinanciera == null || transaccionFinanciera.IdTransaccionFinanciera <= 0) throw new Exception("la transaccion que desea eliminar es nula o su id es invalido");
                if (transaccionFinanciera.Factura == null || transaccionFinanciera.Factura.IdFactura != transaccionFinanciera.IdFactura || transaccionFinanciera.IdFactura <= 0) throw new Exception("error factura nula , o incongruencia de id factura con objeto id factura o id factura invalido");
                if (!(transaccionFinanciera.Factura is FacturaDueno fd)) throw new Exception("la factura asociada a la transaccion no es del tipo correcto");

                TransaccionFinancieraDAO.EliminarTransaccionPorId(transaccionFinanciera.IdTransaccionFinanciera);
            }
			catch (Exception ex)
			{

				throw new Exception("BLL TransaccionFinanciera error al eliminar pago dueño: "+ex.Message,ex);
			}
        }

        public void RegistrarPagoInstructor(TransaccionFinanciera transaccionFinanciera)
        {
			try
			{
                ValidarTransaccion(transaccionFinanciera);

                TipoTransaccionBLL TipoTransaccionBLO = new TipoTransaccionBLL();
                TipoTransaccion tipoTransaccion = TipoTransaccionBLO.BuscarPorId((int)EnumTipoTransaccion.PagoInstructor);
                if (tipoTransaccion == null) throw new Exception("no se encontro el tipo de transaccion para pago dueño");

                transaccionFinanciera.TipoTransaccion = tipoTransaccion;
                transaccionFinanciera.IdFactura = transaccionFinanciera.Factura.IdFactura;

                TransaccionFinancieraDAO.RegistrarTransaccion(transaccionFinanciera);
            }
			catch (Exception ex)
			{

				throw new Exception("BLL TransaccionFinanciera error al registrar pago instructor: "+ex.Message,ex);
			}
        }

        public void EliminarPagoInstructor(TransaccionFinanciera transaccionFinanciera)
        {
			try
			{
                if (transaccionFinanciera == null || transaccionFinanciera.IdTransaccionFinanciera <= 0) throw new Exception("la transaccion que desea eliminar es nula o su id es invalido");
                if (transaccionFinanciera.Factura == null || transaccionFinanciera.Factura.IdFactura != transaccionFinanciera.IdFactura || transaccionFinanciera.IdFactura <= 0) throw new Exception("error factura nula , o incongruencia de id factura con objeto id factura o id factura invalido");
                if (!(transaccionFinanciera.Factura is FacturaInstructor fi)) throw new Exception("la factura asociada a la transaccion no es del tipo correcto");

                TransaccionFinancieraDAO.EliminarTransaccionPorId(transaccionFinanciera.IdTransaccionFinanciera);
            }
			catch (Exception ex)
			{

				throw new Exception("BLL TransaccionFinanciera error al eliminar pago instructor: "+ex.Message,ex);
			}
        }
    }
}
