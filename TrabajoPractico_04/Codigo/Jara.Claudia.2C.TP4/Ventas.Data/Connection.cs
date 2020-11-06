using System.Configuration;
using System.Data.SqlClient;

namespace Ventas.Data
{
    public static class Connection
    {
        private static SqlConnection sqlConnection;

        public static SqlConnection GetConnection()
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SistemaVentasDB"].ConnectionString);
            }
            return sqlConnection;
        }
    }
}
