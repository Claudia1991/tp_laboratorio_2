using System;

namespace Ventas.Modelos.DataModels
{
    public class VentaDataModel : BaseDataModel
    {
        #region Propiedades
        public DateTime Fecha { get; set; }
        public double MontoTotal { get; set; }
        public VentaDetalleDataModel DetalleVenta { get; set; }
        #endregion


        #region Constructos
        public VentaDataModel() { }

        public VentaDataModel(int id, DateTime fecha, double montoTotal, VentaDetalleDataModel ventaDetalle) : base(id)
        {
            Fecha = fecha;
            MontoTotal = montoTotal;
            DetalleVenta = ventaDetalle;
        } 
        #endregion
    }
}
