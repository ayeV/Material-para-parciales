using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Corredor
    {
        public enum Carril { Carril_1, Carril_2 };

        protected static Random _avance;
        protected Carril _carrilElegido;
        short _velocidadMaxima;

        public short VelocidadMaxima
        {
            get { return this._velocidadMaxima; }
            set
            {
                if(value <= 10)
                {
                    this._velocidadMaxima = value;
                }
            }
        }

        public Carril CarrilElegido
        {
            get { return this._carrilElegido; }
        }

        Corredor()
        {
            _avance = new Random(Guid.NewGuid().GetHashCode());

        }

        protected Corredor(short velocidadMax, Carril carrilElegido) :this()
        {
            this._velocidadMaxima = velocidadMax;
            this._carrilElegido = carrilElegido;
        }

        public abstract void Correr();

        public virtual void Guardar(string path)
        {
            throw new NotImplementedException();
        }
    }
}
