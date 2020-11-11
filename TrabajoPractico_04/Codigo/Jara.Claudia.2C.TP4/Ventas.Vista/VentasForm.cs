using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ventas.Bussines;
using Ventas.Modelos.ViewModels;

namespace Ventas.Vista
{
    public partial class VentasForm : Form
    {
        private VentaViewModel venta;

        public VentasForm()
        {
            InitializeComponent();
            InicializarProductos();
            InicializarCampos();
            this.btnAgregarALista.Enabled = false;
            this.btnVender.Enabled = false;
            this.dgvVenta.Enabled = false;
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ProductoForm productoForm = new ProductoForm())
            {
                productoForm.ShowDialog();
            }
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ReporteForm reporteForm = new ReporteForm())
            {
                reporteForm.ShowDialog();
            }
        }

        private void InicializarProductos()
        {
            this.cmbProductos.DataSource = ProductoBussines.ObtenerProductos(); 
            this.cmbProductos.ValueMember = "Id";
            this.cmbProductos.DisplayMember = "Descripcion";
        }

        private void InicializarCampos()
        {
            this.venta = new VentaViewModel();
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
            ProductoViewModel producto = ProductoBussines.ObtenerProductos().First(p=>p.Id == Convert.ToInt32(this.cmbProductos.SelectedValue));
            int cantidad = (int)this.nudCantidadProductos.Value;
            VentasBussines.AgregarProductoALaLista(venta, producto, cantidad);
            this.dgvVenta.DataSource = venta.DetalleVenta.Productos;
            this.lblMontoTotalVenta.Text = venta.MontoTotal.ToString();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
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
            this.cmbProductos.SelectedIndex = -1;
            this.dgvVenta.DataSource = null;
            this.lblMontoTotalVenta.Text = string.Empty;
        }
    }
}
