using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public delegate void AvisoFinHandler(string mensaje);

    public class LosHilos : IRespuesta<int>
    {
        int id;
        List<InfoHilo> misHilos;
        public event AvisoFinHandler AvisoFin;

        public string Bitacora
        {

            get
            {
                StreamReader sr = null;
                string retorno = "";
                try
                {
                    sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/bitacora.txt");
                    retorno = sr.ReadToEnd();


                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    sr.Close();
                }

                return retorno;
            }


            set
            {

                try
                {
                    using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/bitacora.txt", true, Encoding.UTF8))
                    {
                        sw.WriteLine(value);

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public LosHilos()
        {
            this.misHilos = new List<InfoHilo>();
            this.id = 0;
        }

        static LosHilos AgregarHilo(LosHilos hilos)
        {
            hilos.id++;
            InfoHilo infoHilo = new InfoHilo(hilos.id, hilos);
            hilos.misHilos.Add(infoHilo);
            return hilos;
        }

        public void RespuestaHilo(int id)
        {

            string mensaje = string.Format("Terminó el hilo {0}.", id);
            this.Bitacora = mensaje;
            AvisoFin(mensaje);


        }

        public static LosHilos operator +(LosHilos hilos, int cantidad)
        {
            if (cantidad < 1)
            {
                throw new CantidadInvalidaException();
            }
            else
            {
                for (int i = 0; i < cantidad; i++)
                {
                    LosHilos.AgregarHilo(hilos);
                }
            }

            return hilos;
        }


    }
}
