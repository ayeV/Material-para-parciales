using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
  public abstract class Prestamo
    {
        protected float monto;
        protected DateTime vencimiento;

        public float Monto
        {
            get { return this.monto; }
        }

        public DateTime Vencimiento
        {
             set
            {
                if(value > DateTime.Now)
                {
                    this.vencimiento = value;
                }
                else
                {
                    this.vencimiento = DateTime.Now;
                }

            }

            get { return this.vencimiento; }
        }

        public Prestamo (float monto, DateTime vencimiento)
        {
            this.vencimiento = vencimiento;
            this.monto = monto;
        }

        public static int OrdenarPorFecha(Prestamo p1, Prestamo p2)
        {
            int retorno = 0;
            if(p1.vencimiento > p2.vencimiento)
            {
                retorno = 1;
            }
            else if(p1.vencimiento < p2.vencimiento)
            {
                retorno = -1;
            }
            return retorno;

        }

       public abstract void ExtenderPlazo(DateTime nuevoVencimiento);

        public virtual string Mostrar()
        {
            return string.Format("\nVencimiento {0}\nMonto {1}", this.vencimiento, this.monto);
        }
    }
}
