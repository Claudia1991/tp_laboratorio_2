using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ventas.Data;
using Ventas.Modelos.DataModels;

namespace Ventas.DAO
{
    public class VentasDao :BaseDao, IDao<VentaDataModel>
    {
        public VentasDao()
        {
            sqlConnection = Connection.GetConnection();
        }
        public bool CreateElement(VentaDataModel element)
        {
            bool seCreoElemento = false;

            try
            {
                string sqlQuery = "insert into ventas values (@monto, @fecha)";
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("monto", element.MontoTotal);
                    sqlCommand.Parameters.AddWithValue("fecha", element.Fecha);
                    sqlConnection.Open();
                   if(sqlCommand.ExecuteNonQuery() > 0)
                   {
                        sqlQuery = "insert into ventas_detalle values (@idVenta, @idProducto, @cantidad, @precioPorProducto)";
                        foreach (ProductoDetalleDataModel productoDetalle in element.DetalleVenta.Productos)
                        {
                            sqlCommand.CommandText = sqlQuery;
                            sqlCommand.Parameters.AddWithValue("idVenta", element.Id);
                            sqlCommand.Parameters.AddWithValue("idProducto", productoDetalle.Id);
                            sqlCommand.Parameters.AddWithValue("cantidad", productoDetalle.CantidadPorProducto);
                            sqlCommand.Parameters.AddWithValue("precioPorProducto", productoDetalle.PrecioTotalPorProducto);
                            sqlCommand.ExecuteNonQuery();
                        }
                   }
                    seCreoElemento = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return seCreoElemento;
        }

        public bool DeleteElementById(int id)
        {
            bool seEliminoElemento = false;

            try
            {
                string sqlQueryDetalleVenta = "delete from ventas_detalle where @idVenta";
                string sqlQueryVenta = "delete from ventas where @idVenta";
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQueryDetalleVenta, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("idVenta", id);
                    sqlConnection.Open();
                    if (sqlCommand.ExecuteNonQuery() > 0)
                    {
                        sqlCommand.CommandText = sqlQueryVenta;
                        sqlCommand.Parameters.AddWithValue("idVenta", id);
                        sqlCommand.ExecuteNonQuery();
                    }
                    seEliminoElemento = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return seEliminoElemento;
        }

        public List<VentaDataModel> GetAllElements()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public VentaDataModel GetElementById(int id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateElement(VentaDataModel element)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
