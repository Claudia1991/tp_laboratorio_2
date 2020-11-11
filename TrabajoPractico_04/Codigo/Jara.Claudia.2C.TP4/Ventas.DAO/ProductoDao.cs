using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ventas.Data;
using Ventas.Modelos.DataModels;

namespace Ventas.DAO
{
    public class ProductoDao : BaseDao, IDao<ProductoDataModel>
    {
        public bool CreateElement(ProductoDataModel element)
        {
            bool seCreoElement = false;
            try
            {
                string sqlQuery = "insert into producto values (@descripcion, @precio)";
                sqlConnection = Connection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("descripcion", element.Descripcion);
                sqlCommand.Parameters.AddWithValue("precio", element.Precio);
                sqlConnection.Open();
                seCreoElement =  sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return seCreoElement;
        }

        public bool DeleteElementById(int id)
        {
            bool seElimino = false;
            try
            {
                string sqlQuery = "delete from producto where id = @id";
                sqlConnection = Connection.GetConnection();
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("id", id);
                    
                    sqlConnection.Open();
                    seElimino = sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return seElimino;
        }

        public List<ProductoDataModel> GetAllElements()
        {
            List<ProductoDataModel> productos = new List<ProductoDataModel>();
            try
            {
                string sqlQuery = "select * from producto";
                sqlConnection = Connection.GetConnection();
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        productos.Add(new ProductoDataModel(Convert.ToInt32(sqlDataReader[0]), Convert.ToString(sqlDataReader[1]), Convert.ToDouble(sqlDataReader[2])));
                    }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return productos;
        }

        public ProductoDataModel GetElementById(int id)
        {
            ProductoDataModel producto =  null;
            try
            {
                string sqlQuery = "select * from productos where id = @id";
                sqlConnection = Connection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", id);

                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader != null)
                {
                    producto = new ProductoDataModel(Convert.ToInt32(sqlDataReader[0]), Convert.ToString(sqlDataReader[1]), sqlDataReader.GetDouble(2));
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return producto;
        }

        public bool UpdateElement(ProductoDataModel element)
        {
            bool seActualizo = false;
            try
            {
                string sqlQuery = "update producto set descripcion = @descripcion," +
                                  "precio = @precion where id = @id";
                sqlConnection = Connection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", element.Id);
                sqlCommand.Parameters.AddWithValue("descripcion", element.Descripcion);
                sqlCommand.Parameters.AddWithValue("precio", element.Precio);

                sqlConnection.Open();
                seActualizo = sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return seActualizo;
        }
    }
}
