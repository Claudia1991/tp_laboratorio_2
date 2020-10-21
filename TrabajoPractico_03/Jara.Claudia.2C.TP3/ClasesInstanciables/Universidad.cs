using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Enumerado
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Campos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get;
            set;
        }

        public List<Profesor> Instructores
        {
            get;
            set;
        }

        public List<Jornada> Jornadas
        {
            get;
            set;
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Constructor
        public Universidad()
        {

        }
        #endregion

        #region Metodos
        public static bool  Guardar(Universidad universidad)
        {
            return true;
        }

        public Universidad Leer()
        {
            return new Universidad();
        }

        private string MostrarDatos(Universidad universidad)
        {
            return string.Empty;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return true;
        }

        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return true;
        }

        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            return new Profesor();
        }

        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            return new Universidad();
        }

        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            return new Universidad();
        }

        public static Universidad operator +(Universidad universidad, EClases clase)
        {
            return new Universidad();
        }

        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            return true;
        }

        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            return true;
        }

        public static Profesor operator ==(Universidad universidad, EClases clase)
        {
            return new Profesor();
        }
        #endregion
    }
}
