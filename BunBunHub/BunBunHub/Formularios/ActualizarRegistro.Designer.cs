namespace BunBunHub.Formularios
{
    partial class ActualizarRegistro
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
            this.tabControlRegistros = new System.Windows.Forms.TabControl();
            this.tabPageUsuariosSistema = new System.Windows.Forms.TabPage();
            this.grpCredenciales = new System.Windows.Forms.GroupBox();
            this.lblConfirmación = new System.Windows.Forms.Label();
            this.lblValidacion = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsuarioNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tlsUsuarios = new System.Windows.Forms.ToolStrip();
            this.tlsbtnVolver = new System.Windows.Forms.ToolStripButton();
            this.tlsbtnHome = new System.Windows.Forms.ToolStripButton();
            this.grpHistorialUsuarios = new System.Windows.Forms.GroupBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.tabPageClientes = new System.Windows.Forms.TabPage();
            this.tlsClientes = new System.Windows.Forms.ToolStrip();
            this.tlsVolverBtn = new System.Windows.Forms.ToolStripButton();
            this.tlsHomeBtn = new System.Windows.Forms.ToolStripButton();
            this.grpContacto = new System.Windows.Forms.GroupBox();
            this.lblValidarTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grpDatosCliente = new System.Windows.Forms.GroupBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.grpHistorialClientes = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            this.lblBunBunHub = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlRegistros.SuspendLayout();
            this.tabPageUsuariosSistema.SuspendLayout();
            this.grpCredenciales.SuspendLayout();
            this.tlsUsuarios.SuspendLayout();
            this.grpHistorialUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tabPageClientes.SuspendLayout();
            this.tlsClientes.SuspendLayout();
            this.grpContacto.SuspendLayout();
            this.grpDatosCliente.SuspendLayout();
            this.grpHistorialClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlRegistros
            // 
            this.tabControlRegistros.Controls.Add(this.tabPageUsuariosSistema);
            this.tabControlRegistros.Controls.Add(this.tabPageClientes);
            this.tabControlRegistros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlRegistros.Location = new System.Drawing.Point(1, 71);
            this.tabControlRegistros.Multiline = true;
            this.tabControlRegistros.Name = "tabControlRegistros";
            this.tabControlRegistros.SelectedIndex = 0;
            this.tabControlRegistros.ShowToolTips = true;
            this.tabControlRegistros.Size = new System.Drawing.Size(1076, 564);
            this.tabControlRegistros.TabIndex = 0;
            // 
            // tabPageUsuariosSistema
            // 
            this.tabPageUsuariosSistema.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPageUsuariosSistema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageUsuariosSistema.Controls.Add(this.grpCredenciales);
            this.tabPageUsuariosSistema.Controls.Add(this.tlsUsuarios);
            this.tabPageUsuariosSistema.Controls.Add(this.grpHistorialUsuarios);
            this.tabPageUsuariosSistema.Location = new System.Drawing.Point(4, 29);
            this.tabPageUsuariosSistema.Name = "tabPageUsuariosSistema";
            this.tabPageUsuariosSistema.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsuariosSistema.Size = new System.Drawing.Size(1068, 531);
            this.tabPageUsuariosSistema.TabIndex = 0;
            this.tabPageUsuariosSistema.Text = "Usuarios";
            // 
            // grpCredenciales
            // 
            this.grpCredenciales.BackColor = System.Drawing.Color.Transparent;
            this.grpCredenciales.Controls.Add(this.lblConfirmación);
            this.grpCredenciales.Controls.Add(this.lblValidacion);
            this.grpCredenciales.Controls.Add(this.cmbEstado);
            this.grpCredenciales.Controls.Add(this.cmbRol);
            this.grpCredenciales.Controls.Add(this.label2);
            this.grpCredenciales.Controls.Add(this.label3);
            this.grpCredenciales.Controls.Add(this.txtConfirmarContraseña);
            this.grpCredenciales.Controls.Add(this.txtContraseña);
            this.grpCredenciales.Controls.Add(this.label9);
            this.grpCredenciales.Controls.Add(this.label8);
            this.grpCredenciales.Controls.Add(this.txtUsuarioNombre);
            this.grpCredenciales.Controls.Add(this.label7);
            this.grpCredenciales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpCredenciales.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.grpCredenciales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.grpCredenciales.Location = new System.Drawing.Point(616, 86);
            this.grpCredenciales.Name = "grpCredenciales";
            this.grpCredenciales.Size = new System.Drawing.Size(342, 313);
            this.grpCredenciales.TabIndex = 122;
            this.grpCredenciales.TabStop = false;
            this.grpCredenciales.Text = "Credenciales de Acceso";
            // 
            // lblConfirmación
            // 
            this.lblConfirmación.AutoSize = true;
            this.lblConfirmación.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmación.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblConfirmación.Location = new System.Drawing.Point(20, 219);
            this.lblConfirmación.Name = "lblConfirmación";
            this.lblConfirmación.Size = new System.Drawing.Size(0, 15);
            this.lblConfirmación.TabIndex = 45;
            // 
            // lblValidacion
            // 
            this.lblValidacion.AutoSize = true;
            this.lblValidacion.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblValidacion.Location = new System.Drawing.Point(20, 140);
            this.lblValidacion.Name = "lblValidacion";
            this.lblValidacion.Size = new System.Drawing.Size(0, 15);
            this.lblValidacion.TabIndex = 44;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEstado.ForeColor = System.Drawing.Color.Black;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inhabilitado"});
            this.cmbEstado.Location = new System.Drawing.Point(181, 269);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(142, 28);
            this.cmbEstado.TabIndex = 43;
            // 
            // cmbRol
            // 
            this.cmbRol.Enabled = false;
            this.cmbRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbRol.ForeColor = System.Drawing.Color.Black;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] {
            "Administrador",
            "Colaborador",
            "Cliente"});
            this.cmbRol.Location = new System.Drawing.Point(19, 269);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(144, 28);
            this.cmbRol.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(178, 249);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 41;
            this.label2.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 249);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 17);
            this.label3.TabIndex = 40;
            this.label3.Text = "Rol";
            // 
            // txtConfirmarContraseña
            // 
            this.txtConfirmarContraseña.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConfirmarContraseña.ForeColor = System.Drawing.Color.Black;
            this.txtConfirmarContraseña.Location = new System.Drawing.Point(19, 191);
            this.txtConfirmarContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            this.txtConfirmarContraseña.Size = new System.Drawing.Size(219, 27);
            this.txtConfirmarContraseña.TabIndex = 39;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtContraseña.ForeColor = System.Drawing.Color.Black;
            this.txtContraseña.Location = new System.Drawing.Point(19, 113);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(219, 27);
            this.txtContraseña.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(16, 170);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 17);
            this.label9.TabIndex = 38;
            this.label9.Text = "Confirmar Contraseña";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(16, 92);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 36;
            this.label8.Text = "Contraseña:";
            // 
            // txtUsuarioNombre
            // 
            this.txtUsuarioNombre.Enabled = false;
            this.txtUsuarioNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsuarioNombre.ForeColor = System.Drawing.Color.Black;
            this.txtUsuarioNombre.Location = new System.Drawing.Point(19, 48);
            this.txtUsuarioNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuarioNombre.Name = "txtUsuarioNombre";
            this.txtUsuarioNombre.Size = new System.Drawing.Size(219, 27);
            this.txtUsuarioNombre.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(16, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "Usuario";
            // 
            // tlsUsuarios
            // 
            this.tlsUsuarios.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsUsuarios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsbtnVolver,
            this.tlsbtnHome});
            this.tlsUsuarios.Location = new System.Drawing.Point(3, 3);
            this.tlsUsuarios.Name = "tlsUsuarios";
            this.tlsUsuarios.Size = new System.Drawing.Size(1058, 27);
            this.tlsUsuarios.TabIndex = 1;
            this.tlsUsuarios.Text = "toolStrip1";
            // 
            // tlsbtnVolver
            // 
            this.tlsbtnVolver.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsbtnVolver.Image = global::BunBunHub.Properties.Resources.VolverAzul;
            this.tlsbtnVolver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbtnVolver.Name = "tlsbtnVolver";
            this.tlsbtnVolver.Size = new System.Drawing.Size(29, 24);
            this.tlsbtnVolver.Text = "toolStripButton1";
            this.tlsbtnVolver.Click += new System.EventHandler(this.tlsbtnVolver_Click);
            // 
            // tlsbtnHome
            // 
            this.tlsbtnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsbtnHome.Image = global::BunBunHub.Properties.Resources.HomeAzul;
            this.tlsbtnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbtnHome.Name = "tlsbtnHome";
            this.tlsbtnHome.Size = new System.Drawing.Size(29, 24);
            this.tlsbtnHome.Text = "toolStripButton2";
            this.tlsbtnHome.Click += new System.EventHandler(this.tlsbtnHome_Click);
            // 
            // grpHistorialUsuarios
            // 
            this.grpHistorialUsuarios.Controls.Add(this.dgvUsuarios);
            this.grpHistorialUsuarios.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.grpHistorialUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.grpHistorialUsuarios.Location = new System.Drawing.Point(6, 60);
            this.grpHistorialUsuarios.Name = "grpHistorialUsuarios";
            this.grpHistorialUsuarios.Size = new System.Drawing.Size(498, 461);
            this.grpHistorialUsuarios.TabIndex = 0;
            this.grpHistorialUsuarios.TabStop = false;
            this.grpHistorialUsuarios.Text = "Historial de Usuarios";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(14, 26);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.RowTemplate.Height = 24;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(468, 420);
            this.dgvUsuarios.TabIndex = 1;
            // 
            // tabPageClientes
            // 
            this.tabPageClientes.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPageClientes.Controls.Add(this.tlsClientes);
            this.tabPageClientes.Controls.Add(this.grpContacto);
            this.tabPageClientes.Controls.Add(this.comboBox1);
            this.tabPageClientes.Controls.Add(this.grpDatosCliente);
            this.tabPageClientes.Controls.Add(this.label12);
            this.tabPageClientes.Controls.Add(this.grpHistorialClientes);
            this.tabPageClientes.Location = new System.Drawing.Point(4, 29);
            this.tabPageClientes.Name = "tabPageClientes";
            this.tabPageClientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClientes.Size = new System.Drawing.Size(1068, 531);
            this.tabPageClientes.TabIndex = 1;
            this.tabPageClientes.Text = "Clientes";
            // 
            // tlsClientes
            // 
            this.tlsClientes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlsClientes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsVolverBtn,
            this.tlsHomeBtn});
            this.tlsClientes.Location = new System.Drawing.Point(3, 3);
            this.tlsClientes.Name = "tlsClientes";
            this.tlsClientes.Size = new System.Drawing.Size(1062, 27);
            this.tlsClientes.TabIndex = 126;
            this.tlsClientes.Text = "toolStrip2";
            // 
            // tlsVolverBtn
            // 
            this.tlsVolverBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsVolverBtn.Image = global::BunBunHub.Properties.Resources.VolverAzul;
            this.tlsVolverBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsVolverBtn.Name = "tlsVolverBtn";
            this.tlsVolverBtn.Size = new System.Drawing.Size(29, 24);
            this.tlsVolverBtn.Text = "toolStripButton1";
            this.tlsVolverBtn.Click += new System.EventHandler(this.tlsVolverBtn_Click);
            // 
            // tlsHomeBtn
            // 
            this.tlsHomeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsHomeBtn.Image = global::BunBunHub.Properties.Resources.HomeAzul;
            this.tlsHomeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsHomeBtn.Name = "tlsHomeBtn";
            this.tlsHomeBtn.Size = new System.Drawing.Size(29, 24);
            this.tlsHomeBtn.Text = "toolStripButton2";
            this.tlsHomeBtn.Click += new System.EventHandler(this.tlsHomeBtn_Click);
            // 
            // grpContacto
            // 
            this.grpContacto.BackColor = System.Drawing.Color.Transparent;
            this.grpContacto.Controls.Add(this.lblValidarTelefono);
            this.grpContacto.Controls.Add(this.txtTelefono);
            this.grpContacto.Controls.Add(this.txtCorreo);
            this.grpContacto.Controls.Add(this.label4);
            this.grpContacto.Controls.Add(this.label10);
            this.grpContacto.Enabled = false;
            this.grpContacto.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.grpContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.grpContacto.Location = new System.Drawing.Point(594, 234);
            this.grpContacto.Margin = new System.Windows.Forms.Padding(4);
            this.grpContacto.Name = "grpContacto";
            this.grpContacto.Padding = new System.Windows.Forms.Padding(4);
            this.grpContacto.Size = new System.Drawing.Size(367, 167);
            this.grpContacto.TabIndex = 125;
            this.grpContacto.TabStop = false;
            this.grpContacto.Text = "Contacto";
            // 
            // lblValidarTelefono
            // 
            this.lblValidarTelefono.AutoSize = true;
            this.lblValidarTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblValidarTelefono.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidarTelefono.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblValidarTelefono.Location = new System.Drawing.Point(24, 141);
            this.lblValidarTelefono.Name = "lblValidarTelefono";
            this.lblValidarTelefono.Size = new System.Drawing.Size(0, 15);
            this.lblValidarTelefono.TabIndex = 46;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefono.Location = new System.Drawing.Point(24, 114);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(219, 27);
            this.txtTelefono.TabIndex = 3;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCorreo.Location = new System.Drawing.Point(24, 45);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(318, 27);
            this.txtCorreo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.label4.Location = new System.Drawing.Point(24, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Teléfono";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.label10.Location = new System.Drawing.Point(21, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Correo";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Activo",
            "Inhabilitado"});
            this.comboBox1.Location = new System.Drawing.Point(618, 434);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 28);
            this.comboBox1.TabIndex = 43;
            // 
            // grpDatosCliente
            // 
            this.grpDatosCliente.BackColor = System.Drawing.Color.Transparent;
            this.grpDatosCliente.Controls.Add(this.txtEdad);
            this.grpDatosCliente.Controls.Add(this.txtApellido);
            this.grpDatosCliente.Controls.Add(this.txtNombre);
            this.grpDatosCliente.Controls.Add(this.lblEdad);
            this.grpDatosCliente.Controls.Add(this.label5);
            this.grpDatosCliente.Controls.Add(this.lblNombre);
            this.grpDatosCliente.Enabled = false;
            this.grpDatosCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.grpDatosCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.grpDatosCliente.Location = new System.Drawing.Point(594, 60);
            this.grpDatosCliente.Margin = new System.Windows.Forms.Padding(4);
            this.grpDatosCliente.Name = "grpDatosCliente";
            this.grpDatosCliente.Padding = new System.Windows.Forms.Padding(4);
            this.grpDatosCliente.Size = new System.Drawing.Size(367, 158);
            this.grpDatosCliente.TabIndex = 124;
            this.grpDatosCliente.TabStop = false;
            this.grpDatosCliente.Text = "Información Personal";
            // 
            // txtEdad
            // 
            this.txtEdad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEdad.ForeColor = System.Drawing.Color.Black;
            this.txtEdad.Location = new System.Drawing.Point(266, 53);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(4);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(76, 27);
            this.txtEdad.TabIndex = 38;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtApellido.ForeColor = System.Drawing.Color.Black;
            this.txtApellido.Location = new System.Drawing.Point(24, 105);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(219, 27);
            this.txtApellido.TabIndex = 37;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(24, 53);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(219, 27);
            this.txtNombre.TabIndex = 36;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblEdad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.lblEdad.Location = new System.Drawing.Point(263, 33);
            this.lblEdad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(38, 17);
            this.lblEdad.TabIndex = 4;
            this.lblEdad.Text = "Edad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.label5.Location = new System.Drawing.Point(24, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.lblNombre.Location = new System.Drawing.Point(21, 32);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(615, 414);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 17);
            this.label12.TabIndex = 41;
            this.label12.Text = "Estado";
            // 
            // grpHistorialClientes
            // 
            this.grpHistorialClientes.Controls.Add(this.dataGridView1);
            this.grpHistorialClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.grpHistorialClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            this.grpHistorialClientes.Location = new System.Drawing.Point(6, 60);
            this.grpHistorialClientes.Name = "grpHistorialClientes";
            this.grpHistorialClientes.Size = new System.Drawing.Size(498, 461);
            this.grpHistorialClientes.TabIndex = 1;
            this.grpHistorialClientes.TabStop = false;
            this.grpHistorialClientes.Text = "Historial de Clientes";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(468, 420);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnCerrarSistema
            // 
            this.btnCerrarSistema.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSistema.BackgroundImage = global::BunBunHub.Properties.Resources.CerrarSistemaCeleste;
            this.btnCerrarSistema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSistema.FlatAppearance.BorderSize = 0;
            this.btnCerrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSistema.Location = new System.Drawing.Point(1035, 13);
            this.btnCerrarSistema.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrarSistema.Name = "btnCerrarSistema";
            this.btnCerrarSistema.Size = new System.Drawing.Size(32, 30);
            this.btnCerrarSistema.TabIndex = 126;
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // lblBunBunHub
            // 
            this.lblBunBunHub.AutoSize = true;
            this.lblBunBunHub.BackColor = System.Drawing.Color.Transparent;
            this.lblBunBunHub.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBunBunHub.ForeColor = System.Drawing.Color.SeaShell;
            this.lblBunBunHub.Location = new System.Drawing.Point(64, 18);
            this.lblBunBunHub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBunBunHub.Name = "lblBunBunHub";
            this.lblBunBunHub.Size = new System.Drawing.Size(137, 29);
            this.lblBunBunHub.TabIndex = 128;
            this.lblBunBunHub.Text = "BunBunHub";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImage = global::BunBunHub.Properties.Resources.LogoBeige;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogo.Location = new System.Drawing.Point(1, 3);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(75, 61);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 127;
            this.picLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(378, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 35);
            this.label1.TabIndex = 129;
            this.label1.Text = "Actualización de Registros";
            // 
            // ActualizarRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BunBunHub.Properties.Resources.FondoLisoTeal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1080, 637);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBunBunHub);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnCerrarSistema);
            this.Controls.Add(this.tabControlRegistros);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActualizarRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ActualizarRegistro";
            this.tabControlRegistros.ResumeLayout(false);
            this.tabPageUsuariosSistema.ResumeLayout(false);
            this.tabPageUsuariosSistema.PerformLayout();
            this.grpCredenciales.ResumeLayout(false);
            this.grpCredenciales.PerformLayout();
            this.tlsUsuarios.ResumeLayout(false);
            this.tlsUsuarios.PerformLayout();
            this.grpHistorialUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tabPageClientes.ResumeLayout(false);
            this.tabPageClientes.PerformLayout();
            this.tlsClientes.ResumeLayout(false);
            this.tlsClientes.PerformLayout();
            this.grpContacto.ResumeLayout(false);
            this.grpContacto.PerformLayout();
            this.grpDatosCliente.ResumeLayout(false);
            this.grpDatosCliente.PerformLayout();
            this.grpHistorialClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlRegistros;
        private System.Windows.Forms.TabPage tabPageUsuariosSistema;
        private System.Windows.Forms.TabPage tabPageClientes;
        private System.Windows.Forms.GroupBox grpHistorialUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnCerrarSistema;
        private System.Windows.Forms.Label lblBunBunHub;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.ToolStrip tlsUsuarios;
        private System.Windows.Forms.ToolStripButton tlsbtnVolver;
        private System.Windows.Forms.ToolStripButton tlsbtnHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpCredenciales;
        private System.Windows.Forms.Label lblConfirmación;
        private System.Windows.Forms.Label lblValidacion;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmarContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUsuarioNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpHistorialClientes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grpContacto;
        private System.Windows.Forms.Label lblValidarTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpDatosCliente;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStrip tlsClientes;
        private System.Windows.Forms.ToolStripButton tlsVolverBtn;
        private System.Windows.Forms.ToolStripButton tlsHomeBtn;
    }
}