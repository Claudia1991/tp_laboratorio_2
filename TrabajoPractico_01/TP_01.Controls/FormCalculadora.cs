using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TP_01.Controls
{
    public partial class MiCalculadora : Form
    {
        #region Constructores
        public MiCalculadora()
        {
            InitializeComponent();
            CargarOperadoresEnComboBox();
        }
        #endregion

        #region Eventos Metodos Privados
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Metodos Privados
        private void Limpiar()
        {
            txtNumeroUno.Text = string.Empty;
            txtNumeroDos.Text = string.Empty;
            lblResultado.Text = string.Empty;
            cmbOperador.SelectedIndex = 0;
        }

        private static double Operar(string numeroUno, string numeroDos, string operador)
        {
            return 0;
        }

        private void CargarOperadoresEnComboBox()
        {
            List<object> operadores = new List<object>()
            {
                new {Operador='+' },
                new {Operador='/' },
                new {Operador='*' },
                new {Operador='-' },
            };
            cmbOperador.DataSource = operadores;
            cmbOperador.ValueMember = "Operador";
            cmbOperador.DisplayMember = "Operador";
        }
        #endregion
    }
}
