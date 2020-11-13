using System;
using System.IO;
using System.Text;
using Ventas.Excepcion;

namespace Ventas.Utilities
{
    public class Texto : IArchivos<string>
    {
        #region Campos
        private readonly string nombreCarpetaArchivos = "Archivos Guardados";
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        #endregion

        #region Constructor
        public Texto()
        {
            if (!Directory.Exists(nombreCarpetaArchivos))
            {
                Directory.CreateDirectory(nombreCarpetaArchivos);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda el string en un archivo de texto.
        /// </summary>
        /// <param name="archivos"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivos, string datos)
        {
            bool sePudoGuadar = false;
            try
            {
                if (datos != null)
                {
                    using (streamWriter = new StreamWriter(Path.Combine(nombreCarpetaArchivos, archivos), false, Encoding.UTF8))
                    {
                        streamWriter.WriteLine(datos);
                        sePudoGuadar = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException();
            }
            return sePudoGuadar;
        }

        /// <summary>
        /// Lee los datos desde un archivo de texto.
        /// </summary>
        /// <param name="archivos"></param>
        /// <param name="datos"></param>
        /// <returns>Devuelve true si lo pudo leer, false en cualquier otro caso.</returns>
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
                    throw new ArchivosException(string.Format("No existe archivo en la ruta: {0}", Path.Combine(nombreCarpetaArchivos, archivos)));
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException();
            }
            return sePudoLeer;
        }
        #endregion
    }
}
