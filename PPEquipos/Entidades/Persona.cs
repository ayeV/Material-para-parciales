using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public abstract class Persona
    {
        string apellido;
        string nombre;

        public string Apellido

        {
            get { return this.apellido; }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }


        public Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        protected virtual string NombreCompleto()
        {
            return string.Format("{0} {1}", this.nombre, this.apellido);
        }

        protected abstract string FichaTecnica();
          
        

    }
}
