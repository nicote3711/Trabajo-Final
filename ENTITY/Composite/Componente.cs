using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Composite
{
    public abstract class Componente
    {
        public int IdComponente { get; set; }
        public string NombreComponente { get; set; }


        public abstract void AgregarHijo(Componente componente);

        public abstract void  EliminarHijo(Componente componente);

        public abstract IList<Componente> ObtenerHijos();

        public abstract void LimpiarHijos();
        public abstract bool EsHoja();
        

    }
}
