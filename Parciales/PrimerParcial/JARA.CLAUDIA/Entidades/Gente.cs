using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gente : Persona
    {
        public Gente(short edad) : base("No tengo nombre por que soy gentuza", edad)
        {

        }

        public override bool Validar()
        {
            return this.Edad > 18;
        }

        public override string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Holis, soy gentuza!!");
            stringBuilder.Append(base.Mostrar());
            return stringBuilder.ToString();
        }
    }
}
