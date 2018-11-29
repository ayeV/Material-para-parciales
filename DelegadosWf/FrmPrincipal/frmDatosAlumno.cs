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

namespace FrmPrincipal
{
    public partial class frmDatosAlumno : frmAltaAlumno
    {
        public frmDatosAlumno()
        {
            InitializeComponent();
        }


        public void ActualizarAlumno(Alumno a, EventArgs e)
        {
            this.txtApellido.Text = a.Apellido;
            this.txtDNI.Text = a.DNI.ToString();
            this.txtNombre.Text = a.Nombre;
            this.pictureBox1.ImageLocation = a.Foto;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
