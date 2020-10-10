using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Bar
    {
        private List<Empleado> empleados;
        private List<Gente> gente;
        private static Bar singleton;

        public List<Empleado> Empleados { get { return this.empleados; } }
        public List<Gente> Gente { get { return this.gente; } }

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

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Muestro las personas en el bar.");
            foreach (Empleado empleado in empleados)
            {
                stringBuilder.AppendLine(empleado.Mostrar());
            }

            foreach (Gente gente in gente)
            {
                stringBuilder.AppendLine(gente.Mostrar());
            }
            return stringBuilder.ToString();
        }

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

        public static bool operator -(Bar bar, Empleado empleado)
        {
            bool sePudoBorrar = false;
            if (bar.Gente.Count > 0)
            {
                bar.empleados.RemoveAt(bar.Empleados.Count - 1);

                sePudoBorrar = true;
            }
            return sePudoBorrar;
        }
        public static bool operator -(Bar bar, Gente gente)
        {
            bool sePudoBorrar = false;
            if (bar.Gente.Count > 0)
            {
                bar.gente.RemoveAt(0);
                sePudoBorrar = true;
            }
            return sePudoBorrar;
        }

        private static bool SePuedeAgregarGente(int cantidadEmpleados, int cantidadActualGente)
        {
            //falta la validacion de verda, jeje
            //por cada empleado, 10 gente
            //bool sePuedeAgregarGente = false;
            //cantidadEmpleados * 10 <=can

            return cantidadEmpleados * 10 >= cantidadActualGente;
        }
    }
}
