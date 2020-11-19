namespace Ventas.Modelos.DataModels
{
    public abstract class BaseDataModel
    {
        #region Propiedades
        public int Id { get; set; }
        #endregion

        #region Constructores
        protected BaseDataModel() { }
        protected BaseDataModel(int id)
        {
            Id = id;
        } 
        #endregion
    }
}
