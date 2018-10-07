using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPP_2017_LABII
{
    public enum Deportes{Basquet,Futbol,Handball,Rugby}
    class Equipo
    {
        private static Deportes deporte;
        private DirectorTecnico dt;
        private List<Jugador> jugadores;
        private string nombre;

        public static Deportes Deporte { set { deporte = value; } }

        static Equipo() 
        {
            Equipo.Deporte = Deportes.Futbol;
        }

        private Equipo()
        { 
            jugadores = new List<Jugador>();
        }

        public Equipo(string nombre, DirectorTecnico dt) :this()
        {
            this.nombre = nombre;
            this.dt = dt;
        }

        public Equipo(string nombre, DirectorTecnico dt, Deportes deporte)
            : this(nombre, dt)
        {
            Equipo.Deporte = deporte;
        }
        
        public static implicit operator string(Equipo e)
        {
            StringBuilder salida = new StringBuilder();
            salida.AppendFormat("\n**{0}**",e.nombre);
            salida.AppendLine("\nNómina Jugadores:");
            foreach (Jugador j in e.jugadores)
            {
                salida.AppendLine(j.ToString());  
            }
            salida.AppendFormat("\nDirigido por: {0}", e.dt.ToString());

            return salida.ToString();    
        }

        public static bool operator ==(Equipo e, Jugador j)
        {
            bool retorno = false;
            foreach (Jugador jugador in e.jugadores)
            {
                if (jugador == j)
                    retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        public static Equipo operator +(Equipo e, Jugador j) 
        {   
            if(e != j)
            {
                e.jugadores.Add(j);
            }

            return e;
        }

        public static Equipo operator -(Equipo e, Jugador j)
        {
            if (e == j)
            {
                e.jugadores.Remove(j); //Se fija con el mètodo Equals() y yo lo sobreescribì
            }

            return e;
        }



        
    
    }
}
