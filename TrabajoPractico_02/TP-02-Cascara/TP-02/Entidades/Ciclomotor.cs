using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color): base(marca, chasis, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las motos son chicas
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Metodos Sobreescritos
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(string.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("---------------------");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
