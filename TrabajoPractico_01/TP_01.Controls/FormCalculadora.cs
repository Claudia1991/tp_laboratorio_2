using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TP_01.Entidades.Entidades;
using TP_01.Entidades.Helpers;

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
            if (string.IsNullOrEmpty(lblResultado.Text))
            {
                MessageBox.Show(MensajesHelper.ErrorOperacion(), "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Numero numeroADecimal = new Numero(lblResultado.Text);
                lblResultado.Text = numeroADecimal.DecimalBinario(lblResultado.Text);
                MessageBox.Show(MensajesHelper.OperacionExitosa(), "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblResultado.Text))
            {
                MessageBox.Show(MensajesHelper.ErrorOperacion(), "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                Numero numeroADecimal = new Numero(lblResultado.Text);
                string resultado = string.Empty;
                resultado = numeroADecimal.BinarioDecimal(lblResultado.Text);
                if (resultado != MensajesHelper.ErrorConversionBinarioDecimal())
                {
                    lblResultado.Text = resultado;
                    MessageBox.Show(MensajesHelper.OperacionExitosa(), "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(MensajesHelper.ErrorConversionBinarioDecimal(), "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            //Verificar que los txt ingresados sean numeros
            string numeroUno = txtNumeroUno.Text;
            string nuemroDos = txtNumeroDos.Text;
            if (!EsNumeroValido(numeroUno) || !EsNumeroValido(nuemroDos))
            {
                MessageBox.Show(MensajesHelper.ErrorOperacion(), "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else
            {
                double resultado;
                string resultadoInformacion;
                resultado = Operar(numeroUno, nuemroDos, cmbOperador.SelectedValue.ToString());
                resultadoInformacion = resultado == double.MinValue ? MensajesHelper.ErrorDivisionPorCero() : MensajesHelper.OperacionExitosa();
                MessageBox.Show(resultadoInformacion, "Mensaje al usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblResultado.Text = resultado.ToString();
            }
        }

        private void txtNumeroDos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOperar_Click(sender, e);
            }
        }
        #endregion

        #region Metodos Privados
        /// <summary>
        /// Limpia los cuadros de texto, el label del resultado y deja el combobox con el primer operador.
        /// </summary>
        private void Limpiar()
        {
            txtNumeroUno.Text = string.Empty;
            txtNumeroDos.Text = string.Empty;
            lblResultado.Text = string.Empty;
            cmbOperador.SelectedIndex = 0;
        }

        /// <summary>
        /// Realiza la operación dada entre los dos números y devuelve el resultado.
        /// </summary>
        /// <param name="numeroUno">Primer numero</param>
        /// <param name="numeroDos">Segundo numero</param>
        /// <param name="operador">Operación a realizar.</param>
        /// <returns>El resultado de la operación entre los dos números.</returns>
        private static double Operar(string numeroUno, string numeroDos, string operador)
        {
            return Calculadora.Operar(new Numero(numeroUno), new Numero(numeroDos), operador);
        }

        /// <summary>
        /// Carga los operadores matematicos al combo box
        /// </summary>
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

        /// <summary>
        /// Valida que el string se pueda parsear a numero.
        /// </summary>
        /// <param name="numero">Numero a parsear</param>
        /// <returns>Devuelve true o false.</returns>
        private bool EsNumeroValido(string numero)
        {
            Regex regex = new Regex("[0-9]");
            int cantidadComas = Regex.Matches(numero, ",").Count;
            return !string.IsNullOrEmpty(numero) && regex.IsMatch(numero) && !numero.Contains(" ") && !numero.Contains(".") && (cantidadComas <=1);
        }
        #endregion
    }
}
