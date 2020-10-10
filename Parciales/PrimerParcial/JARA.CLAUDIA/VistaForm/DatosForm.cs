﻿using Entidades;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VistaForm
{
    public partial class DatosForm : Form
    {
        #region Campos
        private Bar bar;
        private Type tipo;
        private Regex regex;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get
            {
                return this.txtNombre.Text;
            }
        }

        public string Edad
        {
            get
            {
                return this.txtEdad.Text;
            }
        }

        public string Dni
        {
            get
            {
                return this.txtDni.Text;
            }
        }
        #endregion

        #region Constructores
        public DatosForm()
        {
            InitializeComponent();
        }

        public DatosForm(Bar bar, Type tipo) : this()
        {
            this.bar = bar;
            this.tipo = tipo;
        }
        #endregion

        #region Metodos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.tipo == typeof(Empleado))
            {
                if (EsDniValido() && EsEdadValida() && EsNombreValido())
                {
                    Empleado empleado = CrearEmpleado(Nombre, Dni, Edad);
                    bool seAgregoEmpleado = bar + empleado;
                    if (seAgregoEmpleado)
                    {
                        MessageBox.Show("Se agrego el empleado!", "Nuevo empleado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error", "Nuevo empleado.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                        MessageBox.Show("Verifique los datos para cargar el nuevo empleado", "Nuevo empleado.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                if (EsEdadValida())
                {
                    short edadCliente;
                    Int16.TryParse(Edad, out edadCliente);
                    Gente cliente = new Gente(edadCliente);
                    bool seAgregoCliente = bar + cliente;
                    if (seAgregoCliente)
                    {
                        MessageBox.Show("Se agrego el cliente!", "Nuevo Cliente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error", "Nuevo Cliente.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Verifique los datos para cargar el cliente", "Nuevo cliente.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        /// <summary>
        /// Deshabilita los controles si la persona a crear es de tipo Gente
        /// </summary>
        private void HabilitarControlesSegunPersona()
        {
            if (this.tipo == typeof(Gente))
            {
                this.txtNombre.Enabled = false;
                this.txtDni.Enabled = false;
            }
        }

        /// <summary>
        /// Valida que sea un dni valido(solo numeros)
        /// </summary>
        /// <returns></returns>
        private bool EsDniValido()
        {
            regex = new Regex("[0,9]");
            return string.IsNullOrEmpty(Dni) || regex.IsMatch(Dni);
        }

        /// <summary>
        /// Valida que sea una edad valida(solo numeros)
        /// </summary>
        /// <returns></returns>
        private bool EsEdadValida()
        {
            regex = new Regex(@"^\d$");
            return regex.IsMatch(Edad);
        }

        /// <summary>
        /// Valida si la extension del nombre es mayor o igual a 2
        /// </summary>
        /// <returns></returns>
        private bool EsNombreValido()
        {
            return Nombre.Length >= 2;
        }

        /// <summary>
        /// Crea el empleado segun los parametros pasados
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="dni"></param>
        /// <param name="edad"></param>
        /// <returns>Un nuevo empleado</returns>
        private Empleado CrearEmpleado(string nombre, string dni, string edad)
        {
            Empleado empleado;
            short edadEmpleado;
            Int16.TryParse(edad, out edadEmpleado);
            int dniEmpleado;
            Int32.TryParse(dni,out dniEmpleado);
            if (string.IsNullOrEmpty(dni))
            {
                empleado = new Empleado(nombre, edadEmpleado);
            }
            else
            {
                empleado = new Empleado(nombre, edadEmpleado,dniEmpleado);

            }
            return empleado;
        }

        private void DatosForm_Load(object sender, EventArgs e)
        {
            HabilitarControlesSegunPersona();

        }
        #endregion
    }
}
