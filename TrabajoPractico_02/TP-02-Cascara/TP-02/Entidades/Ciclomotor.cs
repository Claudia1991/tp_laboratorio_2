using System;
using System.Text;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected sealed override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Metodos Sobreescritos
        public sealed override string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("CICLOMOTOR");
            stringBuilder.AppendLine(base.Mostrar());
            stringBuilder.AppendLine(string.Format("TAMAÑO : {0}", this.Tamanio));
            stringBuilder.AppendLine("---------------------");
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }
        #endregion
    }
}
