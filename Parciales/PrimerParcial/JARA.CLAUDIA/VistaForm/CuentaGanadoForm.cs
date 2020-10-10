using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaForm
{
    public partial class CuentaGanadoForm : Form
    {
        private Bar bar;
        private Random random = new Random();

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
                //agrego
                Empleado empleado = new Empleado("Prueba", (short)random.Next());
                bool sePudo = bar + empleado;

            }
            else if (bar.Empleados.Count > empleados)
            {
                //elimino
                Empleado empleado = new Empleado("Prueba", (short)random.Next());

                bool sePudo = bar - empleado;

            }
        }

        private void nudGente_ValueChanged(object sender, EventArgs e)
        {
            int genteActual = (int)nudGente.Value;
            //Verifico si agrega , por la cantidad
            if (bar.Gente.Count < genteActual)
            {
                //agrego
                Gente gente = new Gente((short)random.Next());
                bool sePudo = bar + gente;

            }
            else if (bar.Gente.Count > genteActual)
            {
                //elimino, se que esto se puede mejorar, para eliminar gente
                Gente gente = new Gente((short)random.Next());
                bool sePudo = bar - gente;

            }

        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bar.ToString(),"Informe del ganado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
