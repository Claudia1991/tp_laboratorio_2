using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Campos
        private string nombreArchivoTextoXml = "ArchivoXml.txt";
        private string nombreCarpetaArchivos = "Archivos Guardados";
        #endregion

        #region Metodos
        public bool Guardar(string archivos, T datos)
        {
            throw new NotImplementedException();
        }

        public bool Leer(string archivos, out T datos)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
