using System;
using System.Windows.Forms;
using Ventas.Bussines;
using Ventas.Utilities;

namespace Ventas.Vista
{
    public partial class ReporteForm : Form
    {
        public ReporteForm()
        {
            InitializeComponent();
        }

        private void btnTotalVentas_Click(object sender, System.EventArgs e)
        {
            //Trae todas las ventas y lo pone en el listviewreportes
            this.lstReporte.Text = VentasBussines.ObtenerTodasLasVentas();
        }

        private void btnImprimir_Click(object sender, System.EventArgs e)
        {
            //agarra del lstviewReporte y lo guarda en un txt
            if (!string.IsNullOrEmpty(this.lstReporte.Text))
            {
                Texto texto = new Texto();
                texto.Guardar(string.Concat("Reporte", DateTime.Now, ".txt"), this.lstReporte.Text);
                MessageBox.Show("Se imprimio el reporte, revise si escritorio.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("No puede imprimir el reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAtras_Click(object sender, System.EventArgs e)
        {
            this.lstReporte.Text = string.Empty;

            this.Close();
        }
    }
}
