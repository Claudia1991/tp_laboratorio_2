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

namespace Ventas.Vista
{
    public partial class ProductoForm : Form
    {
        public ProductoForm()
        {
            InitializeComponent();

            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.DataSource = ProductoBussines.ObtenerProductos();
        }

        private void ProductoForm_MouseMove(object sender, MouseEventArgs e)
        {
            //Verifico que el usuario haya seleccionado algo en la grilla para poder eliminar/Modificar
            if (this.dgvProductos.SelectedRows.Count > 0)
            {
                this.btnEliminar.Enabled = true;
                this.btnModificar.Enabled = true;

            }
            else
            {
                this.btnEliminar.Enabled = false;
                this.btnModificar.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (AltaModificacionProductoForm altaModificacionProductoForm = new AltaModificacionProductoForm(true))
            {
                altaModificacionProductoForm.ShowDialog();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            using (AltaModificacionProductoForm altaModificacionProductoForm = new AltaModificacionProductoForm(false))
            {
                altaModificacionProductoForm.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ProductoBussines.EliminarProducto(Convert.ToInt32(this.dgvProductos.SelectedRows[0].DataGridView[0,0])))
            {
                MessageBox.Show("Se elimino correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("No se pudo eliminar el registro.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
