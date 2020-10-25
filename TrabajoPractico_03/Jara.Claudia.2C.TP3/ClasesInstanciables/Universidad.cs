using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    [Serializable]
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
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
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
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion

        #region Metodos
        public static bool  Guardar(Universidad universidad)
        {
            /*Logica: Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de susp rofesores, Alumnos y Jornadas.*/
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Guardar("Universidad.xml", universidad);
            return true;
        }

        public static Universidad Leer()
        {
            /*Logica: Leer de clase retornará un Universidad con todos los datos previamente serializados.*/
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad universidad;
            xml.Leer("Universidad.xml", out universidad);
            return universidad;
        }

        private static string MostrarDatos(Universidad universidad)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("========== JORNADAS ==========");
            foreach (Jornada jornada in universidad.Jornadas)
            {
                stringBuilder.AppendLine(jornada.ToString());
            }
            stringBuilder.AppendLine("========== JORNADAS ==========");

            stringBuilder.AppendLine("========== ALUMNOS ==========");
            foreach (Alumno alumno in universidad.Alumnos)
            {
                stringBuilder.AppendLine(alumno.ToString());

            }
            stringBuilder.AppendLine("========== ALUMNOS ==========");

            stringBuilder.AppendLine("========== PROFESORES ==========");
            foreach (Profesor profesor in universidad.Instructores)
            {
                stringBuilder.AppendLine(profesor.ToString());

            }
            stringBuilder.AppendLine("========== PROFESORES ==========");
            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return !(universidad == alumno);
        }

        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return !(universidad == profesor);
        }

        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            Profesor profesor = universidad.Instructores.FirstOrDefault(p => p != clase);
            return profesor;
        }

        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            /*Logica: Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente
            cargados.
            Si al querer agregar alumnos este ya figura en la lista, lanzar la excepción AlumnoRepetidoException.*/
            if (universidad == alumno)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                universidad.alumnos.Add(alumno);
            }
            return universidad;
        }

        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            /*Logica: Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente
            cargados.*/
            if (universidad != profesor)
            {
                universidad.profesores.Add(profesor);
            }
            return universidad;
        }

        public static Universidad operator +(Universidad universidad, EClases clase)
        {
            /*Logica: Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
            clase, un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la
            toman (todos los que coincidan en su campo ClaseQueToma).*/
            Profesor profesor = universidad == clase;
            Jornada jornada = new Jornada(clase, profesor);
            jornada.Alumnos = universidad.Alumnos.Where(a => a == clase).Select(a => a).ToList();
            universidad.jornada.Add(jornada);
            return universidad;
        }

        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            /* Logica: Un Universidad será igual a un Alumno si el mismo está inscripto en él.*/
            bool existeAlumno = false;
            if (universidad.Alumnos.Count >0)
            {
                universidad.Alumnos.Any(a => a == alumno);
            }
            return existeAlumno;
        }

        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            /*Logica: Un Universidad será igual a un Profesor si el mismo está dando clases en él.*/
            bool existeProfesor = false;
            if (universidad.Instructores.Count >0)
            {
                universidad.Instructores.Any(p => p == profesor);
            }
            return existeProfesor;
        }

        public static Profesor operator ==(Universidad universidad, EClases clase)
        {
            /* Logica: La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
                Sino, lanzará la Excepción SinProfesorException. El distinto retornará el primer Profesor que no
                pueda dar la clase.*/
            Profesor profesor = universidad.Instructores.FirstOrDefault(p => p == clase);
            if (object.ReferenceEquals(profesor, null))
            {
                throw new SinProfesorException();
            }
            return profesor;
        }
        #endregion
    }
}
