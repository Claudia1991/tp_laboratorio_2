using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;

namespace Test
{
    [TestClass]
    public class MetodoExtensionTest
    {
        [TestMethod]
        public void MetodoExtension_TestMethod()
        {
            DateTime ahora = DateTime.Now;
            DateTime ahoraMasDiezMinutos = ahora.AddMinutes(10);

            Assert.IsTrue(ahora.DiferenciaEnMinutos(ahoraMasDiezMinutos) == 10);

        }
    }
}
