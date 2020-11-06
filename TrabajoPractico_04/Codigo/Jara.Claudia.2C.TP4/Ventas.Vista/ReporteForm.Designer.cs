namespace Ventas.Vista
{
    partial class ReporteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpbAcciones = new System.Windows.Forms.GroupBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnPorFecha = new System.Windows.Forms.Button();
            this.btnTotalVentas = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.gpbAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbAcciones
            // 
            this.gpbAcciones.Controls.Add(this.btnAtras);
            this.gpbAcciones.Controls.Add(this.btnImprimir);
            this.gpbAcciones.Controls.Add(this.btnPorFecha);
            this.gpbAcciones.Controls.Add(this.btnTotalVentas);
            this.gpbAcciones.Location = new System.Drawing.Point(12, 12);
            this.gpbAcciones.Name = "gpbAcciones";
            this.gpbAcciones.Size = new System.Drawing.Size(134, 273);
            this.gpbAcciones.TabIndex = 0;
            this.gpbAcciones.TabStop = false;
            this.gpbAcciones.Text = "Acciones";
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(27, 232);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 3;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(27, 165);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnPorFecha
            // 
            this.btnPorFecha.Location = new System.Drawing.Point(27, 95);
            this.btnPorFecha.Name = "btnPorFecha";
            this.btnPorFecha.Size = new System.Drawing.Size(75, 23);
            this.btnPorFecha.TabIndex = 1;
            this.btnPorFecha.Text = "Por Fecha";
            this.btnPorFecha.UseVisualStyleBackColor = true;
            // 
            // btnTotalVentas
            // 
            this.btnTotalVentas.Location = new System.Drawing.Point(27, 33);
            this.btnTotalVentas.Name = "btnTotalVentas";
            this.btnTotalVentas.Size = new System.Drawing.Size(75, 23);
            this.btnTotalVentas.TabIndex = 0;
            this.btnTotalVentas.Text = "Total Ventas";
            this.btnTotalVentas.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(242, 21);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(451, 264);
            this.listBox1.TabIndex = 1;
            // 
            // ReporteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 320);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.gpbAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReporteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sistema de Ventas - Reportes";
            this.gpbAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbAcciones;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnPorFecha;
        private System.Windows.Forms.Button btnTotalVentas;
        private System.Windows.Forms.ListBox listBox1;
    }
}