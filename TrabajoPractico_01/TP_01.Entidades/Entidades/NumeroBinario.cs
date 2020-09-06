using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_01.Entidades.Entidades
{
    public static class NumeroBinario
    {
        #region Metodos Publicos Estaticos
        public static string Suma(double numeroUno, double numeroDos)
        {
            return Convert.ToString(Convert.ToInt32(numeroUno) + Convert.ToInt32(numeroDos), 2);
        }

        public static string Resta(double numeroUno, double numeroDos)
        {
            return Convert.ToString(Convert.ToInt32(numeroUno) - Convert.ToInt32(numeroDos), 2);
        }

        public static string Multiplicacion(double numeroUno, double numeroDos)
        {
            return Convert.ToString(Convert.ToInt32(numeroUno) * Convert.ToInt32(numeroDos), 2);
        }
        #endregion
    }
}
