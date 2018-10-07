using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoPesos:Prestamo
    {
        #region Atributos
        private float porcentajeInteres;
        #endregion

        #region Propiedades
        public float Interes
        {
            get
            {
                return this.CalcularInteres();
            }
        }

        private float CalcularInteres()
        {
            float totalDelPrestamo = this.Monto + this.Monto * this.porcentajeInteres / 100;

            return totalDelPrestamo;
        }
        #endregion

        #region Constructores
        public PrestamoPesos(float monto, DateTime vencimiento, float interes):base(monto,vencimiento)
        {
            this.porcentajeInteres = interes;
        }

        public PrestamoPesos(Prestamo prestamo, float porcentajeInteres):this(prestamo.Monto,prestamo.Vencimiento,porcentajeInteres)
        { }
        #endregion

        #region Métodos
        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            TimeSpan diferencia = nuevoVencimiento.Subtract(this.Vencimiento);
            this.porcentajeInteres = this.porcentajeInteres + diferencia.Days * (float)0.25;
            this.Vencimiento = nuevoVencimiento;
        }

        public override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("\nMonto: {0}", this.Monto);
            retorno.AppendFormat("\nVencimiento: {0}", this.Vencimiento);
            retorno.AppendFormat("\nMonto + Intereses: {0}", this.Interes);
            retorno.AppendFormat("\nPorcentaje Interes: {0}", this.porcentajeInteres);

            return retorno.ToString();
        }
        #endregion

    }
}
