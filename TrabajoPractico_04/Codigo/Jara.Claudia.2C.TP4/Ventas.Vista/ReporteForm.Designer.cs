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
            this.btnTotalVentas = new System.Windows.Forms.Button();
            this.lstReporte = new System.Windows.Forms.ListBox();
            this.gpbAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbAcciones
            // 
            this.gpbAcciones.Controls.Add(this.btnAtras);
            this.gpbAcciones.Controls.Add(this.btnImprimir);
            this.gpbAcciones.Controls.Add(this.btnTotalVentas);
            this.gpbAcciones.Location = new System.Drawing.Point(16, 15);
            this.gpbAcciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbAcciones.Name = "gpbAcciones";
            this.gpbAcciones.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbAcciones.Size = new System.Drawing.Size(179, 212);
            this.gpbAcciones.TabIndex = 0;
            this.gpbAcciones.TabStop = false;
            this.gpbAcciones.Text = "Acciones";
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(36, 157);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(100, 28);
            this.btnAtras.TabIndex = 3;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(36, 97);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 28);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnTotalVentas
            // 
            this.btnTotalVentas.Location = new System.Drawing.Point(36, 41);
            this.btnTotalVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTotalVentas.Name = "btnTotalVentas";
            this.btnTotalVentas.Size = new System.Drawing.Size(100, 28);
            this.btnTotalVentas.TabIndex = 0;
            this.btnTotalVentas.Text = "Total Ventas";
            this.btnTotalVentas.UseVisualStyleBackColor = true;
            this.btnTotalVentas.Click += new System.EventHandler(this.btnTotalVentas_Click);
            // 
            // lstReporte
            // 
            this.lstReporte.FormattingEnabled = true;
            this.lstReporte.ItemHeight = 16;
            this.lstReporte.Location = new System.Drawing.Point(323, 26);
            this.lstReporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstReporte.Name = "lstReporte";
            this.lstReporte.Size = new System.Drawing.Size(600, 324);
            this.lstReporte.TabIndex = 1;
            // 
            // ReporteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 394);
            this.Controls.Add(this.lstReporte);
            this.Controls.Add(this.gpbAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button btnTotalVentas;
        private System.Windows.Forms.ListBox lstReporte;
    }
}