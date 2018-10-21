using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestamosPersonales;
namespace EntidadFinanciera
{
   public class Financiera
    {
        List<Prestamo> listaDePrestamos;
        string razonSocial;

        public float InteresesEnDolares
        {
            get { return this.CalcularInteresesGanado(TipoDePrestamo.Dolares); }
        }

        public float InteresesEnPesos
        {
            get { return this.CalcularInteresesGanado(TipoDePrestamo.Pesos); }
        }

        public float InteresesTotales
        {
            get { return this.CalcularInteresesGanado(TipoDePrestamo.Todos); }
        }

        public string RazonSocial { get { return this.razonSocial; } }

        public List<Prestamo> ListaDePrestamos
        {
            get{ return this.listaDePrestamos; }
        }

        private Financiera()
        {
            this.listaDePrestamos = new List<Prestamo>();
        }

        public Financiera(string razonSocial) :this()
        {
            this.razonSocial = razonSocial;
        }

        #region Operadores

        public static bool operator == (Financiera f, Prestamo p)
        {
            bool retorno = false;
            if(f.listaDePrestamos.Contains(p))
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Financiera f, Prestamo p)
        {
            return !(f == p);
        }

        public static explicit operator string (Financiera financiera)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nRazon social {0}", financiera.razonSocial);
            sb.AppendFormat("\nIntereses en dolares {0}", financiera.InteresesEnDolares);
            sb.AppendFormat("\nIntereses en pesos {0}", financiera.InteresesEnPesos);
            sb.AppendFormat("\nIntereses totales {0}", financiera.InteresesTotales);

            financiera.OrdenarPrestamos();
            foreach (Prestamo item in financiera.listaDePrestamos)
            {
                sb.AppendLine(item.Mostrar());
            }

            return sb.ToString();
        }

        public static Financiera operator +(Financiera financiera,Prestamo prestamoNuevo)
        {
            if(financiera != prestamoNuevo)
            {
                financiera.listaDePrestamos.Add(prestamoNuevo);
            }
            return financiera;
        }

        #endregion

        #region Metodos
        public void OrdenarPrestamos()
        {
            this.listaDePrestamos.Sort(Prestamo.OrdenarPorFecha);
        }

       float CalcularInteresesGanado(TipoDePrestamo tipoPrestamo)
        {
            float interesGanado = 0;

            switch (tipoPrestamo)
            {
                case TipoDePrestamo.Pesos:
                    foreach (Prestamo prestamo in this.listaDePrestamos)
                    {
                        if(prestamo is PrestamoPesos)
                        {
                            interesGanado += ((PrestamoPesos)prestamo).Interes;
                            
                        }

                    }
                    break;
                case TipoDePrestamo.Dolares:
                    foreach (Prestamo prestamo in this.listaDePrestamos)
                    {
                        if (prestamo is PrestamoDolar)
                        {
                            interesGanado += ((PrestamoDolar)prestamo).Interes;

                        }

                    }
                    break;
                case TipoDePrestamo.Todos:
                    foreach (Prestamo prestamo in this.listaDePrestamos)
                    {
                        if (prestamo is PrestamoPesos)
                        {
                            interesGanado += ((PrestamoPesos)prestamo).Interes;

                        }
                        if(prestamo is PrestamoDolar)
                        {
                            interesGanado += ((PrestamoDolar)prestamo).Interes;
                        }

                    }
                    break;
               
            }

            return interesGanado;
        }

        public static string Mostrar(Financiera f)
        {
            return (string)f;
        }

        #endregion

    }
}
