using ENTITY.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public long DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public List<Rol> Roles { get; set; } = new List<Rol>();

        public  bool Activo { get; set; }

        public List<Componente> ObtenerPermisos()
        {
            List<Componente> permisos = new List<Componente>();
            HashSet<int> idsUnicos = new HashSet<int>(); // Para evitar duplicados se podria hacer con una lista tambien, pero con un conjunto es mas eficiente
            foreach (Rol rol in Roles)
            {
                foreach (Componente permiso in rol.Permisos)
                {
                    if (!idsUnicos.Contains(permiso.IdComponente)) // Verificar si el permiso ya fue agregado
                    {
                        permisos.Add(permiso);
                        idsUnicos.Add(permiso.IdComponente); // Agregar el ID del permiso al conjunto
                    }
                }
                permisos.AddRange(rol.Permisos);//aca podria poner rol.obtenerpermisos porque el return hace lo mismo.
            }
            return permisos.ToList(); 
        }
    }
}
