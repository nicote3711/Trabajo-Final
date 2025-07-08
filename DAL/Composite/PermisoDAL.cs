using ENTITY.Composite;
using Helper;
using MAPPER.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Composite
{
    public class PermisoDAL
    {
        private static string rutaXML = HelperD.ObtenerConexionXMl();

        public List<Componente> ObtenerArbolDePermisos()
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataTable tablaPermiso = ds.Tables["Permiso"];
                DataTable tablaComposicion = ds.Tables["Permiso_Composicion"];

                Dictionary<int, Componente> DicComponentes = new Dictionary<int, Componente>();

                // 1. Mapear todos los componentes
                foreach (DataRow row in tablaPermiso.Rows)
                {
                    Componente componente = PermisoMAP.MapearDesdeDB(row);
                    DicComponentes.Add(componente.IdComponente, componente);
                }

                // 2. Armar jerarquía desde Permiso_Composicion
                foreach (DataRow row in tablaComposicion.Rows)
                {
                    int idPadre = Convert.ToInt32(row["Id_Permiso_Padre"]);
                    int idHijo = Convert.ToInt32(row["Id_Permiso_Hijo"]);

                    if (DicComponentes.ContainsKey(idPadre) && DicComponentes.ContainsKey(idHijo))
                    {
                        DicComponentes[idPadre].AgregarHijo(DicComponentes[idHijo]);
                    }

                }

                // 3. Obtener nodos raíz (no son hijos de nadie)
                var hijos = new HashSet<int>(tablaComposicion.AsEnumerable().Select(r => Convert.ToInt32(r["Id_Permiso_Hijo"])));

                List<Componente> raices = DicComponentes.Values.Where(c => !hijos.Contains(c.IdComponente)).ToList();

                return raices;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Permiso error al obtener arbol de permisos: "+ex.Message,ex);
            }

        }

        public Componente BuscarPorId(int id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataTable tablaPermiso = ds.Tables["Permiso"];

                foreach (DataRow row in tablaPermiso.Rows)
                {
                    if (Convert.ToInt32(row["Id_Permiso"]) == id)
                    {
                        return PermisoMAP.MapearDesdeDB(row); // no mapeamos los hijos aquí si es compuesto, solo el nodo
                    }
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Permiso error al buscar por id: "+ex.Message,ex);
            }
         
        }

        public List<Componente> ObtenerTodos()
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataTable tablaPermiso = ds.Tables["Permiso"];
                List<Componente> lista = new List<Componente>();

                foreach (DataRow row in tablaPermiso.Rows)
                {
                    Componente componente = PermisoMAP.MapearDesdeDB(row);
                    lista.Add(componente);
                }
                //Mapea solo los nodos, no los hijos. osea plano
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL permiso error al obtener todos: "+ex.Message,ex);
            }

        }

        public Dictionary<int, Componente> ObtenerDiccionarioPlano()
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataTable tablaPermiso = ds.Tables["Permiso"];
                Dictionary<int, Componente> diccionario = new Dictionary<int, Componente>();

                foreach (DataRow row in tablaPermiso.Rows)
                {
                    Componente componente = PermisoMAP.MapearDesdeDB(row);
                    diccionario.Add(componente.IdComponente, componente);
                }

                return diccionario;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Permiso error al obtener diccionario plano: "+ex.Message,ex);
            }

        }

        public void CargarJerarquia(Dictionary<int, Componente> DicComponentes)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);

                DataTable tablaRelacion = ds.Tables["Permiso_Composicion"];

                foreach (DataRow row in tablaRelacion.Rows)
                {
                    int idPadre = Convert.ToInt32(row["Id_Permiso_Padre"]);
                    int idHijo = Convert.ToInt32(row["Id_Permiso_Hijo"]);

                    if (DicComponentes.ContainsKey(idPadre) && DicComponentes.ContainsKey(idHijo))
                    {
                        DicComponentes[idPadre].AgregarHijo(DicComponentes[idHijo]);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Permiso error al cargar jerarquia: "+ex.Message,ex);
            }
          
        }

        public List<int> ObtenerIdAncestros(int idPermiso)
        {
            try
            {
                List<int> IdAncestros = new List<int>();
                int idHijo = idPermiso; 

                DataSet ds = new DataSet();
                ds.ReadXml(rutaXML, XmlReadMode.ReadSchema);
                DataTable tablaComposicion = ds.Tables["Permiso_Composicion"];
                if (tablaComposicion == null) throw new Exception("No se encontró la tabla Permiso_Composicion.");
            
                while (idHijo!=-1)
                {
                   
                    DataRow relacion = tablaComposicion.AsEnumerable().FirstOrDefault(r =>  Convert.ToInt32(r["Id_Permiso_Hijo"]) == idHijo);
                    if (relacion != null)
                    {
                        idHijo = Convert.ToInt32(relacion["Id_Permiso_Padre"]);
                        IdAncestros.Add(idHijo);
                    }
                    else
                    {
                        idHijo = -1; // No hay más ancestros
                    }
                }
                return IdAncestros;
            }
            catch (Exception ex)
            {

                throw new Exception("DAL Permiso error al obtener id Ancestros: "+ex.Message,ex) ;
            }
        }
   
    }
}
