using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ventas.Bussines;
using Ventas.Modelos.ViewModels;
using Ventas.Utilities;

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
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ProductoForm productoForm = new ProductoForm())
            {
                productoForm.actualizarProductosEvento += new ProductoForm.ActualizarProductosProductoFormDelegado(ActulizarComboProducto);
                productoForm.ShowDialog();
            }
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //agarra del lstviewReporte y lo guarda en un txt
            Texto texto = new Texto();
            if (texto.Guardar(string.Concat("Reporte", DateTime.Now.Ticks, ".txt"), VentasBussines.ObtenerTodasLasVentas()))
            {
                MessageBox.Show("Se imprimio el reporte,revise la carpera 'Archivos Guardados' en la ruta del ejecutable.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No puede imprimir el reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.venta = new VentaViewModel() { DetalleVenta = new VentaDetalleViewModel() { Productos = new List<ProductoDetalleViewModel>() } };
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
    }
}
