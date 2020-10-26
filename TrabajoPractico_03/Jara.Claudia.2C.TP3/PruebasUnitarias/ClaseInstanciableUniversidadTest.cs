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

        [TestMethod]
        public void CuandoEjecuto_MetodoLeerUniversidad_TestMethod()
        {
            this.CargarDatosUniversidad();
            Universidad.Guardar(universidad);
            Universidad universidadXml = Universidad.Leer();
            Assert.IsNotNull(universidadXml);
        }

        [TestMethod]
        public void CuandoEjecuto_MetodoGuardarUniversidad_TestMethod()
        {
            this.CargarDatosUniversidad();

            Assert.IsTrue(Universidad.Guardar(universidad));
        }

        #region Metodos Privados
        private void CargarDatosUniversidad()
        {
            try
            {
                Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion,
                Alumno.EEstadoCuenta.AlDia);
                universidad += a4;
                Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.AlDia);
                universidad += a5;
                Alumno a6 = new Alumno(6, "Juan", "Perez", "12234656",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
                universidad += a6;
                Alumno a7 = new Alumno(7, "Joaquin", "Suarez", "91122456",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.AlDia);
                universidad += a7;
                Alumno a8 = new Alumno(8, "Rodrigo", "Smith", "22236456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion,
                Alumno.EEstadoCuenta.AlDia);
                universidad += a8;
                Profesor i1 = new Profesor(1, "Juan", "Lopez", "12224458",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino);
                universidad += i1;
                Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino);
                universidad += i2;
                universidad += Universidad.EClases.Programacion;
                universidad += Universidad.EClases.Laboratorio;
                universidad += Universidad.EClases.Legislacion;
                universidad += Universidad.EClases.SPD;
            }
            catch (System.Exception)
            {
            }
        }
        #endregion
    }
}
