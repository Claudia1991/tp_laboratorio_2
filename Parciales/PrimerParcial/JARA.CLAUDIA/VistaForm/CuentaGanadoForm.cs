using Entidades;
using System;
using System.Windows.Forms;

namespace VistaForm
{
    public partial class CuentaGanadoForm : Form
    {
        #region Campos
        private Bar bar;
        private DatosForm datosForm;
        private InformeForm informeForm;
        #endregion

        public CuentaGanadoForm()
        {
            InitializeComponent();
            //Inicializo el bar bar bar
            bar = Bar.GetBar();
        }

        private void nudEmpleados_ValueChanged(object sender, EventArgs e)
        {
            int empleados = (int)nudEmpleados.Value;
            //Verifico si agrega , por la cantidad
            if (bar.Empleados.Count < empleados)
            {
                using (datosForm = new DatosForm(bar, typeof(Empleado)))
                {
                    datosForm.ShowDialog();
                    if (datosForm.DialogResult == DialogResult.Cancel)
                    {
                        //Le dio Cancelar al formulario, entonces no sumo nada, no agrego nada
                        nudEmpleados.Value = bar.Empleados.Count;
                    }
                }
            }
            else if (bar.Empleados.Count > empleados)
            {
                bar.BorrarPersonasDelBar(bar, typeof(Empleado));
            }
        }

        private void nudGente_ValueChanged(object sender, EventArgs e)
        {
            int genteActual = (int)nudGente.Value;
            //Verifico si agrega , por la cantidad
            if (bar.Gente.Count < genteActual && !bar.EstaLleno)
            {
                using (datosForm = new DatosForm(bar, typeof(Gente)))
                {
                    datosForm.ShowDialog();
                    if (datosForm.DialogResult == DialogResult.Cancel)
                    {
                        //Le dio Cancelar al formulario, entonces no sumo nada, no agrego nada
                        nudGente.Value = bar.Gente.Count;
                    }
                }
            }
            else if (bar.Gente.Count > genteActual)
            {
                bar.BorrarPersonasDelBar(bar, typeof(Gente));
            }
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            using (informeForm = new InformeForm(bar.ToString()))
            {
                informeForm.ShowDialog();
            }
        }

        private void CuentaGanadoForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (bar.EstaLleno)
            {
                nudGente.Enabled = false;
            }
            else
            {
                nudGente.Enabled = true;
            }
        }
    }
}
