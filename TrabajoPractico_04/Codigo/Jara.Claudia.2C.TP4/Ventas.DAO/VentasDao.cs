using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Modelos.DataModels;

namespace Ventas.DAO
{
    public class VentasDao : IDao<BaseDataModel>
    {
        public bool CreateElement(BaseDataModel element)
        {
            throw new NotImplementedException();
        }

        public bool DeleteElementById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BaseDataModel> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public BaseDataModel GetElementById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateElement(BaseDataModel element)
        {
            throw new NotImplementedException();
        }
    }
}
