using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoDolar:Prestamo
    {
        #region Atributos
        private PeriodicidadDePago periodicidad;
        #endregion

        #region Propiedades
        public PeriodicidadDePago Periodicidad
        {
            get
            {
                return this.periodicidad;
            }
        }

        public float Interes
        {
            get
            {
                return this.CalcularInteres();
            }
        }
        #endregion

        #region Constructores
        public PrestamoDolar(float monto, DateTime vencimiento, PeriodicidadDePago periodicidad):base(monto,vencimiento)
        {
            this.periodicidad = periodicidad;
        }

        public PrestamoDolar(Prestamo prestamo, PeriodicidadDePago periodicidad):this(prestamo.Monto,prestamo.Vencimiento,periodicidad)
        { }
        #endregion

        #region Métodos
        private float CalcularInteres()
        {
            float totalDelPrestamo = 0;

            switch (this.periodicidad)
            { 
                case PeriodicidadDePago.Mensual:
                    totalDelPrestamo = this.monto + this.monto*25/100;
                    break;
                case PeriodicidadDePago.Bimestral:
                    totalDelPrestamo = this.monto + this.monto*35/100;
                    break;
                case PeriodicidadDePago.Trimestral:
                    totalDelPrestamo = this.monto + this.monto*40/100;
                    break;
            }

            return totalDelPrestamo;            
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            TimeSpan diferencia = nuevoVencimiento.Subtract(this.Vencimiento);
            this.monto = this.Monto + diferencia.Days * (float)2.5;
            this.Vencimiento = nuevoVencimiento;
        }

        public override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nMonto: {0}", this.Monto);
            retorno.AppendFormat("\nVencimiento: {0}", this.Vencimiento);
            retorno.AppendFormat("\nMonto + intereses: {0}", this.Interes);
            retorno.AppendFormat("\nPerioricidad: {0}", this.Periodicidad);

            return retorno.ToString();
        }
        #endregion
    }
}
