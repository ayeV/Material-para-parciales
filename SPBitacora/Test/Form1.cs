using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace Test
{
    public partial class Form1 : Form
    {
        LosHilos hilos;
        public Form1()
        {
            InitializeComponent();
            this.hilos = new LosHilos();
            this.hilos.AvisoFin += MostrarMensajeFin;

        }

        private void btnLanzar_Click(object sender, EventArgs e)
        {
            try
            {
                this.hilos += 1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.hilos.Bitacora);
        }

        void MostrarMensajeFin(string msj)
        {
            MessageBox.Show(msj);
        }
    }
}
