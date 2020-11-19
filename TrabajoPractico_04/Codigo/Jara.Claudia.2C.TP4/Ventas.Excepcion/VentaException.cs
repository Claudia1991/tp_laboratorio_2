using System;

namespace Ventas.Excepcion
{
    [Serializable]
    public class VentaException : Exception
    {
        #region Constructores
        public VentaException() { }

        public VentaException(string mensaje) : base(mensaje) { }

        public VentaException(string mensaje, Exception inner) : base(mensaje, inner) { } 
        #endregion
    }
}
