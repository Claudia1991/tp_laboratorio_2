﻿using System;
using System.Windows.Forms;
using Ventas.Bussines;
using Ventas.Modelos.ViewModels;

namespace Ventas.Vista
{

    public partial class ProductoForm : Form
    {
        #region Campos
        public delegate void ActualizarProductosProductoFormDelegado();
        public event ActualizarProductosProductoFormDelegado actualizarProductosEvento;

        #endregion
        #region Constructores
        public ProductoForm()
        {
            InitializeComponent();

            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.DataSource = ProductoBussines.ObtenerProductos();
        }
        #endregion

        #region Metodos
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
                altaModificacionProductoForm.actualizarProductosProductosEvento += this.RecargarProductos;

                altaModificacionProductoForm.ShowDialog();

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ProductoViewModel producto = (ProductoViewModel)this.dgvProductos.SelectedRows[0].DataBoundItem;
            using (AltaModificacionProductoForm altaModificacionProductoForm = new AltaModificacionProductoForm(false, producto.Id.ToString(), producto.Descripcion, producto.Precio.ToString()))
            {
                altaModificacionProductoForm.actualizarProductosProductosEvento += this.RecargarProductos;

                altaModificacionProductoForm.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ProductoViewModel producto = (ProductoViewModel)this.dgvProductos.SelectedRows[0].DataBoundItem;
            if (ProductoBussines.EliminarProducto(producto.Id))
            {
                MessageBox.Show("Se elimino correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.RecargarProductos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el registro.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.actualizarProductosEvento();
            this.Close();
        }

        private void RecargarProductos()
        {
            this.dgvProductos.DataSource = ProductoBussines.ObtenerProductos();
        } 
        #endregion
    }
}
