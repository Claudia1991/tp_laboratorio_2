namespace TP_01.Entidades.Entidades
{
    public static class Calculadora
    {
        #region Metodos Estaticos Publicos
        /// <summary>
        /// Realiza la operacion entre dos numeros.
        /// </summary>
        /// <param name="numeroUno">El primer operando.</param>
        /// <param name="numeroDos">El segundo operando.</param>
        /// <param name="operador">El operador a ejecutar.</param>
        /// <returns>Devuelve el resultado de la operacion.</returns>
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
        /// <summary>
        /// Verifica que el operador ingresado sea un operador valido.
        /// </summary>
        /// <param name="operador">El operador a validar</param>
        /// <returns>Devuelve el operador de suma en caso de error, o el operador en si.</returns>
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
