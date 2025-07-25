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
    public class FacturaSolicitudHorasBLL
    {
        private readonly FacturaSolicitudHorasDAL FacturaSolicitudHorasDAO = new FacturaSolicitudHorasDAL();
        private readonly SolicitudHorasBLL SolicitudHorasBLO = new SolicitudHorasBLL();

        public List<FacturaSolicitudHoras> ObtenerFacturas()
        {
            try
            {
                List<FacturaSolicitudHoras> Lfacturas = FacturaSolicitudHorasDAO.ObtenerFacturas();
                foreach (FacturaSolicitudHoras factura in Lfacturas)
                {
                
                    // Cargar el cliente asociado a la solicitud de horas
                    SolicitudHoras solicitud = SolicitudHorasBLO.BuscarSolicitudPorIdFactura(factura.IdFactura);
                    if (solicitud == null) throw new Exception($"No se encontró la solicitud de horas con ID {factura.Solicitud.IdSolicitudHoras}.");
                    factura.Solicitud = solicitud; // Asignar la solicitud a la factura 

                    //
                    if (factura.Transaccion!=null)
                    {
                        // aca busco la transaccion asociada a la factura por id transaccion si es necesario.
                    }
                }   
                return Lfacturas;
            }
            catch (Exception ex)
            {
                throw new Exception("BLL FacturaSolicitud error al obtener las facturas: " + ex.Message, ex);
            }
        }
        public void RegistrarFactura(FacturaSolicitudHoras factura)
        {
            HelperTransaccion helperTransaccion = new HelperTransaccion();
            DataSet ds = helperTransaccion.DfParaTransaccion();

            
            try
            {
                if (factura == null) throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula.");
                if (factura.Solicitud == null) throw new ArgumentNullException(nameof(factura.Solicitud), "La solicitud de horas no puede ser nula.");
                SolicitudHorasBLO.ValidarSolicitudHoras(factura.Solicitud); // Validar la solicitud de horas antes de continuar
                CargarFacturaConSolicitud(factura);

                if (factura.FechaFactura == default) throw new ArgumentException("La fecha de la factura no puede ser la fecha por defecto.", nameof(factura.FechaFactura));
                if (factura.MontoTotal <= 0) throw new ArgumentOutOfRangeException(nameof(factura.MontoTotal), "El monto total debe ser mayor a cero.");
                // Aquí se llamaría al método DAL para registrar la factura en la base de datos o archivo XML
                // FacturaDAL.RegistrarFactura(factura);


                FacturaSolicitudHorasDAO.RegistrarFactura(factura);
                factura.Solicitud.Factura = new FacturaSolicitudHoras() { IdFactura = factura.IdFactura }; // Crear una nueva instancia de FacturaSolicitudHoras para la solicitud
                factura.Solicitud.Factura.IdFactura = factura.IdFactura; // Asignar el ID de la factura a la solicitud; este paso cao sea necesario si la solicitud ya tiene el ID de la factura asignado.
                SolicitudHorasBLO.AltaSolicitudHoras(factura.Solicitud); // Registrar la solicitud de horas asociada a la factura

                
                Result result = HelperFacturas.GenerarFacturaPDF(factura);
                if (!result.Success)
                throw new Exception(result.Message);

            }
            catch (Exception ex)
            {
                helperTransaccion.RollbackDfParaTransaccion(ds);
                throw new Exception("Error al registrar la factura: " + ex.Message, ex);
            }
        }

        private void CargarFacturaConSolicitud(FacturaSolicitudHoras factura)
        {
            try
            {
                factura.FechaFactura = factura.Solicitud.FechaSolicitud;
                factura.MontoTotal = (factura.Solicitud.CantidadHorasVuelo * factura.Solicitud.ValorHoraVuelo) + (factura.Solicitud.CantidadHorasSimulador * factura.Solicitud.ValorHoraSimulador);
                factura.NroFactura = FacturaSolicitudHorasDAO.ObtenerNumeroFactura(factura.TipoFactura.IdTipoFactura); // Generar un número de factura único
                factura.CuilEmisor = factura.Solicitud.Cliente.CuitCuil; // Asignar el CUIL del cliente emisor
                factura.Detalle = $"Factura por solicitud de horas:  - Cliente: {factura.Solicitud.Cliente.Identificar} -Total {factura.MontoTotal} "; // deberia ver horas vuelo y simu con sus precios.
            }
            catch (Exception ex)
            {

                throw new Exception("BLL FacturaSoliciud error al CargarFactura con solicitud:" + ex.Message, ex);
            }
        }

        public FacturaSolicitudHoras BuscarFacturaPorId(int idFactura)
        {
            try
            {
                return FacturaSolicitudHorasDAO.BuscarFacturaPorId(idFactura);
            }
            catch (Exception ex)
            {
                throw new Exception("BLL FacturaSolicitud error al buscar la factura por ID: " + ex.Message, ex);
            }
        }

        public void EliminarFacturaPorId(int idFactura)
        {
            try
            {
                
                FacturaSolicitudHorasDAO.EliminarFacturaPorId(idFactura);
            }
            catch (Exception ex)
            {

                throw new Exception("BLL FacturaSolicitudHoras error al eliminar Factura por ID: " +ex.Message,ex);
            }
        }
    }
}
