using System;
using Archivos;
using ClasesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PruebasUnitarias
{
    [TestClass]
    public class ArchivosUnitTest
    {
        #region Campos
        private string nombreArchivoTexto = "archivoTextoMosck.txt";
        private string nombreArchivoXml = "archivoXmlMosck.xml";
        private string datosString = "Prueba archivo guardar";
        private Alumno alumno = new Alumno(1, "Claudia", "Jara", "99912315", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
        #endregion

        #region Metodos
        [TestMethod]
        public void Arcvhivos_Texto_Guardar_TestMethod()
        {
            var mock = new Mock<IArchivo<string>>();
            mock.Setup( m => m.Guardar(nombreArchivoTexto,datosString)).Returns(true);
            var mockObject = mock.Object;

            Assert.IsFalse(mockObject.Guardar("", null));
            Assert.IsFalse(mockObject.Guardar("", datosString));
        }

        [TestMethod]
        public void Arcvhivos_Texto_Leer_TestMethod()
        {
            var mock = new Mock<IArchivo<string>>();
            string datosIngresar;
            mock.Setup(m=> m.Leer(nombreArchivoTexto, out datosIngresar)).Returns(true);
            var mockObjet = mock.Object;

            Assert.IsFalse(mockObjet.Leer("",out datosIngresar));
        }

        [TestMethod]
        public void Arcvhivos_XML_Guardar_TestMethod()
        {
            var mock = new Mock<IArchivo<Alumno>>();
            mock.Setup(m=>m.Guardar(nombreArchivoXml,alumno)).Returns(true);
            var mockObject = mock.Object;

            Assert.IsFalse(mockObject.Guardar(nombreArchivoXml, null));
            Assert.IsFalse(mockObject.Guardar(string.Empty, null));
        }

        [TestMethod]
        public void Arcvhivos_XML_Leer_TestMethod()
        {
            var mock = new Mock<IArchivo<Alumno>>();
            Alumno alumnoMock;
            mock.Setup(m=>m.Leer(nombreArchivoXml, out alumnoMock)).Returns(true);
            var mockObject = mock.Object;

            Assert.IsFalse(mockObject.Leer(string.Empty, out alumnoMock));
        }
        #endregion
    }
}
