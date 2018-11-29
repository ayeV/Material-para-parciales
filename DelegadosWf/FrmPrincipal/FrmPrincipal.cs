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
    public partial class FrmPrincipal : Form
    {
        public ActualizarNombrePorDelegado MiDelegado;
        public ActualizarNombrePorDelegado actualizarFotoPorDelegado;
        public MostrarAlumnoPorDelegado mostrarAlumnoDelegado;

        protected Alumno alumno;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void datosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDatos datos = new FrmDatos();
           
            datos.Show(this);
            this.MiDelegado += datos.ActualizarNombre;
            this.actualizarFotoPorDelegado += datos.ActualizarFoto;
          

        }



        private void testDelegadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestDelegados delegados = new frmTestDelegados();
            delegados.Show(this);
            //this.MiDelegado.Invoke("Probando");
            //this.MiDelegado("Probando");
        }

        private void testAlumnosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDatosAlumno alumno = new frmDatosAlumno();
            alumno.Show(this);
            mostrarAlumnoDelegado = new MostrarAlumnoPorDelegado(alumno.ActualizarAlumno);
            mostrarAlumnoDelegado.Invoke(alumno.RetornoAlumno, EventArgs.Empty);
           
        }

        private void alumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaAlumno altaAlumno = new frmAltaAlumno();
            altaAlumno.Show(this);
        }
    }
}
