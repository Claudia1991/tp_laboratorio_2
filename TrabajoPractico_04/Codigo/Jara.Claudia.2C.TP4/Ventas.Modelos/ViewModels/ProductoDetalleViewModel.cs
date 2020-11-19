namespace Ventas.Modelos.ViewModels
{
    public class ProductoDetalleViewModel : ProductoViewModel
    {
        #region Propiedades
        public int CantidadPorProducto { get; set; }
        public double PrecioTotalPorProducto { get; set; }
        #endregion

        #region Constructores
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
        #endregion

        #region Sobrecarga de Metodos
        public override string ToString()
        {
            return base.ToString() + $"\t \nCantidad por producto: {this.CantidadPorProducto} - Precio total por producto: {this.PrecioTotalPorProducto}";
        } 
        #endregion
    }
}
