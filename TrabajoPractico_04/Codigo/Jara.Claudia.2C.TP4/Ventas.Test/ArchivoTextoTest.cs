using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ventas.Excepcion;
using Ventas.Utilities;

namespace Ventas.Test
{
    [TestClass]
    public class ArchivoTextoTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void Guardar_Exception_TestMethod()
        {
            Texto texto = new Texto();
            bool seGuardo = texto.Guardar("ArchivosTexto.txt", null);
        }

        [TestMethod]
        public void Guardar_Ok_TestMethod()
        {
            Texto texto = new Texto();
            bool seGuardo = texto.Guardar("ArchivosTexto.txt", "Test method guardar");
            Assert.IsTrue(seGuardo);
        }
    }
}
