using DAL;
using ENTITY;
using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacturaMantenimientoBLL
    {
        FacturaMantenimientoDAL FacturaMantenimientoDAO = new FacturaMantenimientoDAL();

        public void EliminarFacturaMantenimiento(FacturaMantenimiento facturaMantenimiento)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();
            try
            {
                if (facturaMantenimiento == null || facturaMantenimiento.IdFactura <= 0) throw new Exception("factura nula o con id invalido");
                if (facturaMantenimiento.Mantenimiento == null || facturaMantenimiento.Mantenimiento.IdMantenimiento <=0) throw new Exception("La factura debe tener asociado un mantenimiento no nulo o con id valido");
                if (facturaMantenimiento.Transaccion != null) throw new Exception("No se puede eliminar una factura que ya ha sido pagada");
                if (facturaMantenimiento.Mantenimiento.Aeronave == null || facturaMantenimiento.Mantenimiento.Aeronave.IdAeronave <= 0) throw new Exception("El mantenimiento de la factura no tiene asociada la aeronave o su id es invalido");
                if (!facturaMantenimiento.IdFactura.Equals(facturaMantenimiento.Mantenimiento.FacturaMantenimiento.IdFactura)) throw new Exception("error de inconsistencia de datos en los id de la factura");

                FacturaMantenimientoDAO.EliminarFacturaMantenimiento(facturaMantenimiento.IdFactura);

                MantenimientoBLL MantenimientoBLO = new MantenimientoBLL();
                
                MantenimientoBLO.EliminarFacturaDeMantenimiento(facturaMantenimiento.Mantenimiento);

            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(ds);
                throw  new Exception("BLL FacturaMantenimiento erro al eliminar factura mantenimiento: "+ex.Message,ex);
            }
        }

        public FacturaMantenimiento BuscarFacturaMPorId(int idFactura)
        {
            try
            {
                if (idFactura <= 0) throw new Exception("Id Invalido");

                FacturaMantenimiento factura = FacturaMantenimientoDAO.BuscarFacturaMPorId(idFactura);
                MantenimientoBLL MantenimientoBLL = new MantenimientoBLL();
                Mantenimiento mantenimiento = MantenimientoBLL.BuscarMantenimientoPorIdFactura(idFactura);
                if (mantenimiento == null || mantenimiento.IdMantenimiento <= 0) throw new Exception(" no se encontro el mantenimiento asociado a la factura");
                factura.Mantenimiento= mantenimiento;
                return factura;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL FacturaMatenimiento error al buscar factura por id: "+ex.Message,ex);
            }
        }


        public List<FacturaMantenimiento> ObtenerTodos()
        {
            try
            {
                List<FacturaMantenimiento> LFacturas = FacturaMantenimientoDAO.ObtenerTodos();
                MantenimientoBLL MantenimientoBLO = new MantenimientoBLL();
                TransaccionFinancieraBLL TransaccionFinancieraBLO = new TransaccionFinancieraBLL();
                foreach (FacturaMantenimiento factura in LFacturas)
                {
                    
                   Mantenimiento mantenimiento =  MantenimientoBLO.BuscarMantenimientoPorIdFactura(factura.IdFactura);
                   if (mantenimiento == null) throw new Exception("no se encontro el mantenimiento asociado a la factura");
                   factura.Mantenimiento = mantenimiento;
                    TransaccionFinanciera transaccionFinanciera = TransaccionFinancieraBLO.BuscarTransaccionPorIdFactura(factura.IdFactura);
                    if(transaccionFinanciera != null)
                    {
                        factura.Transaccion = transaccionFinanciera;
                    }
                }
                return LFacturas;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL FacturaMantenimiento error al obtener todos las facturas: " +ex.Message,ex);
            }
           
        }

        public void RegistrarFactura(FacturaMantenimiento facturaMantenimiento)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();
            try
            {
                if (facturaMantenimiento == null) throw new Exception("La factura no puede ser nula");
                if(facturaMantenimiento.Transaccion!=null) throw new Exception("No se pueed registrar una factura con el pago ya realizado. este debe ser nulo en su alta");
                if (facturaMantenimiento.Mantenimiento == null || facturaMantenimiento.Mantenimiento.IdMantenimiento <= 0) throw new Exception("La factura debe tener un mantenimiento no nulo o con id valido asociada");
                if (facturaMantenimiento.Mantenimiento.FacturaMantenimiento != null && facturaMantenimiento.Mantenimiento.FacturaMantenimiento.IdFactura > 0)throw new Exception("El mantenimiento ya tiene una factura registrada.");

                if (facturaMantenimiento.MontoTotal <= 0) throw new Exception("el monto de la factura debe ser mayor a 0");
                if (facturaMantenimiento.Mantenimiento.Aeronave == null || facturaMantenimiento.Mantenimiento.Aeronave.IdAeronave <= 0) throw new Exception("El mantenimiento a registrar la factura no tiene aeronave asociada o el id de esta es invalido");
                if (facturaMantenimiento.FechaFactura.Date > DateTime.Now.Date || facturaMantenimiento.FechaFactura.Date < facturaMantenimiento.Mantenimiento.Fecha.Date) throw new Exception("La fecha de la factura no puede ser mayor a dia de hoy ni inferior a la fecha en la que se contrato el mantenimiento");




                if (facturaMantenimiento.Mantenimiento.Mecanico == null || string.IsNullOrEmpty(facturaMantenimiento.Mantenimiento.Mecanico.CuitCuil)) throw new Exception("El mecanico del mantenimiento es nulo o no tiene Cuit");
                facturaMantenimiento.CuilEmisor = facturaMantenimiento.Mantenimiento.Mecanico.CuitCuil;

                if (FacturaMantenimientoDAO.ExisteFacturaConCuilYNro(facturaMantenimiento.CuilEmisor, facturaMantenimiento.NroFactura)) throw new Exception("ya existe una factura con ese numero de ese cuit");
                FacturaMantenimientoDAO.RegistrarFactura(facturaMantenimiento);

                if (facturaMantenimiento.IdFactura <= 0) throw new Exception("error al obtener el id de la factura");
                facturaMantenimiento.Mantenimiento.FacturaMantenimiento = new FacturaMantenimiento(){IdFactura = facturaMantenimiento.IdFactura, FechaFactura=facturaMantenimiento.FechaFactura};

            
                
                MantenimientoBLL MantenimientoBLO = new MantenimientoBLL();
                MantenimientoBLO.RegistrarFacturaMant(facturaMantenimiento.Mantenimiento);

            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("BLL FacturaMantenimiento error al registrar la factura: "+ex.Message,ex);
            }
        }

        public FacturaMantenimiento BuscarFacturaMantPorIdParaTransaccion(int idFactura)
        {
            try
            {
                if (idFactura <= 0) throw new Exception("id factura invalido");
                FacturaMantenimiento factura = FacturaMantenimientoDAO.BuscarFacturaMPorId(idFactura);
                MantenimientoBLL MantenimientoBLL = new MantenimientoBLL();
                Mantenimiento mantenimiento = MantenimientoBLL.BuscarMantenimientoPorIdFactura(idFactura);
                if (mantenimiento == null || mantenimiento.IdMantenimiento <= 0) throw new Exception(" no se encontro el mantenimiento asociado a la factura");
                factura.Mantenimiento = mantenimiento;

                return factura;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL Factura Mantenimiento error al buscar factura mantenimiento para transaccion: "+ex.Message,ex);
            }
        }
    }
}
