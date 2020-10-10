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
    public partial class InformeForm : Form
    {
        #region Campos
        private string informe;
        #endregion

        #region Constructores
        public InformeForm()
        {
            InitializeComponent();
        }

        public InformeForm(string informe): this()
        {
            this.informe = informe;
        }
        #endregion

        #region Metodos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InformeForm_Load(object sender, EventArgs e)
        {
            this.rtbInforme.Text = this.informe;
        }
        #endregion
    }
}
