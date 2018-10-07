using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPP_2017_LABII
{
    class DirectorTecnico:Persona
    {
        public DirectorTecnico(string nombre, string apellido) : base(nombre, apellido) { }

        protected override string FichaTecnica()
        {
            return this.NombreCompleto();
        }

        public override string ToString()
        {
            return this.FichaTecnica();
        }
    }
}
