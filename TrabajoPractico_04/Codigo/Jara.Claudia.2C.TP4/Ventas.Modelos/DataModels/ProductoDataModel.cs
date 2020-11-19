namespace Ventas.Modelos.DataModels
{
    public class ProductoDataModel : BaseDataModel
    {
        #region Campos
        private string descripcion;
        private double precio;
        #endregion


        #region Propiedades
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }


        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        } 
        #endregion


        #region Constructores
        public ProductoDataModel() { }
        public ProductoDataModel(string descripcion, double precio) : base(0)
        {
            Descripcion = descripcion;
            Precio = precio;
        }

        public ProductoDataModel(int id, string descripcion, double precio) : this(descripcion, precio)
        {
            Id = id;
        } 
        #endregion
    }
}
