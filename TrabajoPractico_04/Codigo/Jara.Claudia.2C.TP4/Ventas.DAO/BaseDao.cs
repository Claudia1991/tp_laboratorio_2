using System.Data.SqlClient;

namespace Ventas.DAO
{
    public abstract class BaseDao
    {
        #region Campos
        protected SqlConnection sqlConnection; 
        #endregion
    }
}
