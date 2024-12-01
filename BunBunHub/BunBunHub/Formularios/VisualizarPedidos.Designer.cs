namespace BunBunHub.Formularios
{
    partial class VisualizarPedidos
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
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.grbEdIdentificacionPedido = new System.Windows.Forms.GroupBox();
            this.txtEdUsuarioCliente = new System.Windows.Forms.TextBox();
            this.dtpEdFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.txtEdID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbEdDetallesPedido = new System.Windows.Forms.GroupBox();
            this.cmbEdPuntoEntrega = new System.Windows.Forms.ComboBox();
            this.cmbEdEstado = new System.Windows.Forms.ComboBox();
            this.txtEdCostoMaterial = new System.Windows.Forms.TextBox();
            this.txtEdCostoCompra = new System.Windows.Forms.TextBox();
            this.txtEdUsuarioColaborador = new System.Windows.Forms.TextBox();
            this.txtEdDescripcion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEditarPedido = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.grbEdIdentificacionPedido.SuspendLayout();
            this.grbEdDetallesPedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(40, 12);
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(447, 431);
            this.dgvPedidos.TabIndex = 0;
            this.dgvPedidos.SelectionChanged += new System.EventHandler(this.dgvPedidos_SelectionChanged);
            // 
            // btnCerrarSistema
            // 
            this.btnCerrarSistema.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSistema.BackgroundImage = global::BunBunHub.Properties.Resources.CerrarSistemaCeleste;
            this.btnCerrarSistema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSistema.FlatAppearance.BorderSize = 0;
            this.btnCerrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSistema.Location = new System.Drawing.Point(774, 12);
            this.btnCerrarSistema.Name = "btnCerrarSistema";
            this.btnCerrarSistema.Size = new System.Drawing.Size(24, 24);
            this.btnCerrarSistema.TabIndex = 118;
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Transparent;
            this.btnVolver.BackgroundImage = global::BunBunHub.Properties.Resources.VolverBeige;
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(12, 473);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(34, 33);
            this.btnVolver.TabIndex = 134;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(512, 457);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 47);
            this.btnEliminar.TabIndex = 135;
            this.btnEliminar.Text = "Eliminar pedido";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // grbEdIdentificacionPedido
            // 
            this.grbEdIdentificacionPedido.Controls.Add(this.txtEdUsuarioCliente);
            this.grbEdIdentificacionPedido.Controls.Add(this.dtpEdFechaCompra);
            this.grbEdIdentificacionPedido.Controls.Add(this.txtEdID);
            this.grbEdIdentificacionPedido.Controls.Add(this.label3);
            this.grbEdIdentificacionPedido.Controls.Add(this.label2);
            this.grbEdIdentificacionPedido.Controls.Add(this.label1);
            this.grbEdIdentificacionPedido.Location = new System.Drawing.Point(512, 56);
            this.grbEdIdentificacionPedido.Name = "grbEdIdentificacionPedido";
            this.grbEdIdentificacionPedido.Size = new System.Drawing.Size(286, 136);
            this.grbEdIdentificacionPedido.TabIndex = 136;
            this.grbEdIdentificacionPedido.TabStop = false;
            this.grbEdIdentificacionPedido.Text = "Identificación del pedido";
            // 
            // txtEdUsuarioCliente
            // 
            this.txtEdUsuarioCliente.Location = new System.Drawing.Point(80, 99);
            this.txtEdUsuarioCliente.Name = "txtEdUsuarioCliente";
            this.txtEdUsuarioCliente.Size = new System.Drawing.Size(121, 20);
            this.txtEdUsuarioCliente.TabIndex = 5;
            // 
            // dtpEdFechaCompra
            // 
            this.dtpEdFechaCompra.Location = new System.Drawing.Point(80, 64);
            this.dtpEdFechaCompra.Name = "dtpEdFechaCompra";
            this.dtpEdFechaCompra.Size = new System.Drawing.Size(200, 20);
            this.dtpEdFechaCompra.TabIndex = 4;
            // 
            // txtEdID
            // 
            this.txtEdID.Location = new System.Drawing.Point(44, 24);
            this.txtEdID.Name = "txtEdID";
            this.txtEdID.Size = new System.Drawing.Size(157, 20);
            this.txtEdID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario \r\nde cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha\r\nde compra:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // grbEdDetallesPedido
            // 
            this.grbEdDetallesPedido.Controls.Add(this.cmbEdPuntoEntrega);
            this.grbEdDetallesPedido.Controls.Add(this.cmbEdEstado);
            this.grbEdDetallesPedido.Controls.Add(this.txtEdCostoMaterial);
            this.grbEdDetallesPedido.Controls.Add(this.txtEdCostoCompra);
            this.grbEdDetallesPedido.Controls.Add(this.txtEdUsuarioColaborador);
            this.grbEdDetallesPedido.Controls.Add(this.txtEdDescripcion);
            this.grbEdDetallesPedido.Controls.Add(this.label9);
            this.grbEdDetallesPedido.Controls.Add(this.label8);
            this.grbEdDetallesPedido.Controls.Add(this.label7);
            this.grbEdDetallesPedido.Controls.Add(this.label6);
            this.grbEdDetallesPedido.Controls.Add(this.label5);
            this.grbEdDetallesPedido.Controls.Add(this.label4);
            this.grbEdDetallesPedido.Location = new System.Drawing.Point(512, 211);
            this.grbEdDetallesPedido.Name = "grbEdDetallesPedido";
            this.grbEdDetallesPedido.Size = new System.Drawing.Size(286, 221);
            this.grbEdDetallesPedido.TabIndex = 137;
            this.grbEdDetallesPedido.TabStop = false;
            this.grbEdDetallesPedido.Text = "Detalles del pedido";
            // 
            // cmbEdPuntoEntrega
            // 
            this.cmbEdPuntoEntrega.FormattingEnabled = true;
            this.cmbEdPuntoEntrega.Items.AddRange(new object[] {
            "Metrocentro",
            "Plaza Naturas"});
            this.cmbEdPuntoEntrega.Location = new System.Drawing.Point(119, 54);
            this.cmbEdPuntoEntrega.Name = "cmbEdPuntoEntrega";
            this.cmbEdPuntoEntrega.Size = new System.Drawing.Size(139, 21);
            this.cmbEdPuntoEntrega.TabIndex = 11;
            // 
            // cmbEdEstado
            // 
            this.cmbEdEstado.FormattingEnabled = true;
            this.cmbEdEstado.Items.AddRange(new object[] {
            "Recibido",
            "En proceso",
            "Listo para entrega",
            "Completado",
            "Cancelado"});
            this.cmbEdEstado.Location = new System.Drawing.Point(70, 28);
            this.cmbEdEstado.Name = "cmbEdEstado";
            this.cmbEdEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbEdEstado.TabIndex = 10;
            // 
            // txtEdCostoMaterial
            // 
            this.txtEdCostoMaterial.Location = new System.Drawing.Point(117, 187);
            this.txtEdCostoMaterial.Name = "txtEdCostoMaterial";
            this.txtEdCostoMaterial.Size = new System.Drawing.Size(141, 20);
            this.txtEdCostoMaterial.TabIndex = 9;
            // 
            // txtEdCostoCompra
            // 
            this.txtEdCostoCompra.Location = new System.Drawing.Point(117, 155);
            this.txtEdCostoCompra.Name = "txtEdCostoCompra";
            this.txtEdCostoCompra.Size = new System.Drawing.Size(141, 20);
            this.txtEdCostoCompra.TabIndex = 8;
            // 
            // txtEdUsuarioColaborador
            // 
            this.txtEdUsuarioColaborador.Location = new System.Drawing.Point(108, 124);
            this.txtEdUsuarioColaborador.Name = "txtEdUsuarioColaborador";
            this.txtEdUsuarioColaborador.Size = new System.Drawing.Size(150, 20);
            this.txtEdUsuarioColaborador.TabIndex = 7;
            // 
            // txtEdDescripcion
            // 
            this.txtEdDescripcion.Location = new System.Drawing.Point(93, 86);
            this.txtEdDescripcion.Name = "txtEdDescripcion";
            this.txtEdDescripcion.Size = new System.Drawing.Size(165, 20);
            this.txtEdDescripcion.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Costo de material:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Costo de compra:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 26);
            this.label7.TabIndex = 3;
            this.label7.Text = "Usuario\r\nde colaborador:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Descripción:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Punto de entrega:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Estado:";
            // 
            // btnEditarPedido
            // 
            this.btnEditarPedido.Location = new System.Drawing.Point(610, 457);
            this.btnEditarPedido.Name = "btnEditarPedido";
            this.btnEditarPedido.Size = new System.Drawing.Size(93, 47);
            this.btnEditarPedido.TabIndex = 138;
            this.btnEditarPedido.Text = "Editar pedido";
            this.btnEditarPedido.UseVisualStyleBackColor = true;
            this.btnEditarPedido.Click += new System.EventHandler(this.btnEditarPedido_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(709, 457);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(89, 47);
            this.btnGuardarCambios.TabIndex = 139;
            this.btnGuardarCambios.Text = "Guardar cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // VisualizarPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BunBunHub.Properties.Resources.FondoLisoTeal;
            this.ClientSize = new System.Drawing.Size(810, 518);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.btnEditarPedido);
            this.Controls.Add(this.grbEdDetallesPedido);
            this.Controls.Add(this.grbEdIdentificacionPedido);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCerrarSistema);
            this.Controls.Add(this.dgvPedidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisualizarPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisualizarPedidos";
            this.Load += new System.EventHandler(this.VisualizarPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.grbEdIdentificacionPedido.ResumeLayout(false);
            this.grbEdIdentificacionPedido.PerformLayout();
            this.grbEdDetallesPedido.ResumeLayout(false);
            this.grbEdDetallesPedido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Button btnCerrarSistema;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox grbEdIdentificacionPedido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEdUsuarioCliente;
        private System.Windows.Forms.DateTimePicker dtpEdFechaCompra;
        private System.Windows.Forms.TextBox txtEdID;
        private System.Windows.Forms.GroupBox grbEdDetallesPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbEdPuntoEntrega;
        private System.Windows.Forms.ComboBox cmbEdEstado;
        private System.Windows.Forms.TextBox txtEdCostoMaterial;
        private System.Windows.Forms.TextBox txtEdCostoCompra;
        private System.Windows.Forms.TextBox txtEdUsuarioColaborador;
        private System.Windows.Forms.TextBox txtEdDescripcion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditarPedido;
        private System.Windows.Forms.Button btnGuardarCambios;
    }
}