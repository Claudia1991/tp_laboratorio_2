using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    [Serializable]
    public class ArchivosException : Exception
    {
        #region Constructores
        public ArchivosException() : base(Recursos.MensajeArchivosException)
        {
        }

        public ArchivosException(string mensaje) : base(mensaje)
        {

        }

        public ArchivosException(Exception innerException) : base(string.Empty, innerException)
        {

        }
        #endregion
    }
}
