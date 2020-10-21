using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Campos
        private Queue<EClases> clasesDelDia;
        private Random random;
        #endregion

        #region Constructor
        private Profesor()
        {

        }

        public Profesor()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }
        #endregion

        #region Metodos 
        protected override string ParticipaEnClase()
        {
            throw new NotImplementedException();
        }

        private void _randomClases()
        {

        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator !=(Profesor profesor, EClases clase)
        {
            return true;
        }

        public static bool operator ==(Profesor profesor, EClases clase)
        {
            return true;
        }
        #endregion
    }
}
