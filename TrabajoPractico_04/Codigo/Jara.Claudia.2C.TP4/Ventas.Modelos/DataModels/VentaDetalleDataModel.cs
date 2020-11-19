using System.Collections.Generic;

namespace Ventas.Modelos.DataModels
{
    public class VentaDetalleDataModel
    {
        #region Propiedades
        public List<ProductoDetalleDataModel> Productos { get; set; } 
        #endregion
    }
}
