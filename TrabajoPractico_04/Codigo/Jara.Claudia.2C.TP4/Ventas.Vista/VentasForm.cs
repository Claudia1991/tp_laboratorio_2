using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Ventas.Bussines;
using Ventas.Modelos.ViewModels;
using Ventas.Utilities;

namespace Ventas.Vista
{
    public partial class VentasForm : Form
    {
        #region Campos
        private delegate void CallbackDelegate(string estadoReporte);
        private VentaViewModel venta;
        private Thread threadReporte;
        #endregion

        #region Constructor
        public VentasForm()
        {
            InitializeComponent();
            InicializarProductos();
            InicializarCampos();
            this.btnAgregarALista.Enabled = false;
            this.btnVender.Enabled = false;
            this.threadReporte = new Thread(ImprimirReporte);
        }
        #endregion

        #region Metodos

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ProductoForm productoForm = new ProductoForm())
            {
                productoForm.actualizarProductosEvento += this.ActulizarComboProducto;
                productoForm.ShowDialog();
            }
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (threadReporte.ThreadState == ThreadState.Stopped)
            {
                this.threadReporte = new Thread(ImprimirReporte);
            }
            threadReporte.Start();

        }

        private void InicializarProductos()
        {
            this.cmbProductos.DataSource = ProductoBussines.ObtenerProductos();
            this.cmbProductos.ValueMember = "Id";
            this.cmbProductos.DisplayMember = "Descripcion";
        }

        /// <summary>
        /// Imprime el reporte de las ventas totales
        /// </summary>
        private void ImprimirReporte()
        {
            try
            {
                Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings.Get("TiempoDelay")));
                /*pongo un delay, para simular que fue a la impresora, etc, pero como corre en un hilo secundario, 
                 * se puede seguir manejando la app*/
                Texto texto = new Texto();
                texto.Guardar(string.Concat("Reporte", DateTime.Now.Ticks, ".txt"), VentasBussines.ObtenerTodasLasVentas());
                ActualizarInformacionReporte("El reporte se imprimio en la carpeta Archivos Guardados.");
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al intentar realizar el reporte", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarInformacionReporte(string informeReporte)
        {
            if (this.lblInformacionReporte.InvokeRequired)
            {
                CallbackDelegate callback = new CallbackDelegate(ActualizarInformacionReporte);
                object[] args = new object[]
                {
                    informeReporte
                };

                this.Invoke(callback, args);
            }
            else
            {
                this.lblInformacionReporte.Text = informeReporte;
            }
        }

        private void InicializarCampos()
        {
            this.venta = new VentaViewModel() 
            { 
                DetalleVenta = new VentaDetalleViewModel() 
                { 
                    Productos = new List<ProductoDetalleViewModel>() 
                } 
            };
        }

        private void VentasForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (VerificarSiSePuedeAgregarProductoALaLista())
            {
                this.btnAgregarALista.Enabled = true;
            }
            if (VerificarSiSePuedeVender())
            {
                this.btnVender.Enabled = true;
            }
        }

        private bool VerificarSiSePuedeVender()
        {
            return this.dgvVenta.RowCount > 0;
        }

        private bool VerificarSiSePuedeAgregarProductoALaLista()
        {
            return this.cmbProductos.SelectedItem != null;
        }

        private void btnAgregarALista_Click(object sender, EventArgs e)
        {
            ProductoViewModel producto = ProductoBussines.ObtenerProductos().First(p => p.Id == Convert.ToInt32(this.cmbProductos.SelectedValue));
            int cantidad = (int)this.nudCantidadProductos.Value;
            VentasBussines.AgregarProductoALaLista(venta, producto, cantidad);
            this.ActualizarGrilla();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            this.venta.Fecha = DateTime.Now;
            bool seVendio = VentasBussines.Vender(this.venta);
            if (seVendio)
            {
                MessageBox.Show("Se vendio, sos cra'.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Limpiar();
            }
            else
            {
                MessageBox.Show("No se vendio,igual sos cra'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            this.nudCantidadProductos.Value = 1;
            this.cmbProductos.SelectedIndex = 0;
            this.dgvVenta.DataSource = null;
            this.lblMontoTotalVenta.Text = string.Empty;
            this.InicializarCampos();
        }

        private void ActualizarGrilla()
        {
            this.dgvVenta.DataSource = null;
            this.dgvVenta.DataSource = venta.DetalleVenta.Productos;
            this.lblMontoTotalVenta.Text = venta.MontoTotal.ToString();
        }

        private void ActulizarComboProducto()
        {
            this.cmbProductos.DataSource = null;
            InicializarProductos();
        }

        private void VentasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadReporte.IsAlive)
            {
                threadReporte.Abort();
            }
        } 
        #endregion
    }
}
