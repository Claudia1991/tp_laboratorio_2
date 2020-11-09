using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Modelos.ViewModels
{
    public class ProductoDetalleViewModel : BaseViewModel
    {
        public int CantidadPorProducto { get; set; }
        public double PrecioTotalPorProducto { get; set; }
    }
}
