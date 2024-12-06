namespace BunBunHub.Formularios
{
    partial class ListaClientes
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
            this.tlsRegistrarPedido = new System.Windows.Forms.ToolStrip();
            this.btnSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.grpClientes = new System.Windows.Forms.GroupBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.tlsRegistrarPedido.SuspendLayout();
            this.grpClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsRegistrarPedido
            // 
            this.tlsRegistrarPedido.AllowDrop = true;
            this.tlsRegistrarPedido.AutoSize = false;
            this.tlsRegistrarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.tlsRegistrarPedido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlsRegistrarPedido.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsRegistrarPedido.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsRegistrarPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSeleccionar,
            this.btnCancelar});
            this.tlsRegistrarPedido.Location = new System.Drawing.Point(0, 436);
            this.tlsRegistrarPedido.Name = "tlsRegistrarPedido";
            this.tlsRegistrarPedido.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tlsRegistrarPedido.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tlsRegistrarPedido.Size = new System.Drawing.Size(329, 57);
            this.tlsRegistrarPedido.TabIndex = 116;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.AutoSize = false;
            this.btnSeleccionar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSeleccionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSeleccionar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSeleccionar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(10, 12, 15, 12);
            this.btnSeleccionar.MergeIndex = 0;
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(110, 37);
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.ToolTipText = "Seleccionar cliente";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.BackColor = System.Drawing.Color.RosyBrown;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 37);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ToolTipText = "Cancelar selección";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grpClientes
            // 
            this.grpClientes.Controls.Add(this.dgvClientes);
            this.grpClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.grpClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.grpClientes.Location = new System.Drawing.Point(16, 11);
            this.grpClientes.Margin = new System.Windows.Forms.Padding(7, 2, 3, 7);
            this.grpClientes.Name = "grpClientes";
            this.grpClientes.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpClientes.Size = new System.Drawing.Size(301, 412);
            this.grpClientes.TabIndex = 117;
            this.grpClientes.TabStop = false;
            this.grpClientes.Text = "Clientes BunBunHub";
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.EnableHeadersVisualStyles = false;
            this.dgvClientes.Location = new System.Drawing.Point(6, 20);
            this.dgvClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.RowTemplate.Height = 24;
            this.dgvClientes.Size = new System.Drawing.Size(289, 388);
            this.dgvClientes.TabIndex = 15;
            // 
            // ListaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::BunBunHub.Properties.Resources.FondoLisoTeal;
            this.ClientSize = new System.Drawing.Size(329, 493);
            this.Controls.Add(this.grpClientes);
            this.Controls.Add(this.tlsRegistrarPedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListaClientes";
            this.Load += new System.EventHandler(this.ListaClientes_Load);
            this.tlsRegistrarPedido.ResumeLayout(false);
            this.tlsRegistrarPedido.PerformLayout();
            this.grpClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsRegistrarPedido;
        private System.Windows.Forms.ToolStripButton btnSeleccionar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.GroupBox grpClientes;
        private System.Windows.Forms.DataGridView dgvClientes;
    }
}