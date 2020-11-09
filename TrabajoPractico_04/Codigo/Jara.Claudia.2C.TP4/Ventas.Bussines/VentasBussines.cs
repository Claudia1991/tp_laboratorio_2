using System.Collections.Generic;
using System.Linq;
using Ventas.Modelos.ViewModels;

namespace Ventas.Bussines
{
    public static class VentasBussines
    {
        public static VentaViewModel AgregarProductoALaLista(VentaViewModel venta, ProductoViewModel producto, int cantidad)
        {
            //aca se agrega el producto a la lista, verificar que si el producto ya esta agregado, agregar la cantidad, no el mismo producto
            bool existeProducto = venta.DetalleVenta.Productos.Any(e => e.Id == producto.Id);
            if (existeProducto)
            {
                //si existe el producto, sumo la cantidad
                int indiceProducto = venta.DetalleVenta.Productos.FindIndex(e => e.Id == producto.Id);
                venta.DetalleVenta.Productos[indiceProducto].CantidadPorProducto += cantidad;
                venta.DetalleVenta.Productos[indiceProducto].PrecioTotalPorProducto = venta.DetalleVenta.Productos[indiceProducto].CantidadPorProducto * venta.DetalleVenta.Productos[indiceProducto].Precio;
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
            //aca habria que usar el mapper, y llamar a los daos,
            //primero guardo en venta 
            return true;
        }
    }
}
