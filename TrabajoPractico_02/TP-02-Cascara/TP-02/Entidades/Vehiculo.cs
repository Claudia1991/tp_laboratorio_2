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
        EMarca marca;
        string chasis;
        ConsoleColor color;
        #endregion

        #region Constructor
        public Vehiculo(EMarca marca, string chasis, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public virtual ETamanio Tamanio { get; }
        #endregion

        #region Metodo Publico
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
        /// <summary>
        /// Operador de casteo explicito a string de un vehiculo.
        /// </summary>
        /// <param name="vehiculo">El string del detalle de un vehiculo</param>
        public static explicit operator string(Vehiculo vehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("CHASIS: {0}\r", vehiculo.chasis));
            sb.AppendLine(string.Format("MARCA : {0}\r", vehiculo.marca.ToString()));
            sb.AppendLine(string.Format("COLOR : {0}\r", vehiculo.color.ToString()));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="vehiculoUno">El primer vehiculo a comparar</param>
        /// <param name="vehiculoDos">El segundo vehiculo a comparar</param>
        /// <returns>Devuelve true si son iguales, false caso contrario.</returns>
        public static bool operator ==(Vehiculo vehiculoUno, Vehiculo vehiculoDos)
        {
            return (vehiculoUno.chasis == vehiculoDos.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="vehiculoUno">El primer vehiculo a comparar</param>
        /// <param name="vehiculoDos">El segundo vehiculo a comparar</param>
        /// <returns>Devuelve true si no son iguales, false caso contrario.</returns>
        public static bool operator !=(Vehiculo vehiculoUno, Vehiculo vehiculoDos)
        {
            return !(vehiculoUno.chasis == vehiculoDos.chasis);
        }
        #endregion
    }
}
