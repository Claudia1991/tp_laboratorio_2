using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    [Serializable]
    public class NacionalidadInvalidadException : Exception
    {
        #region Constructores
        public NacionalidadInvalidadException() : base(Recursos.MensajeNacionalidadInvalidadException)
        {
        }

        public NacionalidadInvalidadException(string mensaje) : base(mensaje)
        {
        }

        public NacionalidadInvalidadException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
        #endregion
    }
}
