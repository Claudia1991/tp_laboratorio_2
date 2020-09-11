using System;
using System.Text.RegularExpressions;
using TP_01.Entidades.Helpers;

namespace TP_01.Entidades.Entidades
{
    public class Numero
    {
        #region Campos
        private double numero;
        #endregion

        #region Propiedades
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Constructores
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Convierte un numero binario a decimal.
        /// </summary>
        /// <param name="binario">El numero binario a convertir.</param>
        /// <returns>Devuelve el numero decimal en caso ok sino un mensaje de error.</returns>
        public string BinarioDecimal(string binario)
        {
            return EsBinario(binario) ? Convert.ToInt32(binario, 2).ToString() : MensajesHelper.ErrorConversionBinarioDecimal();
        }

        /// <summary>
        /// Convierte a numero binario la parte entera de un numero flotante.
        /// </summary>
        /// <param name="numero">El numero a convertir.</param>
        /// <returns>El numero binario.</returns>
        public string DecimalBinario(double numero)
        {
            int valorAbsoluto = (int)Math.Abs(numero);
            return Convert.ToString(valorAbsoluto,2);
        }

        /// <summary>
        /// Convierte a numero binario un string.
        /// </summary>
        /// <param name="strNumero">El numero a convertir.</param>
        /// <returns>El numero binario.</returns>
        public string DecimalBinario(string strNumero)
        {
            double numero;
            double.TryParse(strNumero, out numero);
            return  DecimalBinario(numero);
        }
        #endregion

        #region Metodos Privados
        /// <summary>
        /// Verifica si un string contiene solo ceros y unos.
        /// </summary>
        /// <param name="numero">El numero a verificar.</param>
        /// <returns>Devuelve true si es un string binario, caso contrario false.</returns>
        private bool EsBinario(string numero)
        {
            Regex regex = new Regex("[0-1]");
            return regex.IsMatch(numero) && !numero.Contains(",");
        }

        /// <summary>
        /// Valida si un string se puede parsear a double.
        /// </summary>
        /// <param name="strNumero">El string a parsear.</param>
        /// <returns>Devuelve cero en caso de error, sino el numero parseado.</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;
            bool esNumeroValido;
            esNumeroValido = double.TryParse(strNumero,out numero);
            if (!esNumeroValido)
            {
                numero = 0;
            }
            return numero;
        }
        #endregion

        #region Sobrecarga de Operadores
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero - numeroDos.numero;
        }

        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero * numeroDos.numero;
        }

        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            return numeroDos.numero == 0 ? double.MinValue : numeroUno.numero / numeroDos.numero;
        }

        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero + numeroDos.numero;
        }
        #endregion
    }
}
