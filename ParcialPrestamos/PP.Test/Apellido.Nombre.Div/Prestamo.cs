using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public abstract class Prestamo
    {
        #region Atributos
        protected float monto;
        protected DateTime vencimiento;
        #endregion

        #region Propiedades
        public float Monto
        {
            get 
            {
                return this.monto;
            }
        }

        public DateTime Vencimiento
        {
            get
            {
                return this.vencimiento;
            }
            set
            {
                if (value.CompareTo(DateTime.Today) >= 0)
                {
                    this.vencimiento = value;
                }
                else
                {
                    this.vencimiento = DateTime.Today;
                }                
            }
        }
        #endregion

        #region Constructores
        public Prestamo(float monto, DateTime vencimiento)
        {
            this.monto = monto;
            this.Vencimiento = vencimiento;            
        }
        #endregion

        #region Métodos
        public static int OrdenarPorFecha(Prestamo p1, Prestamo p2)
        { 
            int retorno = 0;

            if(p1.vencimiento.CompareTo(p2.vencimiento) > 0)
            {
                retorno = 1;
            }
            else if(p1.vencimiento.CompareTo(p2.vencimiento) < 0)
            {
                retorno = -1;
            }

            return retorno;
        }

        public abstract void ExtenderPlazo(DateTime nuevoVencimiento);
        
        public virtual string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nMonto: {0}", this.Monto);
            retorno.AppendFormat("\nVencimiento: {0}", this.Vencimiento);
            return retorno.ToString();
        }
        #endregion
    }
}
