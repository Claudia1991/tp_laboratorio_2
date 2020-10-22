using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos
        private int legajo;
        #endregion

        #region Constructor
        public Universitario()
        {
            this.legajo = 0;
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        public override bool Equals(object obj)
        {
            return obj != null ? this.GetType().Equals(obj) : false;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Legajo: {0}", this.legajo);
            stringBuilder.AppendLine(base.ToString());
            return stringBuilder.ToString();
        }

        protected abstract string ParticipaEnClase();

        public static  bool operator ==(Universitario universitarioUno, Universitario universitarioDos)
        {
            return universitarioUno.Equals(universitarioDos) && (universitarioUno.legajo == universitarioDos.legajo || universitarioUno.DNI == universitarioDos.DNI);
        }

        public static bool operator !=(Universitario universitarioUno, Universitario universitarioDos)
        {
            return !(universitarioUno == universitarioDos);
        }
        #endregion
    }
}
