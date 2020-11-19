using System.Collections.Generic;
using System.Text;

namespace Ventas.Modelos.ViewModels
{
    public class VentaDetalleViewModel
    {
        #region Propiedades
        public List<ProductoDetalleViewModel> Productos { get; set; }
        #endregion

        #region Sobre carga de metodos
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ProductoDetalleViewModel producto in this.Productos)
            {
                stringBuilder.AppendLine(producto.ToString());
            }
            return stringBuilder.ToString();
        } 
        #endregion
    }
}
