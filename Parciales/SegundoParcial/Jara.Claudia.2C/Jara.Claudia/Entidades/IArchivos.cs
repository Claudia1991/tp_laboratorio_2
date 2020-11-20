namespace Entidades
{
    public interface IArchivos<X>
    {
        void Guardar(X info);
        X Leer();
    }
}
