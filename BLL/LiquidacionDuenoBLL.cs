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
	public class LiquidacionDuenoBLL
    {
		LiquidacionDuenoDAL LiquidacionDuenoDAO = new LiquidacionDuenoDAL();	
        
        public List<LiquidacionDueno> ObtenerLiquidacionesDPorPeriodo(DateTime periodo)
        {
			try
			{
				VueloBLL VueloBLO = new VueloBLL();

                List<LiquidacionDueno> LLiquidacionesD =  LiquidacionDuenoDAO.ObtenerLiquidacionesDPorPeriodo(periodo);          

                return LLiquidacionesD;

			}
			catch (Exception ex)
			{

				throw new Exception("BLL LiquidacionDueno error al obtener liquidaciones:"+ex.Message,ex);
			}
        }

        public List<LiquidacionDueno> ObtenerLiquidacionesDPorIdPersonaDueño(int idPersona)
        {
            try
            {
                if (idPersona == null || idPersona <= 0) throw new Exception("El id de persona del dueño es un id nulo o invalido");
                List<LiquidacionDueno> LLiquidacionesD = LiquidacionDuenoDAO.ObtenerLiquidacionesDPorIdPersonaDueño(idPersona);
                DuenoBLL DuenoBLO = new DuenoBLL();
                VueloBLL VueloBLO = new VueloBLL();
                ServicioBLL servicioBLO = new ServicioBLL();
                foreach (LiquidacionDueno liquidacion in LLiquidacionesD)
                {

                    Dueno dueno = DuenoBLO.BuscarDuenoPorIdPersona(liquidacion.Persona.IDPersona); // TO DO: Metodo
                    if (dueno == null) throw new Exception("Error al obtener el dueño para la liquidacion");
                    liquidacion.Persona = dueno;
                    liquidacion.Servicio = servicioBLO.BuscarServicioPorID(liquidacion.Servicio.IdServicio);

                    List<Vuelo> vuelosCompletos = new List<Vuelo>();
                    foreach (Vuelo vueloIncompleto in liquidacion.Vuelos)
                    {
                        Vuelo vueloCompleto = VueloBLO.BuscarVueloPorId(vueloIncompleto.IdVuelo);
                        if (vueloCompleto == null) throw new Exception("Vuelo no encontrado");

                        vuelosCompletos.Add(vueloCompleto);


                    }
                    liquidacion.Vuelos = vuelosCompletos;   
                }
                return LLiquidacionesD;
            }
            catch (Exception ex)
            {

                throw new Exception("BLL LiquidacionDueño error al obtener las liquidaciones por Dueño: "+ ex.Message,ex);
            }
        }


        internal void GenerarLiquidacion(LiquidacionDueno liquidacionD)
        {
			
               // HelperTransaccion helperTransaccion = new HelperTransaccion();
               // DataSet ds = helperTransaccion.DfParaTransaccion();
            try
            {
                if (liquidacionD.IdPersona == null || liquidacionD.IdPersona <= 0) throw new Exception("El ID del instructor no puede ser nulo o menor o igual a cero.");
                if (liquidacionD.Vuelos == null) throw new Exception("error al generar la listas de vuelos");
                if (liquidacionD.Vuelos.Count <= 0) throw new Exception("Listas Vacias!No hay vuelos ni simuladores para liquidar.");
                Calcular(liquidacionD);

                LiquidacionDuenoDAO.GenerarLiquidacionD(liquidacionD);

            }
            catch (Exception ex)
                {
                    // helperTransaccion.RollbackDfParaTransaccion(ds);  Este metodo no es transaccional porque a diferencia de los instructores, los dueños no tienen simuladores asociados a la liquidación.
                    throw new Exception("BLL Liquidacion Dueño error al generar liquidacion: " + ex.Message, ex);
                }
            
	
        }

        public static void Calcular(LiquidacionDueno liquidacionD)
        {
            liquidacionD.CantHoras = 0;
            liquidacionD.MontoTotal = 0;

            foreach (Vuelo vuelo in liquidacionD.Vuelos)
            {
                liquidacionD.CantHoras += vuelo.TV;
            }

            liquidacionD.MontoTotal = liquidacionD.CantHoras * liquidacionD.Servicio.Precio;
        }

        internal void AsignarIdFacturaALiquidacion(LiquidacionDueno liquidacion)
        {
            try
            {
                if ( liquidacion.IdLiquidacionServicio <=0) throw new Exception("Id liquidacion nulo o invalido");
                if (liquidacion.IdFactura==null ||liquidacion.IdFactura <= 0) throw new Exception("Id de factura nulo o invalido");
                LiquidacionDuenoDAO.AsginarIdFacturaALiquidacion(liquidacion.IdLiquidacionServicio, liquidacion.IdFactura);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL LiquidacionDueño error al asignar id factura a liquidacion: "+ex.Message,ex) ;
            }
        }

        public List<LiquidacionDueno> BuscarLiquidacionesPorIdFactura(int idFactura)
        {
            try
            {
                List<LiquidacionDueno> LLiquidaciones = LiquidacionDuenoDAO.BuscarLiquidacionesPorIdFacturacion(idFactura);

                return LLiquidaciones;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionDueño error al buscar liquidacion por Id Factura: "+ex.Message,ex);
            }
        }

        public LiquidacionDueno BuscarLiquidacionPorId(int idLiquidacion)
        {
            ServicioBLL servicioBLO = new ServicioBLL();
            try
            {
                LiquidacionDueno liquidacion = LiquidacionDuenoDAO.BuscarLiquidacionPorId(idLiquidacion);
                liquidacion.Servicio = servicioBLO.BuscarServicioPorID(liquidacion.Servicio.IdServicio);

                return liquidacion;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL LiquidacionDueño error al buscar liquidacion por Id: " + ex.Message, ex);
            }
        }

        internal void QuitarIdFacturaALiquidacion(LiquidacionDueno liquidacion)
        {
            try
            {
                if (liquidacion.IdLiquidacionServicio <= 0) throw new Exception("Id liquidacion nulo o invalido");
                LiquidacionDuenoDAO.QuitarIdFacturaALiquidacion(liquidacion.IdLiquidacionServicio);
            }
            catch ( Exception ex)
            {

                throw new Exception("DAL LiquidacionDueño error al quitar Id de Factura a liquidacion: "+ex.Message,ex);
            }
        }
    }
}
