using Excepciones;
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
        private string nombreCarpetaArchivos = "Archivos Guardados";
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        #endregion

        #region Metodos
        public bool Guardar(string archivos, string datos)
        {
            bool sePudoGuadar = false;
            try
            {
                if (!File.Exists(Path.Combine(nombreCarpetaArchivos, archivos)))
                {
                    using (streamWriter = new StreamWriter(Path.Combine(nombreCarpetaArchivos, archivos), false, Encoding.UTF8))
                    {
                        streamWriter.WriteLine(datos);
                        sePudoGuadar = true;
                    }
                }
                else
                {
                    throw new ArchivosException(string.Format("Ya existe un archivo con ese nombre: {0}", archivos));
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return sePudoGuadar;
        }

        public bool Leer(string archivos, out string datos)
        {
            bool sePudoLeer = false;
            try
            {
                if (File.Exists(Path.Combine(nombreCarpetaArchivos, archivos)))
                {
                    using (streamReader = new StreamReader(Path.Combine(nombreCarpetaArchivos, archivos)))
                    {
                        datos = streamReader.ReadToEnd();
                        sePudoLeer = true;
                    }
                }
                else
                {
                    throw new ArchivosException(string.Format("No existe archivo en la ruta: {0}", archivos));
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return sePudoLeer;
        }
        #endregion
    }
}
