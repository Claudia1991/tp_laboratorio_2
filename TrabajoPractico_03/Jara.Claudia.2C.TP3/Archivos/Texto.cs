using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Campos
        private string nombreArchivoTexto = "ArchivoTexto.txt";
        private string nombreCarpetaArchivos = "Archivos Guardados";
        #endregion

        #region Metodos
        public bool Guardar(string archivos, string datos)
        {
            throw new NotImplementedException();
        }

        public bool Leer(string archivos, out string datos)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
