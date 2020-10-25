using Excepciones;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Campos
        private string nombreCarpetaArchivos = "Archivos Guardados";
        private XmlTextWriter xmlTextWriter;
        private XmlTextReader xmlTextReader;
        private XmlSerializer xmlSerializer;

        #endregion

        #region Metodos
        public bool Guardar(string archivos, T datos)
        {
            bool sePudoGuadar = false;
            try
            {
                if (!File.Exists(Path.Combine(nombreCarpetaArchivos, archivos)))
                {
                    using (xmlTextWriter = new XmlTextWriter(Path.Combine(nombreCarpetaArchivos, archivos), Encoding.UTF8))
                    {
                        xmlSerializer = new XmlSerializer(typeof(T));
                        xmlSerializer.Serialize(xmlTextWriter, datos);
                        sePudoGuadar = true;
                    }
                }
                else
                {
                    throw new ArchivosException("Existe el archivo");
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return sePudoGuadar;
            /*Aca es donde serializo, ya que me estan pasando el objeto*/
        }

        public bool Leer(string archivos, out T datos)
        {
            //Deserializamos en bytes y devolvemos un objeto
            bool sePudoLeer = false;
            try
            {
                if (File.Exists(Path.Combine(nombreCarpetaArchivos, archivos)))
                {
                    using (xmlTextReader = new XmlTextReader(Path.Combine(nombreCarpetaArchivos, archivos)))
                    {
                        xmlSerializer = new XmlSerializer(typeof(T));
                        datos = (T)xmlSerializer.Deserialize(xmlTextReader);
                        sePudoLeer = true;
                    }
                }
                else
                {
                    throw new ArchivosException("Noo existe el archivo");
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
