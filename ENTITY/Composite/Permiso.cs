using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Composite
{
    public class Permiso : Componente
    {
        List<Componente> Lhijos = new List<Componente>();
        public override void AgregarHijo(Componente componente)
        {
            Lhijos.Add(componente);
        }

        public override void EliminarHijo(Componente componente)
        {
            Lhijos.Remove(componente);
        }

        public override IList<Componente> ObtenerHijos()
        {

            return Lhijos;
        }
   
        public override bool EsHoja()
        {
            return false; // Un permiso no es una hoja, ya que puede contener items de permiso
        }

        public override void LimpiarHijos()
        {
            Lhijos.Clear();
        }
    }   

}
