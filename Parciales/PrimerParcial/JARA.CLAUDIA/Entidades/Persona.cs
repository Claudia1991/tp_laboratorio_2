using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        private short edad;
        private string nombre;

        public short Edad
        {
            get
            {
                return this.edad;
            }
            set
            {
                this.edad = value;
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
                this.nombre = value;

            }
        }

        protected Persona(string nombre, short edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        public static explicit operator string(Persona persona)
        {
            return persona.Mostrar();
        }

        public virtual string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Nombre: {0}", this.Nombre);
            stringBuilder.AppendFormat("Edad: {0}", this.Edad);
            return stringBuilder.ToString();
        }

        public abstract bool Validar();

    }
}
