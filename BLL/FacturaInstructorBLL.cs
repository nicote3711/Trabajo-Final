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
    public class FacturaInstructorBLL
    {
        FacturaInstructorDAL FacturaInstructorDAO =new FacturaInstructorDAL();

        public void EliminarFactura(FacturaInstructor facturaInstructor)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();
            try
            {
                if (facturaInstructor.IdFactura == null || facturaInstructor.IdFactura <= 0) throw new Exception("Id de factura nulo o invalido.");
                if (facturaInstructor.ListaLiquidaciones == null || facturaInstructor.ListaLiquidaciones.Count <= 0) throw new Exception("Lista de liquidaciones de la factura nula o vacia");

                FacturaInstructorDAO.EliminarFactura(facturaInstructor.IdFactura);
                Result result = HelperFacturas.EliminarFacturaPDF((int)EnumTiposFactura.FacturaInstructor, facturaInstructor.NroFactura);
                LiquidacionInstructorBLL LiquidacionInstructorBLO = new LiquidacionInstructorBLL();
                foreach(LiquidacionInstructor liquidacion in facturaInstructor.ListaLiquidaciones)
                {
                    LiquidacionInstructorBLO.QuitarIdFacturaALiquidacion(liquidacion);
                }
            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(ds);
                throw;
            }
        }

        public List<FacturaInstructor> ObtenerFacturas()
        {
            try
            {
                List<FacturaInstructor> LFacturasInstructor = FacturaInstructorDAO.ObtenerFacturas();
                LiquidacionInstructorBLL LiquidacionInstructorBLO = new LiquidacionInstructorBLL();

                foreach (FacturaInstructor factura in LFacturasInstructor)
                {
                    factura.ListaLiquidaciones = LiquidacionInstructorBLO.ObtenerLiquidacionesPorIdFactura(factura.IdFactura);
                }
                return LFacturasInstructor;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL FacturaInstructor error al obtener Facturas");
            }
        }

        public void RegistrarFacturaInstructor(FacturaInstructor facturaInstructor)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();
            try
            {
                if (facturaInstructor == null) throw new ArgumentNullException("La factura no puede ser nula");
                if (facturaInstructor.ListaLiquidaciones == null || facturaInstructor.ListaLiquidaciones.Count <= 0) throw new ArgumentNullException("La lista de liquidaciones de la factura no puede esta vacia o ser nula ");
                if (facturaInstructor.MontoTotal <= 0) throw new Exception("El monto total no puede ser 0 o menor que 0");
                if (string.IsNullOrEmpty(facturaInstructor.CuilEmisor)) throw new Exception("El cuit no puede ser nulo o vaico");

                FacturaInstructorDAO.RegistrarFactura(facturaInstructor);
                if (facturaInstructor.IdFactura == null || facturaInstructor.IdFactura <=0) throw new Exception("El id de la factura es nulo o invalido");

                LiquidacionInstructorBLL LiquidacionInstructorBLO = new LiquidacionInstructorBLL();

                foreach(LiquidacionInstructor liquidacion in facturaInstructor.ListaLiquidaciones)
                {
                    liquidacion.IdFactura = facturaInstructor.IdFactura;
                    LiquidacionInstructorBLO.AsignarIdFacturaALiquidacion(liquidacion); 
                }

                //Generar FacturaPDF
                Result result = HelperFacturas.GenerarFacturaPDF(facturaInstructor);
                if (!result.Success)
                    throw new Exception(result.Message);
            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("BLL Factura Instructor error al registrar la factura: "+ex.Message,ex);
            }
        }
    }
}
