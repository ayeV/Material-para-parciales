using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Manual :Libro
  {
    public ETipo tipo;

    public Manual(string titulo, float precio, string nombre, string apellido, ETipo tipo) :base(precio,titulo,nombre,apellido)
    {
      this.tipo = tipo;
    }

    public static implicit operator double(Manual m)
    {
      return m._precio;
    }

    public static bool operator ==(Manual a, Manual b)
    {
      bool retorno = false;

      if(a.tipo == b.tipo && (Libro)a == (Libro)b)
      {
        retorno = true;
      }

      return retorno;
    }

    public static bool operator !=(Manual a, Manual b)
    {
      return !(a == b);
    }

    public string Mostrar()
    {
     
      return string.Format( "Tipo: {0}\n\n", this.tipo);
    }
  }
}
