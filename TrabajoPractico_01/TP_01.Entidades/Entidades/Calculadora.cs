using TP_01.Entidades.Enumerados;

namespace TP_01.Entidades.Entidades
{
    public static class Calculadora
    {
        #region Metodos Estaticos Publicos
        public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            return 0;
        }
        #endregion

        #region Metodos Privados Estaticos
        private static string ValidarOperador(char operador)
        {
            string operadorActual = string.Empty;
            if (operador != (char)EnumOperadores.OperadorSuma || operador != (char)EnumOperadores.OperadorResta
                || operador != (char)EnumOperadores.OperadorMultiplicacion 
                || operador != (char)EnumOperadores.OperadorDivision)
            {
                operadorActual = EnumOperadores.OperadorSuma.ToString();

            }
            else
            {
                operadorActual = operador.ToString();
            }
            return operadorActual;
        }
        #endregion
    }
}
