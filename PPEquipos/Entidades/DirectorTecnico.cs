using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class DirectorTecnico :Persona
    {
        public DirectorTecnico(string nombre, string apellido) :base(nombre,apellido)
        {

        }

        protected override string FichaTecnica()
        {
            return string.Format("{0} {1}", base.Nombre, base.Apellido);
        }

        public override string ToString()
        {
            return this.FichaTecnica();
        }
    }
}
