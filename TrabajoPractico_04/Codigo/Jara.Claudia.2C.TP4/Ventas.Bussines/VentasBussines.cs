using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ventas.DAO;
using Ventas.Modelos.DataModels;
using Ventas.Modelos.ViewModels;
using Ventas.Utilities;

namespace Ventas.Bussines
{
    public static class VentasBussines
    {
        #region Campos
        private static VentasDao ventasDao;
        #endregion

        #region Constructor
        static VentasBussines()
        {
            ventasDao = new VentasDao();
        }
        #endregion

        #region Metodos Estaticos
        /// <summary>
        /// Carga el producto a la grilla de detalle de ventas
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static VentaViewModel AgregarProductoALaLista(VentaViewModel venta, ProductoViewModel producto, int cantidad)
        {
            //aca se agrega el producto a la lista, verificar que si el producto ya esta agregado, agregar la cantidad, no el mismo producto
            bool existeProducto = venta.DetalleVenta.Productos.Any(e => e.Id == producto.Id);
            if (existeProducto)
            {
                //si existe el producto, sumo la cantidad
                int indiceProducto = venta.DetalleVenta.Productos.FindIndex(e => e.Id == producto.Id);
                venta.DetalleVenta.Productos[indiceProducto].CantidadPorProducto += cantidad;
                venta.DetalleVenta.Productos[indiceProducto].PrecioTotalPorProducto =
                    venta.DetalleVenta.Productos[indiceProducto].CantidadPorProducto * venta.DetalleVenta.Productos[indiceProducto].Precio;
            }
            else
            {
                //si no existe el producto, agrego el producto
                venta.DetalleVenta.Productos.Add(new ProductoDetalleViewModel()
                {
                    Id = producto.Id,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    CantidadPorProducto = cantidad,
                    PrecioTotalPorProducto = producto.Precio * cantidad
                });

            }
            //calcular el monto total
            venta.MontoTotal = CalcularMontoTotal(venta);
            return venta;
        }

        /// <summary>
        /// Calcul el monto total de la venta
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        private static double CalcularMontoTotal(VentaViewModel venta)
        {
            return venta.DetalleVenta.Productos.Select(e => e.PrecioTotalPorProducto).Sum();
        }

        /// <summary>
        /// Realiza la venta.
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        public static bool Vender(VentaViewModel venta)
        {
            bool seVendio;
            try
            {
                VentaDataModel ventaDataModel = Mapper.Map<VentaViewModel, VentaDataModel>(venta);
                seVendio = ventasDao.CreateElement(ventaDataModel);
            }
            catch (System.Exception)
            {
                seVendio = false;
            }
            return seVendio;
        }

        /// <summary>
        /// Obtiene todas las ventas para realizar el reporte
        /// </summary>
        /// <returns></returns>
        public static string ObtenerTodasLasVentas()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (VentaDataModel venta in ventasDao.GetAllElements())
            {
                stringBuilder.AppendLine("=====================================================================");
                stringBuilder.AppendLine(Mapper.Map<VentaDataModel, VentaViewModel>(venta).ToString());
            }
            return stringBuilder.ToString();
        } 
        #endregion
    }
}
