using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        string _apellido;
        int _dni;
        string _fotoAlumno;
        string _nombre;


        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public string Foto
        {
            get { return this._fotoAlumno; }
            set { this._fotoAlumno = value; }
        }
        public int DNI
        {
            get { return this._dni; }
            set { this._dni = value; }
        }

        public Alumno(string nombre, string apellido, int dni, string ruta)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._dni = dni;
            this._fotoAlumno = ruta;
        }
    }
}
