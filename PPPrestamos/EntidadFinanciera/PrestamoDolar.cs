using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoDolar : Prestamo
    {
        PeriodicidadDePagos periodicidad;

        public PeriodicidadDePagos Periodicidad
        {
            get{return this.periodicidad; }

        }

        public float Interes
        {
            get { return this.CalcularInteres(); }
        }

        public PrestamoDolar(float monto, DateTime vencimiento, PeriodicidadDePagos periodicidad) : base(monto, vencimiento)
        {
            this.periodicidad = periodicidad;
        }

        public PrestamoDolar(Prestamo prestamo, PeriodicidadDePagos periodicidad) : this(prestamo.Monto, prestamo.Vencimiento, periodicidad)
        {

        }

        #region Metodos
        private float CalcularInteres()
        {

            float total = 0;

            switch (this.periodicidad)
            {
                case PeriodicidadDePagos.Mensual:

                    total = this.Monto + this.Monto *25/100;
                    break;
                case PeriodicidadDePagos.Bimestral:

                    total = this.Monto + this.Monto *35/100;
                    break;
                case PeriodicidadDePagos.Trimestral:

                    total = this.Monto + this.Monto *40/100;
                    break;

            }

            return total;


        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            TimeSpan diferencia = nuevoVencimiento.Subtract(this.Vencimiento);
            this.monto = this.Monto + diferencia.Days * (float)2.5;
            this.Vencimiento = nuevoVencimiento;

        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine(base.Mostrar());
            sb.AppendFormat("\nMonto: {0}", this.Monto);
            sb.AppendFormat("\nVencimiento: {0}", this.Vencimiento);
            sb.AppendFormat("\nPeriodicidad: {0}", this.Periodicidad);
            sb.AppendFormat("\nMonto + intereses: {0}", this.Interes);

            return sb.ToString();
        }
        #endregion

    }
}
