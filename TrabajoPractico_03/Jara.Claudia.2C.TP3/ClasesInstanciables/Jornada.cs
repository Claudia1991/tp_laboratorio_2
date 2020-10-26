using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    [Serializable]
    public class Jornada
    {
        #region Campos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public EClases Clases
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructor
        private Jornada()
        {
            this.alumnos = new List<Alumno>();

        }

        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda la jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            /*Logica: Guardar de clase guardará los datos de la Jornada en un archivo de texto.
            • Leer de clase retornará los datos de la Jornada como texto.*/
            bool sePudoGuardar = false;
            Texto texto = new Texto();
            sePudoGuardar = texto.Guardar("Jornada.txt", jornada.ToString());
            return sePudoGuardar;
        }

        /// <summary>
        /// Lee la jornada desde un archivo de texto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string datosJornada = string.Empty;
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out datosJornada);
            return datosJornada;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Clase: {0} - Profesor: {1} ", this.Clases, this.Instructor.ToString());
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("Alumnos: {0}", this.ObtenerNombreAlumnos());
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Obtiene los alumnos en la jornada
        /// </summary>
        /// <returns></returns>
        private string ObtenerNombreAlumnos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Alumno alumno in this.Alumnos)
            {
                stringBuilder.AppendLine(alumno.ToString());
            }
            return stringBuilder.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Verifica si el alumno no toma clase de la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada==alumno);
        }

        /// <summary>
        /// Verifica si el alumno toma clase de la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            /* Logica: Una Jornada será igual a un Alumno si el mismo participa de la clase.*/
            return alumno == jornada.Clases;
        }

        /// <summary>
        /// Agrega alumnos a la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            /* Logica: Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente
                cargados.*/
            if (jornada != alumno)
            {
                jornada.alumnos.Add(alumno);
            }
            return jornada;
        }
        #endregion
    }
}
