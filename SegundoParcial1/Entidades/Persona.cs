using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
namespace Entidades
{
   
    
    public class Persona :Corredor
    {
        public delegate void CorrenCallback(int avance, Corredor corredor);
        public event CorrenCallback Corriendo;
        string _nombre;

        public Persona(string nombre,short velocidadMax,Carril carril) :base(velocidadMax,carril)
        {
            this._nombre = nombre;
        }

        public override void Correr()
        {
            int avance;
            while(true)
            {
                avance = Corredor._avance.Next(0,this.VelocidadMaxima);
                Corriendo(avance, this);
                Thread.Sleep(1000);
            }
        }

        public override void Guardar(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(this.ToString());


                }
            }
            catch (Exception e)
            {

                throw new NoSeGuardoException(e);
            }


        }

        public override string ToString()
        {
            return string.Format("{0} en carril {1} a una velocidad maxima de {2}", this._nombre, this.CarrilElegido, this.VelocidadMaxima);
        }

    }
}
