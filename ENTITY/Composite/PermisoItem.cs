using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Composite
{
    public class PermisoItem : Componente
    {
        public override void AgregarHijo(Componente componente)
        {
            throw new Exception("Un item no puede agregar hijos");
        }

        public override void EliminarHijo(Componente componente)
        {
            throw new Exception("Un item no puede eliminar hijos");
        }

        public override bool EsHoja()
        {
            return true; // Un item es una hoja en el patrón Composite
        }

        public override void LimpiarHijos()
        {
            throw new Exception("Un permisoItem no tiene hijos a eliminar");
        }

        public override IList<Componente> ObtenerHijos()
        {
           return new List<Componente>(); // recomendable retornar una lista vacía segun Gang of Four para recursividad
        }

    
    }
}
