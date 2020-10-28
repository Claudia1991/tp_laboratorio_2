using System;
using System.Collections.Generic;
using static ClasesInstanciables.Universidad;
using EntidadesAbstractas;
using System.Text;

namespace ClasesInstanciables
{
    [Serializable]
    public sealed class Profesor : Universitario
    {
        #region Campos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructor
        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {  
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos 
        /// <summary>
        /// Muestra las clases que dicta el profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticipaEnClase()
        {
            return $"CLASES DEL DIA: {ObtenerClasesDelDia()}";
        }

        /// <summary>
        /// Carga 2 clases Random para el profesor
        /// </summary>
        private void _randomClases()
        {
            for(int i = 0; i<2; i++)
            {
                int clase = random.Next(0, 3);
                this.clasesDelDia.Enqueue((EClases)clase);
            }
        }

        /// <summary>
        /// Devuelve los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        /// <summary>
        /// Devuelve los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Concat(this.MostrarDatos(), this.ParticipaEnClase());
        }

        /// <summary>
        /// Obtiene las clases del profesor
        /// </summary>
        /// <returns></returns>
        private string ObtenerClasesDelDia()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (EClases clase in this.clasesDelDia)
            {
                stringBuilder.AppendFormat("Clase: {0} ", clase);
            }
            return stringBuilder.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Verifica si el profesor no da esa clase
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor profesor, EClases clase)
        {
            return !(profesor == clase);
        }

        /// <summary>
        /// Verifica si el profesor da esa clase
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor profesor, EClases clase)
        {
            return profesor.clasesDelDia.Contains(clase);
        }
        #endregion
    }
}
