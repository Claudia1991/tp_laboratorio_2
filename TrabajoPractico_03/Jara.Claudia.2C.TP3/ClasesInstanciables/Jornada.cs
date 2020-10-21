using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
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
            get;
            set;
        }

        public EClases Clases
        {
            get;
            set;
        }

        public Profesor Instructor
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        private Jornada()
        {

        }

        public Jornada(EClases clase, Profesor instructor)
        {

        }
        #endregion

        #region Metodos
        public static bool Guardar(Jornada jornada)
        {
            return true;
        }

        public string Leer()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return true;
        }

        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            return true;
        }

        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            return new Jornada();
        }
        #endregion
    }
}
