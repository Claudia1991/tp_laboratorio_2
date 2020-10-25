using ClasesInstanciables;
using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : Universidad
    {
        #region Campos
        private string nombreCarpetaArchivos = "Archivos Guardados";
        private XmlTextWriter xmlTextWriter;
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
                    using (xmlTextWriter = new XmlTextWriter(archivos, Encoding.UTF8))
                    {
                        xmlSerializer = new XmlSerializer(typeof(Universidad));
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
            Universidad universidad = new Universidad();
            datos = (T)universidad;
            try
            {

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
