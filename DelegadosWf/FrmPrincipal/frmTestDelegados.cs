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
    public partial class frmTestDelegados : Form
    {
        string picturePath;
        public frmTestDelegados()
        {
            InitializeComponent();
            ConfigurarOpenSaveFileDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string s = this.textBox1.Text;

            ((FrmPrincipal)this.Owner).MiDelegado(s);
            ((FrmPrincipal)this.Owner).actualizarFotoPorDelegado(picturePath);
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

        private void btnFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            this.picturePath = openFileDialog1.FileName;
        }
    }
}
