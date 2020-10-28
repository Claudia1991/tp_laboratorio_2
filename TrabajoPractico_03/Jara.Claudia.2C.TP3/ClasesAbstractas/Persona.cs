using Excepciones;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    [XmlInclude(typeof(Universitario))]
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
        private Regex regex;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }

        

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        public string StringToDni
        {
            get
            {
                return DNI.ToString();
            }
            set
            {
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDni = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Nombre: {0} - Apellido: {1} - DNI: {2} - Nacionalidad: {3} -", Nombre, Apellido, DNI, Nacionalidad);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Valida el dni segun la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dni = -1;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                    {
                        dni = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();

                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        dni = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();

                    }
                    break;
                default:
                    throw new NacionalidadInvalidaException();
            }
            return dni;
        }

        /// <summary>
        /// Valida el dni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;
            int dniParseado;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    regex = new Regex("[0-9]{1,8}");
                    if (regex.IsMatch(dato) && int.TryParse(dato, out dniParseado))
                    {
                        dni = ValidarDni(nacionalidad, dniParseado);
                    }
                    else
                    {
                        throw new DniInvalidoException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    regex = new Regex("[0-9]{8}");
                    if (regex.IsMatch(dato) && int.TryParse(dato, out dniParseado))
                    {
                        dni = ValidarDni(nacionalidad, dniParseado);
                    }
                    else
                    {
                        throw new DniInvalidoException();
                    }
                    break;
            }
            return dni;
        }

        /// <summary>
        /// Valida el nombre
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            regex = new Regex("[a-zA-Z]{2,20}");
            string nombre = string.Empty;
            if (!string.IsNullOrEmpty(dato) && regex.IsMatch(dato))
            {
                nombre = dato;
            }
            return nombre;
        }
        #endregion
    }
}
