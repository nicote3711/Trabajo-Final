using DAL.Composite;
using ENTITY;
using ENTITY.Composite;
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
    public class UsuarioDAL
    {
        private readonly string rutaXml = HelperD.ObtenerConexionXMl();
        private readonly RolDAL RolDAO = new RolDAL();  

        public List<Usuario> ObtenerTodos()
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Usuario"];
                DataTable tablaUsuarioRol = ds.Tables["Usuario_Rol"];
                if (tabla == null) throw new Exception("No se encontró la tabla Usuario.");
                if(tablaUsuarioRol== null) throw new Exception("No se encontró la tabla Usuario_Rol."); 

                List<Usuario> usuarios = new List<Usuario>();

                foreach (DataRow row in tabla.AsEnumerable())
                {
                    Usuario usuario = new Usuario();
                    UsuarioMAP.MapearDesdeDB(usuario, row);

                    var rolesAsociados = tablaUsuarioRol.AsEnumerable().Where(r => r.Field<int>("Id_Usuario") == usuario.IdUsuario).Select(r => r.Field<int>("Id_Rol"));
                    foreach( int idRol in rolesAsociados)
                    {
                        Rol rol = RolDAO.BuscarPorId(idRol);
                        if (rol != null)
                        {
                            usuario.Roles.Add(rol);
                        }
                    }  

                    usuarios.Add(usuario);
                }

                return usuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorNombreUsuario(string nombre)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Usuario"];
                DataTable tablaUsiarioRol = ds.Tables["Usuario_Rol"];
                if (tabla == null) throw new Exception("No se encontró la tabla Usuario.");
                if(tablaUsiarioRol == null) throw new Exception("No se encontró la tabla Usuario_Rol.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(u => u.Field<string>("Nombre_Usuario").Equals(nombre, StringComparison.OrdinalIgnoreCase));
                if (row == null) return null;
                Usuario usuario = new Usuario();
                UsuarioMAP.MapearDesdeDB(usuario, row);

                var rolesAsociados = tablaUsiarioRol.AsEnumerable().Where(r => r.Field<int>("Id_Usuario") == usuario.IdUsuario).Select(r => r.Field<int>("Id_Rol"));
                foreach (int idRol in rolesAsociados)
                {
                    Rol rol = RolDAO.BuscarPorId(idRol);
                    if (rol != null)
                    {
                        usuario.Roles.Add(rol);
                    }
                }

               
                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL USuario error al buscar usuario por nombre: "+ ex.Message,ex);
            }

        }

        public Usuario BuscarPorId(int id)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Usuario"];
                if (tabla == null) throw new Exception("No se encontró la tabla Usuario.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(u => u.Field<int>("Id_Usuario") == id);

                if (row == null) return null;

                Usuario usuario = new Usuario();
                UsuarioMAP.MapearDesdeDB(usuario, row);
                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public void AltaUsuario(Usuario usuario)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Usuario"];
                if (tabla == null) throw new Exception("No se encontró la tabla Usuario.");

                int nuevoId = HelperD.ObtenerProximoID(tabla, "Id_Usuario");
                usuario.IdUsuario = nuevoId;

                DataRow row = tabla.NewRow();
                UsuarioMAP.MapearHaciaDB(usuario, row);
                tabla.Rows.Add(row);

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void BajaUsuario(int idUsuario)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Usuario"];
                if (tabla == null) throw new Exception("No se encontró la tabla Usuario.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(u => u.Field<int>("Id_Usuario") == idUsuario);
                if (row == null) throw new Exception("No se encontró el usuario a dar de baja.");

                row["Activo"] = false;

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL error en Baja usuario:" + ex.Message,ex);
            }

        }
        public void AsociarRolAUsuario(int idUsuario, int idRol)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            DataTable tabla = ds.Tables["Usuario_Rol"];
            if (tabla == null) throw new Exception("No se encontró la tabla Usuario_Rol.");

            bool yaExiste = tabla.AsEnumerable().Any(r =>
                Convert.ToInt32(r["Id_Usuario"]) == idUsuario &&
                Convert.ToInt32(r["Id_Rol"]) == idRol);

            if (!yaExiste)
            {
                DataRow row = tabla.NewRow();
                row["Id_Usuario"] = idUsuario;
                row["Id_Rol"] = idRol;
                tabla.Rows.Add(row);

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
        }

        public void DesasociarRolDeUsuario(int idUsuario, int idRol)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

            DataTable tabla = ds.Tables["Usuario_Rol"];
            if (tabla == null) throw new Exception("No se encontró la tabla Usuario_Rol.");

            DataRow row = tabla.AsEnumerable().FirstOrDefault(r =>Convert.ToInt32(r["Id_Usuario"]) == idUsuario && Convert.ToInt32(r["Id_Rol"]) == idRol);

            if (row != null)
            {
                row.Delete();
                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
        }

        public Usuario BuscarPorDNI(long dNI)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("No se encontró el archivo XML.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Usuario"];
                if (tabla == null) throw new Exception("No se encontró la tabla Usuario.");

                DataRow row = tabla.AsEnumerable().FirstOrDefault(u => u.Field<long>("DNI") == dNI);

                if (row == null) return null;

                Usuario usuario = new Usuario();
                UsuarioMAP.MapearDesdeDB(usuario, row);
                return usuario;

            }
            catch (Exception ex)
            {

                throw new Exception ("DAL Error al buscar usuario por dni" + ex.Message, ex);
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                if (!File.Exists(rutaXml)) throw new FileNotFoundException("Archivo XML no encontrado.");

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXml, XmlReadMode.ReadSchema);

                DataTable tabla = ds.Tables["Usuario"];
                DataRow row = tabla.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Id_Usuario"]) == usuario.IdUsuario);

                if (row == null) throw new Exception("Usuario no encontrado.");

                UsuarioMAP.MapearHaciaDB(usuario, row);

                ds.WriteXml(rutaXml, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception("DAL - Error al modificar el usuario: " + ex.Message, ex);
            }
        }
    }
}
