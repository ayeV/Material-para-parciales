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
  public partial class frmAltaAlumno : Form
  {
        public static Alumno alumno;

        public Alumno RetornoAlumno
        {
            get { return alumno; }
            
        }
        public frmAltaAlumno()
    {
      InitializeComponent();
      ConfigurarOpenSaveFileDialog();

    }

        private void ConfigurarOpenSaveFileDialog()
        {
            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Seleccione una foto...";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string foto = txtFoto.Text;
                int dni = int.Parse(txtDNI.Text);

                Alumno alumnito = new Alumno(nombre, apellido, dni, foto);
                alumno = alumnito;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error desconocido");

            }
            this.Close();
        }

        private void txtFoto_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFoto.Text = openFileDialog1.FileName;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
