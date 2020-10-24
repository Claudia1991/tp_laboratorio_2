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
        public static bool Guardar(Jornada jornada)
        {
            return true;
        }

        public static string Leer()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Clase: {0} - Profesor: {1}", this.Clases, this.Instructor);
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("Alumnos: {0}", this.Alumnos.Select(a => a.Nombre));

            return stringBuilder.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada==alumno);
        }

        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            /* Logica: Una Jornada será igual a un Alumno si el mismo participa de la clase.*/
            return alumno == jornada.Clases;
        }

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
