namespace Ventas.Modelos.DataModels
{
    public class ProductoDetalleDataModel : ProductoDataModel
    {
        public int CantidadPorProducto { get; set; }
        public double PrecioTotalPorProducto { get; set; }

        public ProductoDetalleDataModel(int id, string descripcion, double precio, int cantidad, double precioTotal): base(id, descripcion, precio)
        {
            CantidadPorProducto = cantidad;
            PrecioTotalPorProducto = precioTotal;
        }

        public ProductoDetalleDataModel(string descripcion, double precio, int cantidad, double precioTotal) : base(descripcion, precio)
        {
            CantidadPorProducto = cantidad;
            PrecioTotalPorProducto = precioTotal;
        }
    }
}
