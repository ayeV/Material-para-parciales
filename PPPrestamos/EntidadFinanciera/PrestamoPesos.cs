using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
   public class PrestamoPesos :Prestamo
    {
        float porcentajeInteres;


        public float Interes { get { return this.CalcularInteres(); }  }

        public PrestamoPesos(float monto,DateTime vencimiento,float interes) :base(monto,vencimiento)
        {
            this.porcentajeInteres = interes;
        }

        public PrestamoPesos(Prestamo prestamo,float porcentajeInteres) :this(prestamo.Monto,prestamo.Vencimiento,porcentajeInteres)
        {
           
        }
        #region Metodos
        private float CalcularInteres()
        {

           float total = 0;
           return total = this.Monto + this.Monto * this.porcentajeInteres/100;
    
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            TimeSpan diferencia = nuevoVencimiento.Subtract(this.Vencimiento);
            this.porcentajeInteres = this.porcentajeInteres + diferencia.Days * (float)0.25;
            this.Vencimiento = nuevoVencimiento;

        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine(base.Mostrar());
            sb.AppendFormat("\nMonto: {0}", this.Monto);
            sb.AppendFormat("\nVencimiento: {0}", this.Vencimiento);
            sb.AppendFormat("\nPorcentaje de interes: {0}", this.porcentajeInteres);
            sb.AppendFormat("\nMonto + intereses: {0}", this.Interes);

            return sb.ToString();
        }
        #endregion

    }
}
