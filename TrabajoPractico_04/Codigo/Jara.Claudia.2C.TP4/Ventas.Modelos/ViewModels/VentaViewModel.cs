using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Modelos.ViewModels
{
    public class VentaViewModel : BaseViewModel
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public double MontoTotal { get; set; }
    }
}
