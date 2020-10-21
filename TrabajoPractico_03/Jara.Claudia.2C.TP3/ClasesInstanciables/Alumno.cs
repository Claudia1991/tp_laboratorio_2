using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerados
        public enum EEstadoCuenta
        {
            Aldia,
            Deudor,
            Becado
        }
        #endregion

        #region Campos
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        public Alumno()
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases clasesQueToma)
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases clasesQueToma, EEstadoCuenta estadoDeCuenta)
        {

        }
        #endregion

        #region Metodos Protegidos
        protected override string ParticipaEnClase()
        {
            throw new NotImplementedException();
        }

        protected override string MostrarDatos()
        {
            return string.Empty;
        }
        #endregion

        #region Sobrecarga de operadores
        public override string ToString()
        {
            return base.ToString();
        }

        public static bool operator !=(Alumno alumno, EClases clase)
        {
            return true;
        }

        public static bool operator ==(Alumno alumno, EClases clase)
        {
            return true;
        }
        #endregion
    }
}
