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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ProductoDao productoDao;

        static ProductoBussines()
        {
            productoDao = new ProductoDao();
        }

        public static List<ProductoViewModel> ObtenerProductos()
        {
            //Obtengo los productos de la base, lo mappeo a viewmodel, y devueldo la vista de eso
            List<ProductoViewModel> productos = new List<ProductoViewModel>();
            try
            {
                List<ProductoDataModel> productoDataModels = productoDao.GetAllElements();

                foreach (ProductoDataModel productoDataModel in productoDataModels)
                {
                    productos.Add(Mapper.Map<ProductoDataModel, ProductoViewModel>(productoDataModel));
                }
            }
            catch (Exception)
            {

                throw;
            }
            return productos;
        }

        public static bool ModificarProductos(int id, string descripcion, double precio)
        {
            //Verificar que el view model tenga todos los datos, pasarlo a datamodel y devolver el tema
            return productoDao.UpdateElement(new ProductoDataModel(id, descripcion, Convert.ToDouble(precio)));
        }

        public static bool EliminarProducto(int id)
        {
            //verificar que el id no sea nulo y eliminar
            return productoDao.DeleteElementById(id);
        }

        public static bool AgregarProducto(string descripcion, double precio)
        {
            return productoDao.CreateElement(new ProductoDataModel(descripcion, precio));
        }
    }
}
