using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Ventas.Bussines;

namespace Ventas.Vista
{
    public partial class AltaModificacionProductoForm : Form
    {
        #region Campos
        public delegate void ActualizarProductosAltaModificacionProductoFormsDelegado();
        public event ActualizarProductosAltaModificacionProductoFormsDelegado actualizarProductosProductosEvento;
        private bool agregarElemento = false;
        private Regex regex;
        private const string patronDescripcion = "[a-zA-Z]";
        private const string patronPrecio = "[0-9]";
        #endregion

        #region Constructores
        public AltaModificacionProductoForm()
        {
            InitializeComponent();
            this.txtIdProducto.Enabled = false;
        }

        public AltaModificacionProductoForm(bool agregarElemento) : this()
        {
            this.agregarElemento = agregarElemento;
        }

        public AltaModificacionProductoForm(bool agregarElemento, string id, string descripcion, string precio) : this(agregarElemento)
        {
            this.txtIdProducto.Text = id;
            this.txtDescripcion.Text = descripcion;
            this.txtPrecio.Text = precio;
        }
        #endregion

        #region Metodos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (SonDatosCorrectos())
            {
                if (this.agregarElemento)
                {
                    if (ProductoBussines.AgregarProducto(this.txtDescripcion.Text, Convert.ToDouble(this.txtPrecio.Text)))
                    {
                        MessageBox.Show("Se agrego correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.actualizarProductosProductosEvento();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el registro.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    if (ProductoBussines.ModificarProductos(Convert.ToInt32(this.txtIdProducto.Text), this.txtDescripcion.Text, Convert.ToDouble(this.txtPrecio.Text)))
                    {
                        MessageBox.Show("Se modifico correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.actualizarProductosProductosEvento();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el registro.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("Error: hay datos invalidos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SonDatosCorrectos()
        {
            bool sonDatosCorrectos = false;
            regex = new Regex(patronDescripcion);
            if (!string.IsNullOrEmpty(this.txtDescripcion.Text) && regex.IsMatch(this.txtDescripcion.Text))
            {
                regex = new Regex(patronPrecio);
                if (!string.IsNullOrEmpty(this.txtPrecio.Text) && regex.IsMatch(this.txtPrecio.Text))
                {
                    sonDatosCorrectos = true;
                }
            }
            return sonDatosCorrectos;
        } 
        #endregion
    }
}
