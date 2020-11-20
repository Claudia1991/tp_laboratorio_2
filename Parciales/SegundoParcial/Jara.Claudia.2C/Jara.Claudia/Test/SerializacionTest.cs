using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class SerializacionTest
    {
        Bombero bombero = new Bombero("BomberoUno");
        Bombero bomberodOS;
        string esperado = "Id: 1Entrada: PruebaAlumnoClaudia Jara";

        [TestMethod]
        public void BomberoTest_SerializarBinario()
        {
            bombero.Guardar(new Bombero("BomberoUno"));
        }

        [TestMethod]
        public void BomberoTest_LeerBinario()
        {
            bombero.Guardar(new Bombero("BomberoUno"));
            bomberodOS =  bombero.Leer();
            Assert.IsTrue(bombero.Nombre == bomberodOS.Nombre);
        }

        [TestMethod]
        public void BomberoTest_LeerBD()
        {
            string stringBd = ((IArchivos<string>)bombero).Leer();
            Assert.IsTrue(stringBd == esperado);
        }

        [TestMethod]
        public void BomberoTest_GuardarBD()
        {
             ((IArchivos<string>)bombero).Guardar("Prueba");

        }
    }
}
