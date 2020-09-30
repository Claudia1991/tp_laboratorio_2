using System;
using System.Text;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region Constructor
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Metodos sobreescritos
        public override string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("SUV");
            stringBuilder.AppendLine(base.Mostrar());
            stringBuilder.AppendLine(string.Format("TAMAÑO : {0}", this.Tamanio));
            stringBuilder.AppendLine("---------------------");
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }
        #endregion
    }
}
