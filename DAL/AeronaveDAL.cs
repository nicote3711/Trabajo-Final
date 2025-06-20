﻿using ENTITY;
using Helper;
using MAPPER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AeronaveDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();
        private readonly EstadoAeronaveDAL EstadoAeronaveDAO = new EstadoAeronaveDAL();
        private readonly DuenoDAL DuenoDao = new DuenoDAL();

        public List<Aeronave> ObtenerAeronaves()
        {
            if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            DataTable tablaAeronaves = ds.Tables["Aeronave"];
            if (tablaAeronaves == null) throw new Exception("No se encontró la tabla de Aeronave.");

            List<Aeronave> lista = new List<Aeronave>();

            foreach (DataRow row in tablaAeronaves.Rows)
            {
                Aeronave aeronave = new Aeronave();
                AeronaveMAP.MapearDesdeDB(aeronave, row);

                int idEstado = Convert.ToInt32(row["Id_Estado_Aeronave"]);
                aeronave.Estado = EstadoAeronaveDAO.BuscarEstadoPorId(idEstado);

                if (!row.IsNull("Id_Dueno"))
                {
                    int idDueno = Convert.ToInt32(row["Id_Dueno"]);
                    aeronave.Dueno = DuenoDao.BuscarDuenoPorId(idDueno);
                }

                lista.Add(aeronave);
            }

            return lista;
        }

        public void AltaAeronave(Aeronave aeronave)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            DataTable tabla = ds.Tables["Aeronave"];
            if (tabla == null) throw new Exception("No se encontró la tabla Aeronave.");

            int nuevoId = HelperD.ObtenerProximoID(tabla, "Id_Aeronave");
            aeronave.IdAeronave = nuevoId;

            DataRow row = tabla.NewRow();
            AeronaveMAP.MapearHaciaDB(aeronave, row);
            tabla.Rows.Add(row);

            ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
        }

        public Aeronave BuscarAeronavePorId(int IdAeronave)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            DataTable tabla = ds.Tables["Aeronave"];
            if (tabla == null) throw new Exception("No se encontró la tabla Aeronave.");

            DataRow row = tabla.AsEnumerable().FirstOrDefault(a => a.Field<int>("Id_Aeronave") == IdAeronave);
            if (row == null) return null;

            Aeronave aeronave = new Aeronave();
            AeronaveMAP.MapearDesdeDB(aeronave, row);
            aeronave.Estado = EstadoAeronaveDAO.BuscarEstadoPorId(Convert.ToInt32(row["Id_Estado_Aeronave"]));
            if (!row.IsNull("Id_Dueno"))
            {
                aeronave.Dueno = DuenoDao.BuscarDuenoPorId(Convert.ToInt32(row["Id_Dueno"]));
            }

            return aeronave;
        }

        public void ModificarAeronave(Aeronave aeronave)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            var tabla = ds.Tables["Aeronave"];
            if (tabla == null) throw new Exception("No se encontró la tabla Aeronave.");

            DataRow row = tabla.AsEnumerable().FirstOrDefault(a => a.Field<int>("Id_Aeronave") == aeronave.IdAeronave);
            if (row == null) throw new Exception("No se encontró la aeronave a modificar.");

            AeronaveMAP.MapearHaciaDB(aeronave, row);

            ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
        }

        public void BajaAeronave(int idAeronave, int idEstadoInactivo)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            var tabla = ds.Tables["Aeronave"];
            if (tabla == null) throw new Exception("No se encontró la tabla Aeronave.");

            DataRow row = tabla.AsEnumerable().FirstOrDefault(a => a.Field<int>("Id_Aeronave") == idAeronave);
            if (row == null) throw new Exception("No se encontró la aeronave a dar de baja.");

            row["Id_Estado_Aeronave"] = idEstadoInactivo; 

            ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
        }

        public Aeronave BuscarAeronavePorMatricula(string matricula)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");
                
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tablaAeronave = ds.Tables["Aeronave"];
                DataTable tablaEstados = ds.Tables["Estado_Aeronave"];
                DataTable tablaDuenos = ds.Tables["Dueno"];
                if (tablaAeronave == null || tablaEstados == null || tablaDuenos == null)
                {
                    throw new Exception("No se encontraron las tablas requeridas en el XML.");
                }

                DataRow row = tablaAeronave.AsEnumerable().FirstOrDefault(a => a.Field<string>("Matricula").Equals(matricula, StringComparison.OrdinalIgnoreCase));
                if (row == null) return null;
                Aeronave aeronave = new Aeronave();
                AeronaveMAP.MapearDesdeDB(aeronave, row);
                
                if (!row.IsNull("Id_Dueno"))
                {
                    aeronave.Dueno = DuenoDao.BuscarDuenoPorId(Convert.ToInt32(row["Id_Dueno"]));
                }
                aeronave.Estado = EstadoAeronaveDAO.BuscarEstadoPorId(Convert.ToInt32(row["Id_Estado_Aeronave"]));

                return aeronave;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
