namespace Ventas.Vista
{
    partial class VentasForm
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
            this.dgvVenta = new System.Windows.Forms.DataGridView();
            this.gpbProductos = new System.Windows.Forms.GroupBox();
            this.btnAgregarALista = new System.Windows.Forms.Button();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.nudCantidadProductos = new System.Windows.Forms.NumericUpDown();
            this.gpbVentas = new System.Windows.Forms.GroupBox();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.msBarra = new System.Windows.Forms.MenuStrip();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).BeginInit();
            this.gpbProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadProductos)).BeginInit();
            this.gpbVentas.SuspendLayout();
            this.msBarra.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVenta
            // 
            this.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenta.Location = new System.Drawing.Point(41, 41);
            this.dgvVenta.Name = "dgvVenta";
            this.dgvVenta.Size = new System.Drawing.Size(717, 150);
            this.dgvVenta.TabIndex = 0;
            // 
            // gpbProductos
            // 
            this.gpbProductos.Controls.Add(this.btnAgregarALista);
            this.gpbProductos.Controls.Add(this.cmbProductos);
            this.gpbProductos.Controls.Add(this.nudCantidadProductos);
            this.gpbProductos.Location = new System.Drawing.Point(41, 224);
            this.gpbProductos.Name = "gpbProductos";
            this.gpbProductos.Size = new System.Drawing.Size(346, 100);
            this.gpbProductos.TabIndex = 1;
            this.gpbProductos.TabStop = false;
            this.gpbProductos.Text = "Productos";
            // 
            // btnAgregarALista
            // 
            this.btnAgregarALista.Location = new System.Drawing.Point(197, 71);
            this.btnAgregarALista.Name = "btnAgregarALista";
            this.btnAgregarALista.Size = new System.Drawing.Size(121, 23);
            this.btnAgregarALista.TabIndex = 2;
            this.btnAgregarALista.Text = "Agregar a la Lista";
            this.btnAgregarALista.UseVisualStyleBackColor = true;
            // 
            // cmbProductos
            // 
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(197, 28);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(121, 21);
            this.cmbProductos.TabIndex = 1;
            // 
            // nudCantidadProductos
            // 
            this.nudCantidadProductos.Location = new System.Drawing.Point(22, 28);
            this.nudCantidadProductos.Name = "nudCantidadProductos";
            this.nudCantidadProductos.Size = new System.Drawing.Size(120, 20);
            this.nudCantidadProductos.TabIndex = 0;
            // 
            // gpbVentas
            // 
            this.gpbVentas.Controls.Add(this.btnVender);
            this.gpbVentas.Controls.Add(this.btnCancelar);
            this.gpbVentas.Location = new System.Drawing.Point(449, 224);
            this.gpbVentas.Name = "gpbVentas";
            this.gpbVentas.Size = new System.Drawing.Size(309, 100);
            this.gpbVentas.TabIndex = 2;
            this.gpbVentas.TabStop = false;
            this.gpbVentas.Text = "Ventas";
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(228, 42);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(75, 23);
            this.btnVender.TabIndex = 1;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(30, 42);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // msBarra
            // 
            this.msBarra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.reporteToolStripMenuItem});
            this.msBarra.Location = new System.Drawing.Point(0, 0);
            this.msBarra.Name = "msBarra";
            this.msBarra.Size = new System.Drawing.Size(800, 24);
            this.msBarra.TabIndex = 3;
            this.msBarra.Text = "menuStrip1";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // reporteToolStripMenuItem
            // 
            this.reporteToolStripMenuItem.Name = "reporteToolStripMenuItem";
            this.reporteToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.reporteToolStripMenuItem.Text = "Reporte";
            // 
            // VentasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gpbVentas);
            this.Controls.Add(this.gpbProductos);
            this.Controls.Add(this.dgvVenta);
            this.Controls.Add(this.msBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.msBarra;
            this.Name = "VentasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistemas de Ventas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).EndInit();
            this.gpbProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadProductos)).EndInit();
            this.gpbVentas.ResumeLayout(false);
            this.msBarra.ResumeLayout(false);
            this.msBarra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVenta;
        private System.Windows.Forms.GroupBox gpbProductos;
        private System.Windows.Forms.Button btnAgregarALista;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.NumericUpDown nudCantidadProductos;
        private System.Windows.Forms.GroupBox gpbVentas;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MenuStrip msBarra;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteToolStripMenuItem;
    }
}