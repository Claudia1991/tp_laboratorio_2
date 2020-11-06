using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Modelos.ViewModels
{
    public class ProductoViewModel : BaseViewModel
    {
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    }
}
