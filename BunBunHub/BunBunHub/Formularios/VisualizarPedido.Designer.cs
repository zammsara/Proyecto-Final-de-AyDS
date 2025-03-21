﻿namespace BunBunHub.Formularios
{
    partial class VisualizarPedido
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
            this.DatosPedido = new System.Windows.Forms.GroupBox();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.cmbPuntoEntrega = new System.Windows.Forms.ComboBox();
            this.lblPuntoEntrega = new System.Windows.Forms.Label();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.dtpFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCompra = new System.Windows.Forms.Label();
            this.txtIDPedido = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.grpDatosCliente = new System.Windows.Forms.GroupBox();
            this.grpContacto = new System.Windows.Forms.GroupBox();
            this.lblValidarCorreo = new System.Windows.Forms.Label();
            this.lblValidarTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.DatosPedido.SuspendLayout();
            this.grpDatosCliente.SuspendLayout();
            this.grpContacto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // DatosPedido
            // 
            this.DatosPedido.BackColor = System.Drawing.Color.Transparent;
            this.DatosPedido.Controls.Add(this.txtMontoTotal);
            this.DatosPedido.Controls.Add(this.txtEstado);
            this.DatosPedido.Controls.Add(this.lblEstado);
            this.DatosPedido.Controls.Add(this.txtDescripcion);
            this.DatosPedido.Controls.Add(this.lblDescripcion);
            this.DatosPedido.Controls.Add(this.cmbPuntoEntrega);
            this.DatosPedido.Controls.Add(this.lblPuntoEntrega);
            this.DatosPedido.Controls.Add(this.lblMontoTotal);
            this.DatosPedido.Controls.Add(this.dtpFechaCompra);
            this.DatosPedido.Controls.Add(this.lblFechaCompra);
            this.DatosPedido.Controls.Add(this.txtIDPedido);
            this.DatosPedido.Controls.Add(this.lblID);
            this.DatosPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.DatosPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.DatosPedido.Location = new System.Drawing.Point(394, 110);
            this.DatosPedido.Name = "DatosPedido";
            this.DatosPedido.Size = new System.Drawing.Size(329, 318);
            this.DatosPedido.TabIndex = 160;
            this.DatosPedido.TabStop = false;
            this.DatosPedido.Text = "Datos del Pedido";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Enabled = false;
            this.txtMontoTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMontoTotal.ForeColor = System.Drawing.Color.Black;
            this.txtMontoTotal.Location = new System.Drawing.Point(208, 272);
            this.txtMontoTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(101, 27);
            this.txtMontoTotal.TabIndex = 153;
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(24, 272);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(4);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(146, 27);
            this.txtEstado.TabIndex = 126;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(24, 251);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(50, 19);
            this.lblEstado.TabIndex = 152;
            this.lblEstado.Text = "Estado";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescripcion.Location = new System.Drawing.Point(24, 171);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(285, 65);
            this.txtDescripcion.TabIndex = 151;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(22, 148);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(83, 19);
            this.lblDescripcion.TabIndex = 150;
            this.lblDescripcion.Text = "Descripción";
            // 
            // cmbPuntoEntrega
            // 
            this.cmbPuntoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuntoEntrega.Enabled = false;
            this.cmbPuntoEntrega.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPuntoEntrega.FormattingEnabled = true;
            this.cmbPuntoEntrega.Items.AddRange(new object[] {
            "Metrocentro",
            "Plaza Naturas"});
            this.cmbPuntoEntrega.Location = new System.Drawing.Point(24, 117);
            this.cmbPuntoEntrega.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPuntoEntrega.Name = "cmbPuntoEntrega";
            this.cmbPuntoEntrega.Size = new System.Drawing.Size(285, 28);
            this.cmbPuntoEntrega.TabIndex = 149;
            // 
            // lblPuntoEntrega
            // 
            this.lblPuntoEntrega.AutoSize = true;
            this.lblPuntoEntrega.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntoEntrega.Location = new System.Drawing.Point(24, 94);
            this.lblPuntoEntrega.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPuntoEntrega.Name = "lblPuntoEntrega";
            this.lblPuntoEntrega.Size = new System.Drawing.Size(116, 19);
            this.lblPuntoEntrega.TabIndex = 148;
            this.lblPuntoEntrega.Text = "Punto de entrega";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(204, 251);
            this.lblMontoTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(86, 19);
            this.lblMontoTotal.TabIndex = 142;
            this.lblMontoTotal.Text = "Monto Total";
            // 
            // dtpFechaCompra
            // 
            this.dtpFechaCompra.Enabled = false;
            this.dtpFechaCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCompra.Location = new System.Drawing.Point(148, 53);
            this.dtpFechaCompra.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaCompra.Name = "dtpFechaCompra";
            this.dtpFechaCompra.Size = new System.Drawing.Size(132, 26);
            this.dtpFechaCompra.TabIndex = 141;
            this.dtpFechaCompra.Value = new System.DateTime(2024, 12, 3, 0, 0, 0, 0);
            // 
            // lblFechaCompra
            // 
            this.lblFechaCompra.AutoSize = true;
            this.lblFechaCompra.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCompra.Location = new System.Drawing.Point(144, 30);
            this.lblFechaCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaCompra.Name = "lblFechaCompra";
            this.lblFechaCompra.Size = new System.Drawing.Size(115, 19);
            this.lblFechaCompra.TabIndex = 140;
            this.lblFechaCompra.Text = "Fecha de compra";
            // 
            // txtIDPedido
            // 
            this.txtIDPedido.Enabled = false;
            this.txtIDPedido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDPedido.Location = new System.Drawing.Point(24, 52);
            this.txtIDPedido.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDPedido.Name = "txtIDPedido";
            this.txtIDPedido.ReadOnly = true;
            this.txtIDPedido.Size = new System.Drawing.Size(101, 27);
            this.txtIDPedido.TabIndex = 131;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(24, 29);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(23, 19);
            this.lblID.TabIndex = 130;
            this.lblID.Text = "ID";
            // 
            // grpDatosCliente
            // 
            this.grpDatosCliente.BackColor = System.Drawing.Color.Transparent;
            this.grpDatosCliente.Controls.Add(this.grpContacto);
            this.grpDatosCliente.Controls.Add(this.txtEdad);
            this.grpDatosCliente.Controls.Add(this.txtApellido);
            this.grpDatosCliente.Controls.Add(this.txtNombre);
            this.grpDatosCliente.Controls.Add(this.lblEdad);
            this.grpDatosCliente.Controls.Add(this.lblApellido);
            this.grpDatosCliente.Controls.Add(this.lblNombre);
            this.grpDatosCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.grpDatosCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.grpDatosCliente.Location = new System.Drawing.Point(24, 110);
            this.grpDatosCliente.Margin = new System.Windows.Forms.Padding(4);
            this.grpDatosCliente.Name = "grpDatosCliente";
            this.grpDatosCliente.Padding = new System.Windows.Forms.Padding(4);
            this.grpDatosCliente.Size = new System.Drawing.Size(324, 318);
            this.grpDatosCliente.TabIndex = 154;
            this.grpDatosCliente.TabStop = false;
            this.grpDatosCliente.Text = "Información Personal";
            // 
            // grpContacto
            // 
            this.grpContacto.BackColor = System.Drawing.Color.Transparent;
            this.grpContacto.Controls.Add(this.lblValidarCorreo);
            this.grpContacto.Controls.Add(this.lblValidarTelefono);
            this.grpContacto.Controls.Add(this.txtTelefono);
            this.grpContacto.Controls.Add(this.txtCorreo);
            this.grpContacto.Controls.Add(this.lblTelefono);
            this.grpContacto.Controls.Add(this.lblCorreo);
            this.grpContacto.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.grpContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.grpContacto.Location = new System.Drawing.Point(21, 130);
            this.grpContacto.Margin = new System.Windows.Forms.Padding(4);
            this.grpContacto.Name = "grpContacto";
            this.grpContacto.Padding = new System.Windows.Forms.Padding(4);
            this.grpContacto.Size = new System.Drawing.Size(288, 169);
            this.grpContacto.TabIndex = 125;
            this.grpContacto.TabStop = false;
            this.grpContacto.Text = "Contacto";
            // 
            // lblValidarCorreo
            // 
            this.lblValidarCorreo.AutoSize = true;
            this.lblValidarCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblValidarCorreo.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidarCorreo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblValidarCorreo.Location = new System.Drawing.Point(8, 73);
            this.lblValidarCorreo.Name = "lblValidarCorreo";
            this.lblValidarCorreo.Size = new System.Drawing.Size(0, 15);
            this.lblValidarCorreo.TabIndex = 47;
            // 
            // lblValidarTelefono
            // 
            this.lblValidarTelefono.AutoSize = true;
            this.lblValidarTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblValidarTelefono.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidarTelefono.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblValidarTelefono.Location = new System.Drawing.Point(8, 142);
            this.lblValidarTelefono.Name = "lblValidarTelefono";
            this.lblValidarTelefono.Size = new System.Drawing.Size(0, 15);
            this.lblValidarTelefono.TabIndex = 46;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefono.Location = new System.Drawing.Point(8, 111);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(174, 27);
            this.txtTelefono.TabIndex = 3;
            this.txtTelefono.Click += new System.EventHandler(this.seleccionar_enter);
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros_KeyPress);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Enabled = false;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCorreo.Location = new System.Drawing.Point(8, 42);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.ReadOnly = true;
            this.txtCorreo.Size = new System.Drawing.Size(256, 27);
            this.txtCorreo.TabIndex = 2;
            this.txtCorreo.Click += new System.EventHandler(this.seleccionar_enter);
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.lblTelefono.Location = new System.Drawing.Point(8, 89);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(59, 17);
            this.lblTelefono.TabIndex = 1;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.lblCorreo.Location = new System.Drawing.Point(5, 21);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(49, 17);
            this.lblCorreo.TabIndex = 0;
            this.lblCorreo.Text = "Correo";
            // 
            // txtEdad
            // 
            this.txtEdad.Enabled = false;
            this.txtEdad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEdad.ForeColor = System.Drawing.Color.Black;
            this.txtEdad.Location = new System.Drawing.Point(183, 43);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(4);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.ReadOnly = true;
            this.txtEdad.Size = new System.Drawing.Size(76, 27);
            this.txtEdad.TabIndex = 38;
            this.txtEdad.Click += new System.EventHandler(this.seleccionar_enter);
            this.txtEdad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtApellido.ForeColor = System.Drawing.Color.Black;
            this.txtApellido.Location = new System.Drawing.Point(18, 95);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ReadOnly = true;
            this.txtApellido.Size = new System.Drawing.Size(149, 27);
            this.txtApellido.TabIndex = 37;
            this.txtApellido.Click += new System.EventHandler(this.seleccionar_enter);
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.letrasEspacios_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(20, 43);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(149, 27);
            this.txtNombre.TabIndex = 36;
            this.txtNombre.Click += new System.EventHandler(this.seleccionar_enter);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras_KeyPress);
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblEdad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.lblEdad.Location = new System.Drawing.Point(180, 23);
            this.lblEdad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(38, 17);
            this.lblEdad.TabIndex = 4;
            this.lblEdad.Text = "Edad";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.lblApellido.Location = new System.Drawing.Point(18, 74);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(57, 17);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.lblNombre.Location = new System.Drawing.Point(17, 22);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // lblEncabezado
            // 
            this.lblEncabezado.AutoSize = true;
            this.lblEncabezado.BackColor = System.Drawing.Color.Transparent;
            this.lblEncabezado.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezado.ForeColor = System.Drawing.Color.SeaShell;
            this.lblEncabezado.Location = new System.Drawing.Point(226, 29);
            this.lblEncabezado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Size = new System.Drawing.Size(283, 32);
            this.lblEncabezado.TabIndex = 159;
            this.lblEncabezado.Text = "Información del Pedido";
            // 
            // btnCerrarSistema
            // 
            this.btnCerrarSistema.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSistema.BackgroundImage = global::BunBunHub.Properties.Resources.CerrarBlanco;
            this.btnCerrarSistema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSistema.FlatAppearance.BorderSize = 0;
            this.btnCerrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSistema.Location = new System.Drawing.Point(685, 29);
            this.btnCerrarSistema.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrarSistema.Name = "btnCerrarSistema";
            this.btnCerrarSistema.Size = new System.Drawing.Size(38, 42);
            this.btnCerrarSistema.TabIndex = 158;
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.BackColor = System.Drawing.Color.RosyBrown;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(24, 436);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 32);
            this.btnCancelar.TabIndex = 157;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(250, 436);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 32);
            this.btnGuardar.TabIndex = 156;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.AutoSize = true;
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.Location = new System.Drawing.Point(144, 436);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(98, 32);
            this.btnActualizar.TabIndex = 155;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.ForeColor = System.Drawing.Color.SeaShell;
            this.lblBienvenido.Location = new System.Drawing.Point(195, 61);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(360, 20);
            this.lblBienvenido.TabIndex = 161;
            this.lblBienvenido.Text = "¡Tu pedido ya está con nosotros, espéralo con ansias!";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImage = global::BunBunHub.Properties.Resources.LogoBeige;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogo.Location = new System.Drawing.Point(24, 20);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(75, 61);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 162;
            this.picLogo.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(482, 435);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(171, 32);
            this.btnEliminar.TabIndex = 163;
            this.btnEliminar.Text = "Cancelar Pedido";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // VisualizarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BunBunHub.Properties.Resources.miniPaneles;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(752, 489);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.DatosPedido);
            this.Controls.Add(this.grpDatosCliente);
            this.Controls.Add(this.lblEncabezado);
            this.Controls.Add(this.btnCerrarSistema);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnActualizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisualizarPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisualizarPedido";
            this.Load += new System.EventHandler(this.VisualizarPedido_Load);
            this.DatosPedido.ResumeLayout(false);
            this.DatosPedido.PerformLayout();
            this.grpDatosCliente.ResumeLayout(false);
            this.grpDatosCliente.PerformLayout();
            this.grpContacto.ResumeLayout(false);
            this.grpContacto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox DatosPedido;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.ComboBox cmbPuntoEntrega;
        private System.Windows.Forms.Label lblPuntoEntrega;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.Label lblFechaCompra;
        private System.Windows.Forms.TextBox txtIDPedido;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.GroupBox grpDatosCliente;
        private System.Windows.Forms.GroupBox grpContacto;
        private System.Windows.Forms.Label lblValidarCorreo;
        private System.Windows.Forms.Label lblValidarTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Button btnCerrarSistema;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnEliminar;
    }
}