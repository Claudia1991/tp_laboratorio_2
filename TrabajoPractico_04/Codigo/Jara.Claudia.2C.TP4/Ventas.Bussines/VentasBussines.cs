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
        private static VentasDao ventasDao;

        static VentasBussines()
        {
            ventasDao = new VentasDao();
        }
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

        private static double CalcularMontoTotal(VentaViewModel venta)
        {
            return venta.DetalleVenta.Productos.Select(e=>e.PrecioTotalPorProducto).Sum();
        }

        public static bool Vender(VentaViewModel venta)
        {
            VentaDataModel ventaDataModel = Mapper.Map<VentaViewModel, VentaDataModel>(venta);
            return ventasDao.CreateElement(ventaDataModel);
        }

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

        public static List<string> ObtenerVentas()
        {
            List<string> listaVentas = new List<string>();

            foreach (VentaDataModel venta in ventasDao.GetAllElements())
            {
                listaVentas.Add(Mapper.Map<VentaDataModel, VentaViewModel>(venta).ToString());
            }
            return listaVentas;
        }
    }
}
