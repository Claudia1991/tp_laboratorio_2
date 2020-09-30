using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enumerados
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region Campos
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected virtual ETamanio Tamanio { get; }
        #endregion

        #region Constructor
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Operadores
        public static explicit operator string(Vehiculo vehiculo)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("CHASIS: {0}\r\n", vehiculo.chasis));
            stringBuilder.AppendLine(string.Format("MARCA : {0}\r\n", vehiculo.marca.ToString()));
            stringBuilder.AppendLine(string.Format("COLOR : {0}\r\n", vehiculo.color.ToString()));
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="vehiculoUno"></param>
        /// <param name="vehiculoDos"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo vehiculoUno, Vehiculo vehiculoDos)
        {
            return (vehiculoUno.chasis == vehiculoDos.chasis);
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="vehiculoUno"></param>
        /// <param name="vehiculoDos"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo vehiculoUno, Vehiculo vehiculoDos)
        {
            return !(vehiculoUno.chasis == vehiculoDos.chasis);
        }
        #endregion
    }
}
