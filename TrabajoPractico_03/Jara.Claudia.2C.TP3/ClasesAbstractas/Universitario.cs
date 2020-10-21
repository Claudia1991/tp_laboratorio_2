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

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }
        #endregion

        #region Metodos
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected virtual string MostrarDatos()
        {
            return string.Empty;
        }

        protected abstract string ParticipaEnClase();

        public static  bool operator ==(Universitario universitarioUno, Universitario universitarioDos)
        {
            return true;
        }

        public static bool operator !=(Universitario universitarioUno, Universitario universitarioDos)
        {
            return true;
        }
        #endregion
    }
}
