using System.Collections.Generic;
using Ventas.Modelos.DataModels;

namespace Ventas.DAO
{
    public interface IDao<T> where T : BaseDataModel
    {
        T GetElementById(int id);
        bool UpdateElement(T element);
        bool DeleteElementById(int id);
        List<T> GetAllElements();
    }
}
