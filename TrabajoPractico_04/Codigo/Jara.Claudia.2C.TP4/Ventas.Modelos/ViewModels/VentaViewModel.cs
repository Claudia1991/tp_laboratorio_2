using System;

namespace Ventas.Modelos.ViewModels
{
    public class VentaViewModel : BaseViewModel
    {
        #region Propiedades
        public DateTime Fecha { get; set; }
        public double MontoTotal { get; set; }
        public VentaDetalleViewModel DetalleVenta { get; set; }
        #endregion

        #region Constructores
        public VentaViewModel() { }

        public VentaViewModel(int id, DateTime fecha, double montoTotal, VentaDetalleViewModel ventaDetalle) : base(id)
        {
            Fecha = fecha;
            MontoTotal = montoTotal;
            DetalleVenta = ventaDetalle;
        } 
        #endregion

        #region Sobre carga de metodos
        public override string ToString()
        {
            return string.Concat($"Id Venta {this.Id.ToString()} - Fecha: {this.Fecha.ToString()} - Monto Total:{this.MontoTotal.ToString()} \n", this.DetalleVenta.ToString());
        } 
        #endregion
    }
}
