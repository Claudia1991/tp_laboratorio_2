using System.Collections.Generic;
using System.Text;

namespace Ventas.Modelos.ViewModels
{
    public class VentaDetalleViewModel
    {
        public List<ProductoDetalleViewModel> Productos{get;set;}

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ProductoDetalleViewModel producto in this.Productos)
            {
                stringBuilder.AppendLine(producto.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
