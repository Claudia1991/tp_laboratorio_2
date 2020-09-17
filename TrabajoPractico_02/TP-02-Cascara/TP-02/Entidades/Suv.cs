using System;
using System.Text;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region Constructor
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(marca,chasis, color)
        {
        }
        #endregion

        #region Campos
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Metodos sobreescritos
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(string.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("---------------------");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
