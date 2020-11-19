using System.Configuration;
using System.Data.SqlClient;

namespace Ventas.Data
{
    public static class Connection
    {
        #region Campo
        private static SqlConnection sqlConnection;
        #endregion

        #region Metodos
        /// <summary>
        /// Obtiene la instancia de la conexion a la base de datos
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SistemaVentasDB"].ConnectionString);
            }
            return sqlConnection;
        } 
        #endregion
    }
}
