using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {

        #region Enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Campos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get;
            set;
        }

        public int DNI
        {
            get;
            set;
        }

        public ENacionalidad Nacionalidad
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public string StringToDni
        {
            get;
            set;
        }
        #endregion

        #region Constructores
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {

        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return base.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return 0;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return 0;
        }

        private string ValidarNombreApellido(string dato)
        {
            return string.Empty;
        }
        #endregion
    }
}
