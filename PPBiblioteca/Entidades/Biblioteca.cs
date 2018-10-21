using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Biblioteca
    {
        int _capacidad;
        List<Libro> _libros;

        #region Propiedades
        public double PrecioDeManuales
        {
            get
            { return this.ObtenerPrecio(ELibro.Manual); }

        }

        public double PrecioDeNovelas
        {
            get
            { return this.ObtenerPrecio(ELibro.Novela); }


        }

        public double PrecioTotal
        {
            get
            { return this.ObtenerPrecio(ELibro.Ambos); }


        }
        #endregion

        #region Constructores

        private Biblioteca()
        {
            this._libros = new List<Libro>();
        }

        private Biblioteca(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }
        #endregion

        #region Operadores
        public static implicit operator Biblioteca(int capacidad)
        {

            Biblioteca biblio = new Biblioteca(capacidad);
            return biblio;
        }

        public static bool operator ==(Biblioteca e, Libro l)
        {
          
            bool retorno = false;

            for (int i = 0; i < e._libros.Count; i++)
            {
                if (l is Novela && e._libros[i] is Novela)
                {
                    if ((Novela)l == (Novela)e._libros[i])
                    {
                        retorno = true;
                        break;
                    }
                }
                else if (l is Manual && e._libros[i] is Manual)
                {
                    if ((Manual)l == (Manual)e._libros[i])
                    {
                        retorno = true;
                        break;
                    }
                }
            }



            return retorno;
        }

        public static bool operator !=(Biblioteca e, Libro l)
        {
            return !(e == l);
        }

        public static Biblioteca operator +(Biblioteca e, Libro l)
        {
            foreach (Libro item in e._libros)
            {
                if (e == l)
                {
                    Console.WriteLine("El libro ya esta en la biblioteca");
                    return e;
                }
            }

            if (e._libros.Count < e._capacidad)
            {
                e._libros.Add(l);
            }
            else if (e._libros.Count > e._capacidad)
            {
                Console.WriteLine("No hay mas lugar en la biblioteca");
            }

            return e;



        }

        #endregion

        #region Metodos

        double ObtenerPrecio(ELibro tipoLibro)
        {
         

            double precioTotal = 0;
            double precioManual = 0;
            double precioNovela = 0;

            foreach (Libro item in this._libros)
            {
                if (item is Manual)
                {

                    precioManual += (Manual)item;

                }
                else if (item is Novela)
                {

                    precioNovela += (Novela)item;

                }


            }

            switch (tipoLibro)
            {
                case ELibro.Manual:

                    precioTotal = precioManual;
                    break;

                case ELibro.Novela:

                    precioTotal = precioNovela;
                    break;

                case ELibro.Ambos:
                    precioTotal = precioNovela + precioManual;
                    break;

            }

            return precioTotal;


        }

        public static string Mostrar(Biblioteca e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Capacidad de la biblioteca: {0}\n", e._capacidad);
            sb.AppendLine();
            sb.AppendFormat("Total por novelas: {0:.0}\n", e.PrecioDeNovelas);
            sb.AppendFormat("Total por manuales: {0:.0}\n", e.PrecioDeManuales);
            sb.AppendFormat("Total {0:.0}\n", e.PrecioTotal);
            sb.AppendLine();
            foreach (Libro item in e._libros)
            {

                sb.AppendLine((string)item);

                if (item is Manual)
                {

                    sb.AppendLine(((Manual)item).Mostrar());
                }
                else if (item is Novela)
                {
                    sb.AppendLine(((Novela)item).Mostrar());
                }
            }

            return sb.ToString();
        }

        #endregion
    }
}
