using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
   public class InfoHilo 
    {
        IRespuesta<int> callback;
        Thread hilo;
        int id;
        static Random randomizer;

       static InfoHilo()
        {
            randomizer = new Random();
        }

        public InfoHilo(int id,IRespuesta<int> callback) 
        {
            this.id = id;
            this.callback = callback;
            this.hilo = new Thread(Ejecutar);
            hilo.Start();
        }

        void Ejecutar()
        {
            Thread.Sleep(randomizer.Next(1000, 5000));
           this.callback.RespuestaHilo(this.id);

        }
            
    }
}
