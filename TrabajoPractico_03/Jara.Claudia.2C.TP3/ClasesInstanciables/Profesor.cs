using System;
using System.Collections.Generic;
using static ClasesInstanciables.Universidad;
using EntidadesAbstractas;
using System.Text;
using System.Linq;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Campos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructor
        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {  
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos 
        protected override string ParticipaEnClase()
        {
            return $"CLASES DEL DIA: {this.clasesDelDia.Select(x => x.ToString())}";
        }

        private void _randomClases()
        {
            for(int i = 0; i<2; i++)
            {
                int clase = random.Next(0, 3);
                this.clasesDelDia.Enqueue((EClases)clase);
            }
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        public override string ToString()
        {
            return string.Concat(this.MostrarDatos(), this.ParticipaEnClase());
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator !=(Profesor profesor, EClases clase)
        {
            return !(profesor == clase);
        }

        public static bool operator ==(Profesor profesor, EClases clase)
        {
            return profesor.clasesDelDia.Contains(clase);
        }
        #endregion
    }
}
