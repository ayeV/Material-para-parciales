using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPP_2017_LABII
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorTecnico dt = new DirectorTecnico("Jorge","Habbeger");
            Equipo e1 = new Equipo("Huracán de San Rafael Futbol", dt, Deportes.Futbol);
            Jugador j1 = new Jugador("Fernando", "Pandolfi", 11, false);
            Jugador j2 = new Jugador("Julio", "Marchant", 8, false);
            Jugador j3 = new Jugador("Julio", "Marchant", 8, false);
            Jugador j4 = new Jugador("Ezequiel", "Medran", 12, false);
            Jugador j5 = new Jugador("Ezequiel", "Medran", 12, false);
            e1 = e1 + j1; //Agrego a jugador 1
            e1 += j2; //Agrego jugador 2
            e1 -= j3; //Borro a jugador 2 usando a jugador 3 que tiene los mismos datos. 
            e1 += j4; //Agrego jugador 4
            e1 += j5; //Trato de agregar a jugador 5 que tiene los mismos datos que jugador 4.

            DirectorTecnico dt2 = new DirectorTecnico("Juan", "Perez");
            Equipo e2 = new Equipo("Equipo Dos", dt2);

            Console.WriteLine((string)e1);
            Console.WriteLine((string)e2);
            Console.ReadKey();

        }
    }
}
