namespace Ventas.Modelos.ViewModels
{
    public abstract class BaseViewModel
    {
        #region Propiedades
        public int Id { get; set; } 
        #endregion

        #region Constructores
        protected BaseViewModel() { }
        protected BaseViewModel(int id)
        {
            Id = id;
        }
        #endregion

        #region Metodos sobrecargados
        public override string ToString()
        {
            return $"Id producto: {this.Id}";
        } 
        #endregion
    }
}
