using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Excepcion
{
    public class ProductoException : Exception
    {
        public ProductoException() { }

        public ProductoException(string mensaje) : base(mensaje) { }

        public ProductoException(string mensaje, Exception inner) : base(mensaje, inner) { }

    }
}
