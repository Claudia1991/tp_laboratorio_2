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

        #region Constructor
        public Xml()
        {
            if (!Directory.Exists(nombreCarpetaArchivos))
            {
                Directory.CreateDirectory(nombreCarpetaArchivos);
            }
        }
        #endregion

        #region Metodos
        public bool Guardar(string archivos, T datos)
        {
            bool sePudoGuadar = false;
            try
            {
                using (xmlTextWriter = new XmlTextWriter(Path.Combine(nombreCarpetaArchivos, archivos), Encoding.UTF8))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(xmlTextWriter, datos);
                    sePudoGuadar = true;
                }
                
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return sePudoGuadar;
        }

        public bool Leer(string archivos, out T datos)
        {
            bool sePudoLeer = false;
            datos = default(T);
            try
            {
                if (File.Exists(Path.Combine(nombreCarpetaArchivos, archivos)))
                {
                    using (xmlTextReader = new XmlTextReader(Path.Combine(nombreCarpetaArchivos, archivos)))
                    {
                        xmlSerializer = new XmlSerializer(typeof(T));
                        if (xmlSerializer.CanDeserialize(xmlTextReader))
                        {
                            datos = (T)xmlSerializer.Deserialize(xmlTextReader);
                            sePudoLeer = true;
                        }
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
