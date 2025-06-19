using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Composite
{
    public class Rol : Componente
    {
   

        public List<Componente> Permisos { get; set; } = new List<Componente>();

        public override void AgregarHijo(Componente componente)
        {
            try
            {
                Permisos.Add(componente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override void EliminarHijo(Componente componente)
        {
            try
            {
                Permisos.Remove(componente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override bool EsHoja()
        {
           return false; // Un rol no es una hoja, ya que puede contener permisos   
        }

        public override void LimpiarHijos()
        {
            try
            {
                Permisos.Clear();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override IList<Componente> ObtenerHijos()
        {
            try
            {
                return Permisos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
