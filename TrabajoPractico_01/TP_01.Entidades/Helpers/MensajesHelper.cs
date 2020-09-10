namespace TP_01.Entidades.Helpers
{
    public static class MensajesHelper
    {
        #region Metodos Estatico Publicos
        /// <summary>
        /// Devuelve mensaje de error de operacion.
        /// </summary>
        /// <returns>Devuelve el mensaje de error.</returns>
        public static string ErrorOperacion()
        {
            return "No se puede realizar la operacion solicitada.";
        }

        /// <summary>
        /// Devuelve mensaje de operacion exitosa.
        /// </summary>
        /// <returns>Devuelve mensaje de operacion exitosa.</returns>
        public static string OperacionExitosa()
        {
            return "Operación realizada con éxito.";
        }

        /// <summary>
        /// Devuelve mensaje de error de conversion de binario a decimal.
        /// </summary>
        /// <returns>Devuelve mensaje de error de conversion de binario a decimal.</returns>
        public static string ErrorConversionBinarioDecimal()
        {
            return "No se puede convertir a decimal.";
        }

        /// <summary>
        /// Devuelve mensaje de division por cero.
        /// </summary>
        /// <returns>Devuelve mensaje de division por cero.</returns>
        public static string ErrorDivisionPorCero()
        {
            return "Esta tratando de dividir por cero.";
        }
        #endregion
    }
}
