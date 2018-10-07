using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPP_2017_LABII
{
    abstract class Persona
    {
        private string nombre;
        private string apellido;

        public string Nombre { get { return this.nombre; } }
        public string Apellido { get { return this.apellido; } }

        public Persona(string nombre, string apellido) 
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        protected abstract string FichaTecnica();
        protected virtual string NombreCompleto()
        { 
            string nombreCompleto = String.Format("{0} {1}",this.Nombre,this.Apellido);
            return nombreCompleto; 
        }
    }
}
