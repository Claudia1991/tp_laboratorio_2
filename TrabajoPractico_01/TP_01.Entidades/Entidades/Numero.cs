using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TP_01.Entidades.Entidades
{
    public class Numero
    {
        #region Campos
        private double numero;
        #endregion

        #region Propiedades
        public double SetNumero(string strNumero)
        {
            double numero;
            if (EsBinario(strNumero))
            {
                numero = Convert.ToDouble(BinarioDecimal(strNumero));
            }
            else
            {
                numero = ValidarNumero(strNumero);
            }
            return numero;
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
            this.numero = SetNumero(strNumero);
        }
        #endregion

        #region Metodos Publicos
        public string BinarioDecimal(string binario)
        {
            return Convert.ToInt32(binario, 2).ToString();
        }

        public string DecimalBinario(double numero)
        {
            int valorAbsoluto = (int)Math.Abs(numero);
            return Convert.ToString(valorAbsoluto,2);
        }

        public string DecimalBinario(string strNumero)
        {
            double numero;
            double.TryParse(strNumero, out numero);
            return  DecimalBinario(numero);

        }
        #endregion

        #region Metodos Privados
        private bool EsBinario(string numero)
        {
            Regex regex = new Regex("{0-1}");
            return regex.IsMatch(numero);
        }

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

        #region Operadores
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            return 0;
        }

        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            return 0;
        }

        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            return 0;
        }

        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            return 0;
        }
        #endregion
    }
}
