using System;

namespace Excepciones
{
    [Serializable]
    public class NacionalidadInvalidaException : Exception
    {
        #region Constructores
        public NacionalidadInvalidaException() : base(Recursos.MensajeNacionalidadInvalidadException)
        {
        }

        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {
        }

        public NacionalidadInvalidaException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
        #endregion
    }
}
