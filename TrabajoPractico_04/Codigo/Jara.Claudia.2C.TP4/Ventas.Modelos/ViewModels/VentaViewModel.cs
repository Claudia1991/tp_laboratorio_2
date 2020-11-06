using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Modelos.ViewModels
{
    public class VentaViewModel : BaseViewModel
    {
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }
        public int CantidadPorProducto { get; set; }
        public float PrecioTotalPorProducto { get; set; }
        public DateTime Fecha { get; set; }
        public float MontoTotal { get; set; }
    }
}
