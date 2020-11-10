namespace Ventas.Utilities
{
    public interface IArchivos<T>
    {
        #region Metodos
        bool Guardar(string archivos, T datos);
        bool Leer(string archivos, out T datos);
        #endregion
    }
}
