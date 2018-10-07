using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPP_2017_LABII
{
    class Jugador:Persona
    {
        private bool esCapitan;
        private int numero;

        public bool EsCapitan { get { return this.esCapitan; } set { this.esCapitan = value; } }
        public int Numero { get { return this.numero; } set { this.numero = value; } }

        public Jugador(string nombre, string apellido) :base(nombre,apellido)
        {
            this.Numero = 0;
            this.EsCapitan = false;
        }

        public Jugador(string nombre, string apellido, int numero, bool capitan)
            : this(nombre, apellido)
        {
            this.EsCapitan = capitan;
            this.Numero = numero;        
        }

        public static bool operator ==(Jugador j1, Jugador j2)
        {
            bool retorno = false;
            if (j1.Nombre == j2.Nombre && j1.Apellido == j2.Apellido && j1.Numero == j2.Numero)
            {
                retorno = true;
            }

            return retorno;        
        }

        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Jugador)
                retorno = (this == (Jugador)obj);
            return retorno;
        }

        protected override string FichaTecnica()
        {
            string informacion = String.Format("{0}, camiseta número {1}", this.NombreCompleto(), this.Numero);;
            if (this.EsCapitan)
            {
                informacion = String.Format("{0}, capitán del equipo, camiseta número {1}", this.NombreCompleto(), this.Numero);
            }

            return informacion;
        }

        public override string ToString()
        {
            return this.FichaTecnica();
        }

        public static explicit operator int(Jugador jugador)
        {
            return jugador.Numero;
        }


    }
}
