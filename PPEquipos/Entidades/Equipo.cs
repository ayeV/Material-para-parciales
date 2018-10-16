using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Equipo
    {
       static Deportes deporte;
        DirectorTecnico dt;
        List<Jugador> jugadores;
        string nombre;

        public Deportes Deporte
        {
            set { Equipo.deporte = value; }
        }

        static Equipo()
        {
            Equipo.deporte = Deportes.Futbol;
        }
        
        Equipo()
        {
            this.jugadores = new List<Jugador>();
        }

        public Equipo(string nombre, DirectorTecnico dt) :this()
        {
            this.nombre = nombre;
            this.dt = dt;
        }

        public Equipo(string nombre, DirectorTecnico dt, Deportes deporte) :this(nombre,dt)
        {
            Equipo.deporte = deporte;

        }

        public static implicit operator string(Equipo e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("**{0} {1}**\n", e.nombre, Equipo.deporte);
            sb.AppendLine("Nomina jugadores: ");
            foreach(Jugador player in e.jugadores)
            {
                sb.AppendLine(player.ToString());
            }
            sb.AppendFormat("Dirigido por {0}", e.dt.ToString());
            return sb.ToString();
        }

        public static bool operator ==(Equipo e, Jugador j)
        {
            bool retorno = false;
            foreach(Jugador item in e.jugadores)
            {
                if( item == j)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        public static Equipo operator +(Equipo e, Jugador j)
        {
            if(e!=j)
            {
                e.jugadores.Add(j);
            }
            return e;
        }

        public static Equipo operator -(Equipo e, Jugador j)
        {
            if(e == j)
            {
                e.jugadores.Remove(j);
            }
            return e;
        }

    }
}
