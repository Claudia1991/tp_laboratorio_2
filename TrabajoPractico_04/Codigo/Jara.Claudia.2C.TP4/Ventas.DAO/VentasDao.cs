﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ventas.Data;
using Ventas.Modelos.DataModels;

namespace Ventas.DAO
{
    public class VentasDao :BaseDao, IDao<VentaDataModel>
    {
        #region Metodos CRUD
        /// <summary>
        /// Crea el elemento en la base
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool CreateElement(VentaDataModel element)
        {
            bool seCreoElemento = false;

            try
            {
                string sqlQueryInsertVenta = "insert into ventas values (@monto_total, @fecha_venta)";
                sqlConnection = Connection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sqlQueryInsertVenta, sqlConnection);
                sqlCommand.Parameters.AddWithValue("monto_total", element.MontoTotal);
                sqlCommand.Parameters.AddWithValue("fecha_venta", element.Fecha);
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    string sqlQuerySelectIdVenta = "select max(id_venta) from ventas";
                    SqlCommand sqlCommand1 = new SqlCommand(sqlQuerySelectIdVenta, sqlConnection);
                    int idVenta = (int)sqlCommand1.ExecuteScalar();

                    string sqlQueryInsertDetalle = "insert into ventas_detalle values (@id_venta, @id_producto, @cantidad_productos, @monto_por_producto)";
                    foreach (ProductoDetalleDataModel productoDetalle in element.DetalleVenta.Productos)
                    {
                        sqlCommand = new SqlCommand(sqlQueryInsertDetalle, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("id_venta", idVenta);
                        sqlCommand.Parameters.AddWithValue("id_producto", productoDetalle.Id);
                        sqlCommand.Parameters.AddWithValue("cantidad_productos", productoDetalle.CantidadPorProducto);
                        sqlCommand.Parameters.AddWithValue("monto_por_producto", productoDetalle.PrecioTotalPorProducto);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                seCreoElemento = true;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return seCreoElemento;
        }

        /// <summary>
        /// Elimina un elemento segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteElementById(int id)
        {
            bool seEliminoElemento = false;

            try
            {
                string sqlQueryDetalleVenta = "delete from ventas_detalle where id_venta = @id_venta";
                string sqlQueryVenta = "delete from ventas where id_venta =  @id_venta";
                sqlConnection = Connection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sqlQueryDetalleVenta, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id_venta", id);
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    sqlCommand.CommandText = sqlQueryVenta;
                    sqlCommand.ExecuteNonQuery();
                }
                seEliminoElemento = true;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return seEliminoElemento;
        }

        /// <summary>
        /// Obtiene todos los elementos
        /// </summary>
        /// <returns></returns>
        public List<VentaDataModel> GetAllElements()
        {
            List<VentaDataModel> ventas = new List<VentaDataModel>();
            bool esPrimerRegistro = true;
            bool noEsMismaVenta = false;
            int idVentaSiguiente;
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
                    if (ventas.Count > 0)
                    {
                        idVentaSiguiente = Convert.ToInt32(sqlDataReader["id_venta"]);
                        noEsMismaVenta = ventas[ventas.Count - 1].Id != idVentaSiguiente;
                    }
                    if (noEsMismaVenta || esPrimerRegistro)
                    {
                        esPrimerRegistro = false;
                        VentaDataModel venta = new VentaDataModel(Convert.ToInt32(sqlDataReader["id_venta"]), Convert.ToDateTime(sqlDataReader["fecha_venta"]), sqlDataReader.GetDouble(6),
                        new VentaDetalleDataModel()
                        {
                            Productos =
                            new List<ProductoDetalleDataModel>()
                            {
                                new ProductoDetalleDataModel(sqlDataReader.GetInt32(1),sqlDataReader.GetString(2),sqlDataReader.GetDouble(4),sqlDataReader.GetInt32(3),sqlDataReader.GetDouble(5))
                            }
                        });
                        ventas.Add(venta);
                    }
                    else
                    {
                        ProductoDetalleDataModel productoDetalle = new ProductoDetalleDataModel(sqlDataReader.GetInt32(1), sqlDataReader.GetString(2), sqlDataReader.GetDouble(4),
                            sqlDataReader.GetInt32(3), sqlDataReader.GetDouble(5));

                        ventas[ventas.Count - 1].DetalleVenta.Productos.Add(productoDetalle);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return ventas;
        }

        /// <summary>
        /// Obtiene un elemento segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VentaDataModel GetElementById(int id)
        {
            VentaDataModel venta = null;
            try
            {
                string sqlQueryVenta = "select v.id_venta,p.id_producto, p.descripcion,vd.cantidad_productos,p.precio,vd.monto_por_producto ,v.monto_total, v.fecha_venta " +
                                        "from ventas v " +
                                        "inner join ventas_detalle vd on v.id_venta = vd.id_venta " +
                                        "inner join producto p on p.id_producto = vd.id_producto " +
                                        "where v.id_venta = @id_venta";
                sqlConnection = Connection.GetConnection();
                SqlCommand sqlCommand = new SqlCommand(sqlQueryVenta, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id_venta", id);

                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    venta = new VentaDataModel(Convert.ToInt32(sqlDataReader["id_venta"]), Convert.ToDateTime(sqlDataReader["fecha_venta"]), sqlDataReader.GetDouble(6),
                       new VentaDetalleDataModel()
                       {
                           Productos =
                           new List<ProductoDetalleDataModel>()
                           {
                                new ProductoDetalleDataModel(sqlDataReader.GetInt32(1),sqlDataReader.GetString(2),sqlDataReader.GetDouble(4),sqlDataReader.GetInt32(3),sqlDataReader.GetDouble(5))
                           }
                       });
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return venta;
        }

        /// <summary>
        /// Actualiza un elemento
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool UpdateElement(VentaDataModel element)
        {
            bool seActualizo = false;
            try
            {
                string sqlQueryVenta = "update ventas set fecha_venta = @fecha_venta where id_venta = @id_venta";
                sqlConnection = Connection.GetConnection();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQueryVenta, sqlConnection);
                sqlCommand.Parameters.AddWithValue("id_venta", element.Id);
                sqlCommand.Parameters.AddWithValue("fecha_venta", element.Fecha);
                seActualizo = sqlCommand.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return seActualizo;
        }

        /// <summary>
        /// Obtiene el id de la ultima venta generada
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            int idVenta;
            try
            {
                sqlConnection = Connection.GetConnection();
                sqlConnection.Open();
                string sqlQuerySelectIdVenta = "select max(id_venta) from ventas";
                SqlCommand sqlCommand1 = new SqlCommand(sqlQuerySelectIdVenta, sqlConnection);
                idVenta = (int)sqlCommand1.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return idVenta;
        } 
        #endregion
    }
}
