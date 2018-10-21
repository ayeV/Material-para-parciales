using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Autor
  {
    string apellido;
    string nombre;

    #region Constructor
    public Autor(string nombre, string apellido)
    {
      this.nombre = nombre;
      this.apellido = apellido;
    }
    #endregion

    #region Operadores
    public static bool operator == (Autor a, Autor b)
    {
      bool retorno = false;

      if(a.nombre == b.nombre && a.apellido == b.apellido)
      {
        retorno = true;
      }
      return retorno;

    }
    public static bool operator !=(Autor a, Autor b)
    {
      return !(a == b);
    }

    public static implicit operator string (Autor a)
    {
        return a.nombre + "-" + a.apellido;
      
    }

    #endregion
  }
}
