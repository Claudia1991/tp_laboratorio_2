using System;
using System.Text;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Enumerados
        public enum ETipo { Sedan, Monovolumen }
        #endregion

        #region Campos
        private ETipo tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca,  color)
        {
            tipo = ETipo.Monovolumen;
        }

        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected sealed override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Metodo sobrecargado
        public sealed override string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("SEDAN");
            stringBuilder.AppendLine(base.Mostrar());
            stringBuilder.AppendLine(string.Format("TAMAÑO : {0}", this.Tamanio));
            stringBuilder.AppendLine("TIPO : " + this.tipo);
            stringBuilder.AppendLine("---------------------");
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }
        #endregion
    }
}
