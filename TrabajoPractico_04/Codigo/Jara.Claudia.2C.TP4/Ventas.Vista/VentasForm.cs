using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas.Bussines;
using Ventas.Modelos.ViewModels;

namespace Ventas.Vista
{
    public partial class VentasForm : Form
    {
        private List<ProductoDetalleViewModel> productoDetalles;
        private List<ProductoViewModel> productos;

        public VentasForm()
        {
            InitializeComponent();
            InicializarProductos();
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
            productos = ProductoBussines.ObtenerProductos();

            this.cmbProductos.DataSource = productos;
            this.cmbProductos.ValueMember = "Id" ;
            this.cmbProductos.DisplayMember = "Descripcion - Precio" ;
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
            ProductoViewModel producto = productos.First(p=>p.Id == Convert.ToInt32(this.cmbProductos.SelectedValue));
            VentasBussines.AgregarProductoALaLista(productoDetalles, producto);
            this.dgvVenta.DataSource = productoDetalles;
        }

        private void btnVender_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.nudCantidadProductos.Value = 1;
            this.cmbProductos.SelectedIndex = -1;
            this.dgvVenta.DataSource = null;
        }
    }
}
