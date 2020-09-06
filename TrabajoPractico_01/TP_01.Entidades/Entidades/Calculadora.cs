namespace TP_01.Entidades.Entidades
{
    public static class Calculadora
    {
        #region Metodos Estaticos Publicos
        public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            double resultado = double.MinValue;
            char charOperador;
            string strOperador;
            if (char.TryParse(operador, out charOperador))
            {
                strOperador = ValidarOperador(charOperador);
                switch (strOperador)
                {
                    case "+":
                        resultado = numeroUno + numeroDos;
                        break;
                    case "-":
                        resultado = numeroUno - numeroDos;
                        break;
                    case "*":
                        resultado = numeroUno * numeroDos;
                        break;
                    case "/":
                        resultado = numeroUno / numeroDos;
                        break;
                }
            }            
            return resultado;
        }
        #endregion

        #region Metodos Privados Estaticos
        private static string ValidarOperador(char operador)
        {
            string operadorActual = string.Empty;
            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                operadorActual = "+";

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
