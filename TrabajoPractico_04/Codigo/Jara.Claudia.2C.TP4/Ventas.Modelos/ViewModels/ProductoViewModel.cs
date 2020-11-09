namespace Ventas.Modelos.ViewModels
{
    public class ProductoViewModel : BaseViewModel
    {
        private string descripcion;
        private double precio;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }


        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public ProductoViewModel() { }
        public ProductoViewModel(string descripcion, double precio) : base(0)
        {
            Descripcion = descripcion;
            Precio = precio;
        }

        public ProductoViewModel(int id, string descripcion, double precio) : this(descripcion, precio)
        {
            Id = id;
        }
    }
}
