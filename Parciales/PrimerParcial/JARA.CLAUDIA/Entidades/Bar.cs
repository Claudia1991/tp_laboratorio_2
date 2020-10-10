using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Bar
    {
        #region Campos
        private List<Empleado> empleados;
        private List<Gente> gente;
        private static Bar singleton;
        #endregion

        #region Propiedades
        public List<Empleado> Empleados
        {
            get
            {
                return this.empleados;
            }
        }

        public List<Gente> Gente
        {
            get
            {
                return this.gente;
            }
        }
        #endregion

        #region Constructores
        private Bar()
        {
            this.empleados = new List<Empleado>();
            this.gente = new List<Gente>();
        }

        public static Bar GetBar()
        {
            if (singleton == null)
            {
                singleton = new Bar();
            }
            return singleton;
        }
        #endregion

        #region Sobrecargas
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Muestro las personas en el bar.");
            stringBuilder.AppendLine("----------[EMPLEADOS]----------");
            foreach (Empleado empleado in empleados)
            {
                if (empleado.Dni != -1)
                {
                    stringBuilder.AppendLine(empleado.Mostrar());

                }
            }
            stringBuilder.AppendLine("----------[EMPLEADOS]----------");

            stringBuilder.AppendLine("----------[GENTE]----------");

            foreach (Gente gente in gente)
            {
                stringBuilder.AppendLine(gente.Mostrar());
            }
            stringBuilder.AppendLine("----------[GENTE]----------");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Agrega empleados al bar.
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="empleado"></param>
        /// <returns>Devuelve true si pudo agregar, false caso contrario.</returns>
        public static bool operator +(Bar bar, Empleado empleado)
        {
            //Verifico que no haya un empleado igual, sino lo agrego
            bool sePudoAgregar = false;
            if (!bar.Empleados.Any(e => e == empleado) && empleado.Validar())
            {
                bar.empleados.Add(empleado);
                sePudoAgregar = true;
            }
            return sePudoAgregar;
        }

        /// <summary>
        /// Agrega gente al bar si hay los empleados disponibles.
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="gente"></param>
        /// <returns>Devuelve true si pudo agregar, false caso contrario.</returns>
        public static bool operator +(Bar bar, Gente gente)
        {
            bool sePudoAgregar = false;
            if (SePuedeAgregarGente(bar.Empleados.Count,bar.Gente.Count) && gente.Validar())
            {
                bar.gente.Add(gente);
                sePudoAgregar = true;
            }
            return sePudoAgregar;
        }

        public bool BorrarPersonasDelBar(Bar bar, Type tipo)
        {
            bool sePudoBorrar = false;
            int indiceAEliminar = tipo == typeof(Empleado) ? bar.Empleados.Count - 1 : 0;

            if ( tipo == typeof(Empleado) && bar.Empleados.Count >0)
            {
                bar.empleados.RemoveAt(indiceAEliminar);
                sePudoBorrar = true;
            }else if (tipo == typeof(Gente) && bar.Gente.Count > 0)
            {
                bar.gente.RemoveAt(indiceAEliminar);
                sePudoBorrar = true;
            }

            return sePudoBorrar;
        }

        /// <summary>
        /// Verifica si se puede agregar mas clientes segun la cantidad de empleados del bar
        /// </summary>
        /// <param name="cantidadEmpleados"></param>
        /// <param name="cantidadActualGente"></param>
        /// <returns>Devuelve true si se puede agregar, false en otro caso.</returns>
        private static bool SePuedeAgregarGente(int cantidadEmpleados, int cantidadActualGente)
        {
            return cantidadEmpleados * 10 > cantidadActualGente;
        }
        #endregion
    }
}
