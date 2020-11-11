using System.Data.SqlClient;

namespace Ventas.DAO
{
    public abstract class BaseDao
    {
        protected SqlConnection sqlConnection;
    }
}
