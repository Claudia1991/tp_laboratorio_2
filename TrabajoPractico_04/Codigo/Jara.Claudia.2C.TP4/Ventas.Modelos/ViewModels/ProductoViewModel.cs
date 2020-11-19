namespace Ventas.Modelos.ViewModels
{
    public class ProductoViewModel : BaseViewModel
    {
        #region Campos
        private string descripcion;
        private double precio;
        #endregion

        #region Propiedades
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
        #endregion

        #region Construcotes
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
        #endregion

        #region Sobrecarga de Medos
        public override string ToString()
        {
            return base.ToString() + $" \t \nDescripcion: {this.Descripcion} - Precio: {this.Precio}";
        } 
        #endregion
    }
}
