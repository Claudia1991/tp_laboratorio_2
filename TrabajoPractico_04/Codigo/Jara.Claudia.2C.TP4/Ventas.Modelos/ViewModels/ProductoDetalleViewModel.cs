namespace Ventas.Modelos.ViewModels
{
    public class ProductoDetalleViewModel : ProductoViewModel
    {
        public int CantidadPorProducto { get; set; }
        public double PrecioTotalPorProducto { get; set; }
        public ProductoDetalleViewModel() { }
        public ProductoDetalleViewModel(int id, string descripcion, double precio, int cantidad, double precioTotal) : base(id, descripcion, precio)
        {
            CantidadPorProducto = cantidad;
            PrecioTotalPorProducto = precioTotal;
        }

        public ProductoDetalleViewModel(string descripcion, double precio, int cantidad, double precioTotal) : base(descripcion, precio)
        {
            CantidadPorProducto = cantidad;
            PrecioTotalPorProducto = precioTotal;
        }
    }
}
