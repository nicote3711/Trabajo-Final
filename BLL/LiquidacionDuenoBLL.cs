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
                    throw new Exception("BLL LiquidacionInsctructor error al generar liquidacion: " + ex.Message, ex);
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
    }
}
