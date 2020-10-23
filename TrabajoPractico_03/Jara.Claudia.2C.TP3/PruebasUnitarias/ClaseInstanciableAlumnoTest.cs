using System;
using ClasesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class ClaseInstanciableAlumnoTest
    {
        private Alumno alumno;

        [TestInitialize]
        public void TestInitializer()
        {
            alumno = new Alumno();
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoTesMethod()
        {
            
            alumno.Nacionalidad = EntidadesAbstractas.Persona.ENacionalidad.Extranjero;
            alumno.StringToDni = "1";


        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalidoTesMethod()
        {

            alumno.Nacionalidad = (EntidadesAbstractas.Persona.ENacionalidad)2;
            alumno.DNI = 1;
        }
    }
}
