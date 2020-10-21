﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    [Serializable]
    public class AlumnoRepetidoException : Exception
    { 
        #region Constructores
        public AlumnoRepetidoException() : base(Recursos.MensajeAlumnoRepetidoException)
        {
        }

        public AlumnoRepetidoException(string mensaje) : base(mensaje)
        {
        }

        public AlumnoRepetidoException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
        #endregion
    }
}
