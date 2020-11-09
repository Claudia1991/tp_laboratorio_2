using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ventas.Data;
using Ventas.Modelos.DataModels;

namespace Ventas.DAO
{
    public class ProductoDao : BaseDao, IDao<ProductoDataModel>
    {
        public ProductoDao()
        {
            sqlConnection = Connection.GetConnection();
        }

        public bool CreateElement(ProductoDataModel element)
        {
            bool seCreoElement = false;
            try
            {
                string sqlQuery = "insert into productos values (@descripcion, @precio)";
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("descripcion", element.Descripcion);
                    sqlCommand.Parameters.AddWithValue("precio", element.Precio);
                    sqlConnection.Open();
                    seCreoElement =  sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return seCreoElement;
        }

        public bool DeleteElementById(int id)
        {
            bool seElimino = false;
            try
            {
                string sqlQuery = "delete from productos where id = @id";
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("id", id);
                    
                    sqlConnection.Open();
                    seElimino = sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return seElimino;
        }

        public List<ProductoDataModel> GetAllElements()
        {
            List<ProductoDataModel> productos = null;
            try
            {
                string sqlQuery = "select * from productos";
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        productos.Add(new ProductoDataModel(Convert.ToInt32(sqlDataReader[0]), Convert.ToString(sqlDataReader[1]), sqlDataReader.GetFloat(2)));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return productos;
        }

        public ProductoDataModel GetElementById(int id)
        {
            ProductoDataModel producto =  null;
            try
            {
                string sqlQuery = "select * from productos where id = @id";
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("id", id);

                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader != null)
                    {
                        producto = new ProductoDataModel(Convert.ToInt32(sqlDataReader[0]), Convert.ToString(sqlDataReader[1]), sqlDataReader.GetDouble(2));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return producto;
        }

        public bool UpdateElement(ProductoDataModel element)
        {
            bool seActualizo = false;
            try
            {
                string sqlQuery = "update productos set descripcion = @descripcion," +
                                  "precio = @precion where id = @id";
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("id", element.Id);
                    sqlCommand.Parameters.AddWithValue("descripcion", element.Descripcion);
                    sqlCommand.Parameters.AddWithValue("precio", element.Precio);

                    sqlConnection.Open();
                    seActualizo = sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return seActualizo;
        }
    }
}
