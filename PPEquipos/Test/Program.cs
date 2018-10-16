using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectorTecnico dt = new DirectorTecnico("Jorge", "Habbeger");

            Equipo equipo = new Equipo("Huracan de san rafael", dt);
            Jugador j1 = new Jugador("Fernando", "Pandolfini",11,false);
            Jugador j2 = new Jugador("Julio", "Marchant", 8, false);
            Jugador j3 = new Jugador("Ezequiel", "Medran", 12, false);
            Jugador j4 = new Jugador("Jose", "Pereda", 24, false);
            Jugador j5 = new Jugador("Hernan", "Florentin", 6, false);
            Jugador j6 = new Jugador("Fernando", "Navas", 11, true);
            Jugador j7 = new Jugador("Fernando", "Navas", 11, true);

            equipo += j1;
            equipo += j2;
            equipo += j3;
            equipo += j4;
            equipo += j5;
            equipo += j6;
            equipo += j7;

            Console.WriteLine((string)equipo);
            Console.ReadKey();
            Console.Clear();

            //quito un jugador
            equipo -= j1;
            Console.WriteLine((string)equipo);



            Console.ReadLine();



        }
    }
}
