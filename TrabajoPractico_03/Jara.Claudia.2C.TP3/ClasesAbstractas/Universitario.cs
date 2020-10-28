using System;
using System.Text;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Universitario : Persona
    {
        #region Campos
        private int legajo;
        #endregion

        #region Constructor
        public Universitario()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica que 2 objetos sean del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj != null ? this.GetType() == obj.GetType() : false;
        }

        /// <summary>
        /// Devuelve los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Legajo: {0} - ", this.legajo);
            stringBuilder.AppendLine(base.ToString());
            return stringBuilder.ToString();
        }

        protected abstract string ParticipaEnClase();

        /// <summary>
        /// Verifica que 2 universitarios son iguales
        /// </summary>
        /// <param name="universitarioUno"></param>
        /// <param name="universitarioDos"></param>
        /// <returns></returns>
        public static  bool operator ==(Universitario universitarioUno, Universitario universitarioDos)
        {
            return universitarioUno.Equals(universitarioDos) && (universitarioUno.legajo == universitarioDos.legajo || universitarioUno.DNI == universitarioDos.DNI);
        }

        /// <summary>
        /// Verifica si 2 universitarios no son iguales
        /// </summary>
        /// <param name="universitarioUno"></param>
        /// <param name="universitarioDos"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario universitarioUno, Universitario universitarioDos)
        {
            return !(universitarioUno == universitarioDos);
        }
        #endregion
    }
}
