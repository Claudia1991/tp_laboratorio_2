using System;

namespace Ventas.Modelos.ViewModels
{
    public class VentaViewModel : BaseViewModel
    {
        public DateTime Fecha { get; set; }
        public double MontoTotal { get; set; }
        public VentaDetalleViewModel DetalleVenta { get; set; }

        public VentaViewModel() { }

        public VentaViewModel(int id, DateTime fecha, double montoTotal, VentaDetalleViewModel ventaDetalle) : base(id)
        {
            Fecha = fecha;
            MontoTotal = montoTotal;
            DetalleVenta = ventaDetalle;
        }

        public override string ToString()
        {
            return string.Concat($"Fecha: {this.Fecha.ToString()} - Monto Total:{this.MontoTotal.ToString()} \n",this.DetalleVenta.ToString());
        }
    }
}
