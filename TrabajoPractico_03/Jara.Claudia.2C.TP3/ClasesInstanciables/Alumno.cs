using EntidadesAbstractas;
using System;
using System.Text;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    [Serializable]
    public sealed class Alumno : Universitario
    {
        #region Enumerados
        public enum EEstadoCuenta
        {
            AlDia,
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
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = clasesQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases clasesQueToma, EEstadoCuenta estadoDeCuenta) 
            : this(id, nombre, apellido,dni,nacionalidad ,clasesQueToma)
        {
            this.estadoCuenta = estadoDeCuenta;
        }
        #endregion

        #region Metodos Protegidos
        /// <summary>
        /// Muestra las clases del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticipaEnClase()
        {
            return $"TOMA CLASE DE: {this.claseQueToma.ToString()}";
        }

        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("Clases que toma: {0}, Estado de cuenta: {1}", this.ParticipaEnClase(), this.estadoCuenta);
            return stringBuilder.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Verifica si el alumno no toma la clase
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno alumno, EClases clase)
        {
            /* Logica: Un Alumno será distinto a un EClase sólo si no toma esa clase. */
            return alumno.claseQueToma != clase;
        }

        /// <summary>
        /// Verifica si el alumno toma la clase.
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno alumno, EClases clase)
        {
            /* Logica: Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor. */
            return alumno.claseQueToma == clase && alumno.estadoCuenta != EEstadoCuenta.Deudor;
        }
        #endregion
    }
}
