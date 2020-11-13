namespace Ventas.Modelos.ViewModels
{
    public abstract class BaseViewModel
    {
        public int Id { get; set; }

        protected BaseViewModel() { }
        protected BaseViewModel(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Id producto: {this.Id}";
        }
    }
}
