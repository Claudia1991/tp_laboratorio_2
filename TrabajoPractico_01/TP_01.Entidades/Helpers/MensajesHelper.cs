namespace TP_01.Entidades.Helpers
{
    public static class MensajesHelper
    {
        #region Metodos Estatico Publicos
        public static string ErrorOperacion()
        {
            return "No se puede realizar la operacion solicitada.";
        }

        public static string OperacionExitosa()
        {
            return "Operación realizada con éxito.";
        }

        public static string ErrorConversionBinarioDecimal()
        {
            return "No se puede convertir a decimal.";
        }
        #endregion
    }
}
