﻿using System;

namespace Ventas.Excepcion
{
    [Serializable]
    public class ArchivosException : Exception
    {
        #region Constructores
        public ArchivosException() { }

        public ArchivosException(string mensaje) : base(mensaje) { }

        public ArchivosException(string mensaje, Exception inner) : base(mensaje, inner) { } 
        #endregion
    }
}
