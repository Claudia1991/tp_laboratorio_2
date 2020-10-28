using ClasesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PruebasUnitarias
{
    [TestClass]
    public class ClaseInstanciableJornadaTest
    {
        #region Campos
        Jornada jornada;
        #endregion

        #region Metodos de test
        [TestInitialize]
        public void TestInitialize()
        {
            List<Alumno> alumnos = new List<Alumno>() 
            {
                new Alumno(4, "Miguel", "Hernandez", "92264456",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.AlDia),
                new Alumno(5, "Carlos", "Gonzalez", "12236456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.AlDia),
                new Alumno(6, "Juan", "Perez", "12234656",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Deudor),
                new Alumno(8, "Rodrigo", "Smith", "22236456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.AlDia)
            };

            Profesor profesor = new Profesor(1, "Juan", "Lopez", "12224458",EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            jornada = new Jornada(Universidad.EClases.Programacion, profesor) 
            {
                Alumnos = alumnos
            };
        }

        [TestMethod]
        public void CuandoEjecuto_JornadaLeerMetodo_TestMethod()
        {
            string jornadaString;
            Jornada.Guardar(jornada);
            jornadaString = Jornada.Leer();
            Assert.IsNotNull(jornadaString);
        }

        [TestMethod]
        public void CuandoEjecuto_JornadaGuardarMetodo_TestMethod()
        {
            Assert.IsTrue(Jornada.Guardar(jornada));
        }
        #endregion
    }
}
