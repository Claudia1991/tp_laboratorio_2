using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ventas.Data;
using Ventas.Modelos.DataModels;

namespace Ventas.DAO
{
    public class VentasDao :BaseDao, IDao<VentaDataModel>
    {
        public bool CreateElement(VentaDataModel element)
        {
            bool seCreoElemento = false;

            try
            {
                string sqlQuery = "insert into ventas values (@monto_total, @fecha_venta)";
                sqlConnection = Connection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("monto_total", element.MontoTotal);
                sqlCommand.Parameters.AddWithValue("fecha_venta", element.Fecha);
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    sqlQuery = "insert into ventas_detalle values (@id_venta, @id_producto, @cantidad_productos, @monto_por_producto)";
                    foreach (ProductoDetalleDataModel productoDetalle in element.DetalleVenta.Productos)
                    {
                        sqlCommand.CommandText = sqlQuery;
                        sqlCommand.Parameters.AddWithValue("id_venta", element.Id);
                        sqlCommand.Parameters.AddWithValue("id_producto", productoDetalle.Id);
                        sqlCommand.Parameters.AddWithValue("cantidad_productos", productoDetalle.CantidadPorProducto);
                        sqlCommand.Parameters.AddWithValue("monto_por_producto", productoDetalle.PrecioTotalPorProducto);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                seCreoElemento = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return seCreoElemento;
        }

        public bool DeleteElementById(int id)
        {
            bool seEliminoElemento = false;

            try
            {
                string sqlQueryDetalleVenta = "delete from ventas_detalle where @id_venta";
                string sqlQueryVenta = "delete from ventas where @id_venta";
                sqlConnection = Connection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sqlQueryDetalleVenta, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id_venta", id);
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    sqlCommand.CommandText = sqlQueryVenta;
                    sqlCommand.Parameters.AddWithValue("id_venta", id);
                    sqlCommand.ExecuteNonQuery();
                }
                seEliminoElemento = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return seEliminoElemento;
        }

        public List<VentaDataModel> GetAllElements()
        {
            List<VentaDataModel> ventas = new List<VentaDataModel>();
            int idVenta;
            int idProducto;
            try
            {
                string sqlQueryVentas = "select v.id_venta,p.id_producto, p.descripcion,vd.cantidad_productos,p.precio,vd.monto_por_producto ,v.monto_total, v.fecha_venta " +
                    "from ventas v " +
                    "inner join ventas_detalle vd on v.id_venta = vd.id_venta " +
                    "inner join producto p on p.id_producto = vd.id_producto " +
                    "order by v.id_venta ";
                sqlConnection = Connection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sqlQueryVentas, sqlConnection);

                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    ventas.Add(new VentaDataModel());
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
            return ventas;
        }

        public VentaDataModel GetElementById(int id)
        {
            VentaDataModel venta = new VentaDataModel();
            List<ProductoDetalleDataModel> productoDetalles = new List<ProductoDetalleDataModel>();
            try
            {
                string sqlQueryVentas = "select * from ventas where id_venta = @id_venta";
                string sqlQueryVentasDetalle = "select * from ventas_detalle where id_venta = @id_venta";
                sqlConnection = Connection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sqlQueryVentas, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id_venta", id);

                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader != null)
                {
                    sqlCommand.CommandText = sqlQueryVentasDetalle;
                    sqlCommand.Parameters.AddWithValue("id_venta", id);

                    SqlDataReader sqlDataReaderVentaDetalle = sqlCommand.ExecuteReader();
                    while (sqlDataReaderVentaDetalle.Read())
                    {
                        productoDetalles.Add(
                            new ProductoDetalleDataModel(Convert.ToInt32(sqlDataReaderVentaDetalle[0]),
                                                        Convert.ToString(sqlDataReaderVentaDetalle[1]),
                                                        sqlDataReaderVentaDetalle.GetDouble(2),
                                                        Convert.ToInt32(sqlDataReaderVentaDetalle[3]),
                                                        sqlDataReaderVentaDetalle.GetDouble(4)));
                    }
                    venta = new VentaDataModel(Convert.ToInt32(sqlDataReader[0]),
                                                Convert.ToDateTime(sqlDataReader[1]),
                                                sqlDataReader.GetDouble(2),
                                                new VentaDetalleDataModel()
                                                {
                                                    Productos = productoDetalles
                                                });
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
            return venta;
        }

        public bool UpdateElement(VentaDataModel element)
        {
            throw new NotImplementedException();
        }
    }
}
