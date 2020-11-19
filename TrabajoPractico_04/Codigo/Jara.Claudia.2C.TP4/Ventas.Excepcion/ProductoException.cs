using System;

namespace Ventas.Excepcion
{
    [Serializable]
    public class ProductoException : Exception
    {
        #region Constructores
        public ProductoException() { }

        public ProductoException(string mensaje) : base(mensaje) { }

        public ProductoException(string mensaje, Exception inner) : base(mensaje, inner) { } 
        #endregion

    }
}
