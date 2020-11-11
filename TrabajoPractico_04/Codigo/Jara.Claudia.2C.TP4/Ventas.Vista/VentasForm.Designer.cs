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
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMontoTotalVenta = new System.Windows.Forms.Label();
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
            this.dgvVenta.Location = new System.Drawing.Point(55, 50);
            this.dgvVenta.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVenta.MultiSelect = false;
            this.dgvVenta.Name = "dgvVenta";
            this.dgvVenta.ReadOnly = true;
            this.dgvVenta.RowHeadersWidth = 51;
            this.dgvVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVenta.Size = new System.Drawing.Size(956, 185);
            this.dgvVenta.TabIndex = 0;
            // 
            // gpbProductos
            // 
            this.gpbProductos.Controls.Add(this.btnAgregarALista);
            this.gpbProductos.Controls.Add(this.cmbProductos);
            this.gpbProductos.Controls.Add(this.nudCantidadProductos);
            this.gpbProductos.Location = new System.Drawing.Point(55, 328);
            this.gpbProductos.Margin = new System.Windows.Forms.Padding(4);
            this.gpbProductos.Name = "gpbProductos";
            this.gpbProductos.Padding = new System.Windows.Forms.Padding(4);
            this.gpbProductos.Size = new System.Drawing.Size(461, 123);
            this.gpbProductos.TabIndex = 1;
            this.gpbProductos.TabStop = false;
            this.gpbProductos.Text = "Productos";
            // 
            // btnAgregarALista
            // 
            this.btnAgregarALista.Location = new System.Drawing.Point(263, 87);
            this.btnAgregarALista.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarALista.Name = "btnAgregarALista";
            this.btnAgregarALista.Size = new System.Drawing.Size(161, 28);
            this.btnAgregarALista.TabIndex = 2;
            this.btnAgregarALista.Text = "Agregar a la Lista";
            this.btnAgregarALista.UseVisualStyleBackColor = true;
            this.btnAgregarALista.Click += new System.EventHandler(this.btnAgregarALista_Click);
            // 
            // cmbProductos
            // 
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(157, 34);
            this.cmbProductos.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(265, 24);
            this.cmbProductos.TabIndex = 1;
            // 
            // nudCantidadProductos
            // 
            this.nudCantidadProductos.Location = new System.Drawing.Point(29, 34);
            this.nudCantidadProductos.Margin = new System.Windows.Forms.Padding(4);
            this.nudCantidadProductos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadProductos.Name = "nudCantidadProductos";
            this.nudCantidadProductos.Size = new System.Drawing.Size(88, 22);
            this.nudCantidadProductos.TabIndex = 0;
            this.nudCantidadProductos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gpbVentas
            // 
            this.gpbVentas.Controls.Add(this.btnVender);
            this.gpbVentas.Controls.Add(this.btnCancelar);
            this.gpbVentas.Location = new System.Drawing.Point(599, 328);
            this.gpbVentas.Margin = new System.Windows.Forms.Padding(4);
            this.gpbVentas.Name = "gpbVentas";
            this.gpbVentas.Padding = new System.Windows.Forms.Padding(4);
            this.gpbVentas.Size = new System.Drawing.Size(412, 123);
            this.gpbVentas.TabIndex = 2;
            this.gpbVentas.TabStop = false;
            this.gpbVentas.Text = "Ventas";
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(304, 52);
            this.btnVender.Margin = new System.Windows.Forms.Padding(4);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(100, 28);
            this.btnVender.TabIndex = 1;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(40, 52);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // msBarra
            // 
            this.msBarra.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msBarra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.reporteToolStripMenuItem});
            this.msBarra.Location = new System.Drawing.Point(0, 0);
            this.msBarra.Name = "msBarra";
            this.msBarra.Size = new System.Drawing.Size(1067, 28);
            this.msBarra.TabIndex = 3;
            this.msBarra.Text = "menuStrip1";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // reporteToolStripMenuItem
            // 
            this.reporteToolStripMenuItem.Name = "reporteToolStripMenuItem";
            this.reporteToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.reporteToolStripMenuItem.Text = "Reporte";
            this.reporteToolStripMenuItem.Click += new System.EventHandler(this.reporteToolStripMenuItem_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(652, 271);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(87, 17);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Monto Total:";
            // 
            // lblMontoTotalVenta
            // 
            this.lblMontoTotalVenta.AutoSize = true;
            this.lblMontoTotalVenta.Location = new System.Drawing.Point(792, 271);
            this.lblMontoTotalVenta.Name = "lblMontoTotalVenta";
            this.lblMontoTotalVenta.Size = new System.Drawing.Size(0, 17);
            this.lblMontoTotalVenta.TabIndex = 5;
            // 
            // VentasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 484);
            this.Controls.Add(this.lblMontoTotalVenta);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.gpbVentas);
            this.Controls.Add(this.gpbProductos);
            this.Controls.Add(this.dgvVenta);
            this.Controls.Add(this.msBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.msBarra;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VentasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistemas de Ventas";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VentasForm_MouseMove);
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
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMontoTotalVenta;
    }
}