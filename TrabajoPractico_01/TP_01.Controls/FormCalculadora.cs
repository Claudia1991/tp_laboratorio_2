﻿using System;
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
                lblInformativo.Text = MensajesHelper.ErrorOperacion();
            }
            else
            {
                Numero numeroADecimal = new Numero(lblResultado.Text);
                lblResultado.Text = numeroADecimal.DecimalBinario(lblResultado.Text);
                lblInformativo.Text = MensajesHelper.OperacionExitosa();
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblResultado.Text))
            {
                lblInformativo.Text = MensajesHelper.ErrorOperacion();
            }
            else
            {
                Numero numeroADecimal = new Numero(lblResultado.Text);
                string resultado = string.Empty;
                resultado = numeroADecimal.BinarioDecimal(lblResultado.Text);
                if (resultado != MensajesHelper.ErrorConversionBinarioDecimal())
                {
                    lblResultado.Text = resultado;
                }
                else
                {
                    lblInformativo.Text = MensajesHelper.ErrorOperacion();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            bool sonNumerosValidos = regex.IsMatch(txtNumeroUno.Text) && regex.IsMatch(txtNumeroDos.Text);
            //Verificar que los txt ingresados sean numeros
            if (string.IsNullOrEmpty(txtNumeroUno.Text) || string.IsNullOrEmpty(txtNumeroDos.Text) || !sonNumerosValidos)
            {
                lblInformativo.Text = MensajesHelper.ErrorOperacion();
            }
            else
            {
                double resultado;
                resultado = Operar(txtNumeroUno.Text, txtNumeroDos.Text, cmbOperador.SelectedValue.ToString());
                lblInformativo.Text = resultado == double.MinValue ? MensajesHelper.ErrorOperacion() : MensajesHelper.OperacionExitosa();
                lblResultado.Text = resultado.ToString();
            }
        }
        #endregion

        #region Metodos Privados
        private void Limpiar()
        {
            txtNumeroUno.Text = string.Empty;
            txtNumeroDos.Text = string.Empty;
            lblResultado.Text = string.Empty;
            lblInformativo.Text = string.Empty;
            cmbOperador.SelectedIndex = 0;
        }

        private static double Operar(string numeroUno, string numeroDos, string operador)
        {
            return Calculadora.Operar(new Numero(numeroUno), new Numero(numeroDos), operador);
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
