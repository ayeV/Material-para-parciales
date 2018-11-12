using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Entidades;
namespace Test
{
    public partial class Form1 : Form
    {
        public delegate void CorrenCallback(int avance, Corredor corredor);
        List<Persona> _corredores;
        List<Thread> _corredoresActivos;
        bool _hayGanador;
        public Form1()
        {
            InitializeComponent();
            this._corredores = new List<Persona>();
            this._corredoresActivos = new List<Thread>();
            this._corredores.Add(new Persona("Fernando", 9, Corredor.Carril.Carril_1));
            this._corredores.Add(new Persona("Fernanda", 15, Corredor.Carril.Carril_2));
            this._hayGanador = false;
            
        }

        private void btnCorrer_Click(object sender, EventArgs e)
        {
            this._hayGanador = false;
            Thread t1 = new Thread(this._corredores[0].Correr);
            Thread t2 = new Thread(this._corredores[1].Correr);
            this._corredoresActivos.Clear();
            this._corredoresActivos.Add(t1);
            this._corredoresActivos.Add(t2);

            foreach (Thread item in this._corredoresActivos)
            {
                try
                {
                    item.Start();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            this._corredores[0].Corriendo += PersonaCorriendo;
            this._corredores[1].Corriendo += PersonaCorriendo;

            

        }

        

        void AnalizarCarrera(ProgressBar carril,int avance,Corredor corredor)
        {
            int nuevoValor = carril.Value + avance;
            if(nuevoValor < 100 && this._hayGanador == false)
            {
                carril.Value = nuevoValor;
            }
            else if(this._hayGanador == false)
            {
                carril.Value = 100;
                this._hayGanador = true;
                this.HayGanador(corredor);
            }
        }

        void HayGanador(Corredor corredor)
        {
            foreach (Thread item in this._corredoresActivos)
            {
                item.Abort();
            }

            corredor.Guardar("Ganadores");
            MessageBox.Show("El ganador es: " + corredor.ToString());
            btnCorrer.Enabled = true;
        }

        void LimpiarCarriles()
        {
            pgbCarril1.Value = 0;
            pgbCarril2.Value = 0;
            
        }

        void PersonaCorriendo(int avance,Corredor corredor)
        {
            if (pgbCarril1.InvokeRequired || pgbCarril2.InvokeRequired)
            {
                CorrenCallback d = new CorrenCallback(PersonaCorriendo);
                this.Invoke(d, new object[] { avance, corredor });
            }
            else
            {
              if(corredor.CarrilElegido == Corredor.Carril.Carril_1)
                {
                   this.AnalizarCarrera(pgbCarril1, avance, corredor);
                }
              else
                {
                   this.AnalizarCarrera(pgbCarril2, avance, corredor);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Thread thread in this._corredoresActivos)
            {
                thread.Abort();
            }
        }

    }
}
