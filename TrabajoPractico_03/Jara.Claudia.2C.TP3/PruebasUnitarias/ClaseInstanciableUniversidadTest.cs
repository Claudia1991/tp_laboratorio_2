using ClasesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class ClaseInstanciableUniversidadTest
    {
        private Universidad universidad;

        [TestInitialize]
        public void TestInitializer()
        {
            universidad = new Universidad();
        }

        [TestMethod]
        public void ClasesInstanciadasOk_TestMethod()
        {
            
            Assert.IsNotNull(universidad.Alumnos);
        }
    }
}
