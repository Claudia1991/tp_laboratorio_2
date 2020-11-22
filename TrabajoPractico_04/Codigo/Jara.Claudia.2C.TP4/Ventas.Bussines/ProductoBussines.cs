using System;
using System.Collections.Generic;
using Ventas.DAO;
using Ventas.Modelos.DataModels;
using Ventas.Modelos.ViewModels;
using Ventas.Utilities;

namespace Ventas.Bussines
{
    public static class ProductoBussines
    {
        #region Campos
        private static ProductoDao productoDao;
        #endregion

        #region Constructor
        static ProductoBussines()
        {
            productoDao = new ProductoDao();
        }
        #endregion

        #region Metodos Estaticos
        /// <summary>
        /// Obtiene todos los productos desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<ProductoViewModel> ObtenerProductos()
        {
            //Obtengo los productos de la base, lo mappeo a viewmodel, y devueldo la vista de eso
            List<ProductoViewModel> productos = null ;
            try
            {
                List<ProductoDataModel> productoDataModels = productoDao.GetAllElements();
                productos = new List<ProductoViewModel>();

                foreach (ProductoDataModel productoDataModel in productoDataModels)
                {
                    productos.Add(Mapper.Map<ProductoDataModel, ProductoViewModel>(productoDataModel));
                }
            }
            catch (Exception)
            {
                productos = new List<ProductoViewModel>();
            }
            return productos;
        }

        /// <summary>
        /// Modifica un producto segun los datos establecidos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <returns></returns>
        public static bool ModificarProductos(int id, string descripcion, double precio)
        {
            bool seModifico;
            try
            {
                seModifico = productoDao.UpdateElement(new ProductoDataModel(id, descripcion, Convert.ToDouble(precio)));
            }
            catch (Exception)
            {
                seModifico = false;
            }
            return seModifico;
        }

        /// <summary>
        /// Elimina un producto segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool EliminarProducto(int id)
        {
            bool seElimino;
            try
            {
                seElimino = productoDao.DeleteElementById(id);
            }
            catch (Exception)
            {
                seElimino = false;
            }
            return seElimino;
        }

        /// <summary>
        /// Agrega un nuevo producto a la base de datos
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <returns></returns>
        public static bool AgregarProducto(string descripcion, double precio)
        {
            bool seAgrego;
            try
            {
                seAgrego = productoDao.CreateElement(new ProductoDataModel(descripcion, precio));
            }
            catch (Exception)
            {
                seAgrego = false;
            }
            return seAgrego;
        } 
        #endregion
    }
}
