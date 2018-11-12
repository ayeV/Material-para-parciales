using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class NoSeGuardoException :Exception
    {

        public NoSeGuardoException(Exception innerException) :base(innerException.Message)
        {

        }
    }
}
