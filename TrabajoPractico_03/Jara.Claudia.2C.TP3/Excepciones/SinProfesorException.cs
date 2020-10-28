using System;

namespace Excepciones
{
    [Serializable]
    public class SinProfesorException : Exception
    {
        #region Constructores
        public SinProfesorException() : base(Recursos.MensajeSinProfesorException)
        {
        }

        public SinProfesorException(string mensaje) : base(mensaje)
        {
        }

        public SinProfesorException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
        #endregion
    }
}
