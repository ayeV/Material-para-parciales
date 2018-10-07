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
        #region Atributos
        private List<Prestamo> listaDePrestamos;
        private string razonSocial;
        #endregion
        
        #region Propiedades
        public List<Prestamo> ListaDePrestamos
        {
            get 
            {
                return this.listaDePrestamos;
            }
        }

        public string RazonSocial
        {
            get
            {
                return this.razonSocial;
            }
        }

        public float InteresesEnDolares
        {
            get
            {
                return this.CalcularInteresGanado(TipoDePrestamo.Dolares);
            }
        }

        public float InteresesEnPesos
        {
            get
            {
                return this.CalcularInteresGanado(TipoDePrestamo.Pesos);
            }
        }

        public float InteresesTotales
        {
            get
            {
                return this.CalcularInteresGanado(TipoDePrestamo.Todos);
            }
        }
        #endregion

        #region Constructores
        private Financiera()
        {         
            this.listaDePrestamos = new List<Prestamo>();
        }

        public Financiera(string razonSocial):this()
        {
            this.razonSocial = razonSocial;
        }
        #endregion

        #region Métodos
        private float CalcularInteresGanado(TipoDePrestamo tipoPrestamo)
        {
            float interesGanado = 0;

            switch (tipoPrestamo)
            {
                case TipoDePrestamo.Dolares:
                    foreach (Prestamo prestamo in this.listaDePrestamos)
                    {
                        if (prestamo is PrestamoDolar)
                        {
                            interesGanado += ((PrestamoDolar)prestamo).Interes;
                        }
                    }
                    break;

                case TipoDePrestamo.Pesos:
                    foreach (Prestamo prestamo in this.listaDePrestamos)
                    {
                        if (prestamo is PrestamoPesos)
                        {
                            interesGanado += ((PrestamoPesos)prestamo).Interes;
                        }
                    }
                    break;

                case TipoDePrestamo.Todos:
                    foreach (Prestamo prestamo in this.listaDePrestamos)
                    {
                        if (prestamo is PrestamoDolar)
                        {
                            interesGanado += ((PrestamoDolar)prestamo).Interes;
                        }

                        if (prestamo is PrestamoPesos)
                        {
                            interesGanado += ((PrestamoPesos)prestamo).Interes;
                        }
                    }
                    break;
            }

            return interesGanado;
        }

        public void OrdenarPrestamos()
        {
            this.listaDePrestamos.Sort(Prestamo.OrdenarPorFecha);
        }

        public static string Mostrar(Financiera financiera)
        {
            return (string)financiera;
        }
        #endregion

        #region Sobrecargas
        public static explicit operator string(Financiera financiera)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nRazon social: {0}", financiera.RazonSocial);
            retorno.AppendFormat("\nIntereses totales ganados: {0}", financiera.InteresesTotales);
            retorno.AppendFormat("\nIntereses en dólares: {0}", financiera.InteresesEnDolares);
            retorno.AppendFormat("\nIntereses en pesos: {0}", financiera.InteresesEnPesos);

            financiera.OrdenarPrestamos();
            foreach(Prestamo prestamo in financiera.listaDePrestamos)
            {
                retorno.AppendLine(prestamo.Mostrar());            
            }

            return retorno.ToString();
        }
        
        public static Financiera operator +(Financiera financiera, Prestamo prestamo)
        {
            if (financiera != prestamo) //Si el prestamo no pertenece ya a la lista
            {
                financiera.listaDePrestamos.Add(prestamo);
            }

            return financiera;
        }

        public static bool operator ==(Financiera financiera, Prestamo prestamo)
        {
            bool retorno = false;

            if (financiera.listaDePrestamos.Contains(prestamo))
            { //Si la financiera contiene ya a prestamo...
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Financiera financiera, Prestamo prestamo)
        {
            return !(financiera == prestamo);
        }
        #endregion
    }
}
