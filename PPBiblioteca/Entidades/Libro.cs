using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        protected Autor _autor;
        protected int _cantidadDePaginas;
        protected static Random _generadorDePaginas;
        protected float _precio;
        protected string _titulo;

        #region Propiedad
        public int CantidadDePaginas
        {
            get

            {
                if (this._cantidadDePaginas == 0)
                {
                    this._cantidadDePaginas = Libro._generadorDePaginas.Next(10, 580);
                }

                return this._cantidadDePaginas;

            }
        }

        #endregion

        #region Construcores

        static Libro()
        {
            Libro._generadorDePaginas = new Random();
        }

        public Libro(float precio, string titulo, string nombre, string apellido)
        {
            this._precio = precio;
            this._titulo = titulo;
            this._autor = new Autor(nombre, apellido);

        }

        public Libro(string titulo, Autor autor, float precio)
        {
            this._precio = precio;
            this._titulo = titulo;
            this._autor = autor;

        }

        #endregion

        public static bool operator ==(Libro a, Libro b)
        {
            bool retorno = false;
            if (a._titulo == b._titulo && a._autor == b._autor)
            {
                retorno = true;
            }

            return retorno;

        }
        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }

        public static explicit operator string(Libro l)
        {
            return Libro.Mostrar(l);
        }


        private static string Mostrar(Libro l)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TITULO: " + l._titulo);
            sb.AppendLine("CANTIDAD DE PAGINAS: " + l.CantidadDePaginas);
            sb.AppendLine("AUTOR: " + l._autor);
            sb.AppendLine("PRECIO: " + l._precio);

            return sb.ToString();
        }

    }
}
