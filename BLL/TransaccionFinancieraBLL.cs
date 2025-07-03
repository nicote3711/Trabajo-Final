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
				if (transaccionFinanciera.Factura == null || transaccionFinanciera.Factura.IdFactura <= 0) throw new Exception("la factura de la transaccion es nula o su id es invalido");
				if (transaccionFinanciera.FechaTransaccion.Date < transaccionFinanciera.Factura.FechaFactura.Date) throw new Exception("la fecha de la transaccion no puede ser anterior a la factura");
				if (transaccionFinanciera.MontoTransaccion <= 0) throw new Exception("el monto de la transaccion debe ser un monto valido");
				if (transaccionFinanciera.ReferenciaExterna == null && transaccionFinanciera.FormaPago.IdFormaPago.Equals((int)EnumFormaPago.Transferencia)) throw new Exception("las transacciones por transferencia refquieren el numero de referencia externa");
				if (transaccionFinanciera.ReferenciaExterna != null && transaccionFinanciera.FormaPago.IdFormaPago.Equals((int)EnumFormaPago.Efectivo)) throw new Exception("las opereciones en efectivo no poseen referencia externa");

                


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

				foreach(TransaccionFinanciera  transaccion in LTransaccionesF)
				{
                    FormaPagoBLL FormaPagoBLO = new FormaPagoBLL();
                    FormaPago formaPago = FormaPagoBLO.BuscarFormaPagoPorId(transaccion.FormaPago.IdFormaPago);
                    if (formaPago == null) throw new Exception("error al obtener la forma de pago de la transaccion");
                    transaccion.FormaPago = formaPago;

                    TipoTransaccionBLL TipoTransaccionBLO = new TipoTransaccionBLL();
                    TipoTransaccion tipoTransaccion = TipoTransaccionBLO.BuscarPorId(transaccion.TipoTransaccion.IdTipoTransaccion);
                    if (tipoTransaccion == null) throw new Exception("error al obtener el tipo de la transaccion");
                    transaccion.TipoTransaccion = tipoTransaccion;

					
                }
				return LTransaccionesF;
			}
			catch (Exception ex)
			{

				throw new Exception("BLL TransaccionFinanciera error al obtener todas: "+ex.Message,ex);
			}
        }
    }
}
