using System;

namespace Excepciones
{
    [Serializable]
    public class DniInvalidoException : Exception
    {
        #region Constructores
        public DniInvalidoException() : base(Recursos.MensajeDniInvalidoException)
        {
        }

        public DniInvalidoException(string mensaje) : base(mensaje)
        {
        }

        public DniInvalidoException(Exception innerException) : this(string.Empty, innerException)
        {
        }

        public DniInvalidoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
        #endregion
    }
}
