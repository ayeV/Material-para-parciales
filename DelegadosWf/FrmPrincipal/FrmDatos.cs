using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmPrincipal
{
    public partial class FrmDatos : Form
    {

        public FrmDatos()
        {
            InitializeComponent();
        }

        public void ActualizarNombre(string dato)
        {
            this.lblDatos.Text = dato;
        }

        public void ActualizarFoto(string dato)
        {
            this.pictureBox1.ImageLocation = dato;
        }


    }
}
