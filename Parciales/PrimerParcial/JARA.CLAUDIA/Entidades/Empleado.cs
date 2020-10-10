using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : Persona
    {
        #region Campos
        private int dni;
        #endregion

        #region Propiedades
        public int Dni
        {
            get
            {
                return this.dni;
            }
        }
        #endregion

        #region Constructores
        public Empleado(string nombre, short edad) : base(nombre, edad)
        {
            this.dni = -1;
        }

        public Empleado(string nombre, short edad, int dni) : this (nombre, edad)
        {
            this.dni = dni;
        }
        #endregion


        #region Metodos
        /// <summary>
        /// Valida que el empleado sea mayor de 21 años y su nombre tengo por lo menos dos caracteres
        /// </summary>
        /// <returns>Devuelve true en caso de ser valido, false en cualquier otro caso</returns>
        public override bool Validar()
        {
            return this.Edad > 21 && this.Nombre.Length >= 2;
        }

        /// <summary>
        /// Muestra los datos de un empleado.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Holis, soy un empleado!!");
            stringBuilder.Append(base.Mostrar());
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Verifica si dos empleados son iguales o no.
        /// </summary>
        /// <param name="empleadoUno"></param>
        /// <param name="empleadoDos"></param>
        /// <returns></returns>
        public static bool operator ==(Empleado empleadoUno, Empleado empleadoDos)
        {
            return empleadoUno.Edad == empleadoDos.Edad && empleadoUno.Nombre == empleadoDos.Nombre;
        }

        /// <summary>
        /// Verifica si dos empleados son iguales o no.
        /// </summary>
        /// <param name="empleadoUno"></param>
        /// <param name="empleadoDos"></param>
        /// <returns></returns>
        public static bool operator !=(Empleado empleadoUno, Empleado empleadoDos)
        {
            return !(empleadoUno == empleadoDos);
        }
        #endregion
    }
}
