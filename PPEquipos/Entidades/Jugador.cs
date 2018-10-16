using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador : Persona
    {
        int numero;
        bool esCapitan;

        public int Numero
        {
            get { return this.numero; }

            set { this.numero = value; }
        }

        public bool EsCapitan
        {
            get { return this.esCapitan; }
            set { this.esCapitan = value; }
        }

        public Jugador(string nombre, string apellido) : base(nombre, apellido)
        {
            this.numero = 0;
            this.esCapitan = false;

        }

        public Jugador(string nombre, string apellido, int numero, bool esCapitan) : this(nombre, apellido)
        {
            this.numero = numero;
            this.esCapitan = esCapitan;

        }

        public static explicit operator int(Jugador jugador)
        {
            return jugador.numero;
        }

        public static bool operator == (Jugador j1, Jugador j2)
        {
            bool retorno = false;

            if(j1.Nombre == j2.Nombre && j1.Apellido == j2.Apellido && j1.numero == j2.numero)
            {
                retorno = true;
            }
            return retorno;
 
        }
        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j2);
        }

        protected override string FichaTecnica()
        {
            string retorno = "";
            if(this.esCapitan == true)
            {
                retorno = string.Format(base.NombreCompleto() + "  capitan del equipo, camiseta numero {0}", this.numero);
            }
            else
            {
                retorno = string.Format(base.NombreCompleto() + "  camiseta numero {0}", this.numero);
            }

            return retorno;
        }

        public override string ToString()
        {
            return this.FichaTecnica();
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Jugador)
            {
                retorno = (this == (Jugador)obj);
            }
            return retorno;
        }

    }
}
