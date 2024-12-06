namespace BunBunHub.Formularios
{
    partial class PanelCliente
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
            this.components = new System.ComponentModel.Container();
            this.lblPaneldeControl = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIdPedido = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnVisualizarPedido = new System.Windows.Forms.Button();
            this.picPublicidad2 = new System.Windows.Forms.PictureBox();
            this.picEstado = new System.Windows.Forms.PictureBox();
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            this.lblBunBunHub = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.picCancelado = new System.Windows.Forms.PictureBox();
            this.btnInformacionSistema = new System.Windows.Forms.Button();
            this.btnPerfilCliente = new System.Windows.Forms.Button();
            this.btnHistorialPedidos = new System.Windows.Forms.Button();
            this.picPerfil = new System.Windows.Forms.PictureBox();
            this.toolTipFunciones = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPublicidad2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancelado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPaneldeControl
            // 
            this.lblPaneldeControl.AutoSize = true;
            this.lblPaneldeControl.BackColor = System.Drawing.Color.Transparent;
            this.lblPaneldeControl.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaneldeControl.ForeColor = System.Drawing.Color.SeaShell;
            this.lblPaneldeControl.Location = new System.Drawing.Point(579, 91);
            this.lblPaneldeControl.Name = "lblPaneldeControl";
            this.lblPaneldeControl.Size = new System.Drawing.Size(69, 30);
            this.lblPaneldeControl.TabIndex = 121;
            this.lblPaneldeControl.Text = "Inicio";
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblBienvenido.ForeColor = System.Drawing.Color.SeaShell;
            this.lblBienvenido.Location = new System.Drawing.Point(514, 122);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(222, 13);
            this.lblBienvenido.TabIndex = 120;
            this.lblBienvenido.Text = "Bienvenido al Panel de Control de Clientes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.SeaShell;
            this.label7.Location = new System.Drawing.Point(467, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 143;
            this.label7.Text = "Ingrese el ID del Pedido";
            // 
            // txtIdPedido
            // 
            this.txtIdPedido.BackColor = System.Drawing.Color.White;
            this.txtIdPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdPedido.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPedido.ForeColor = System.Drawing.Color.DarkGray;
            this.txtIdPedido.Location = new System.Drawing.Point(470, 206);
            this.txtIdPedido.Name = "txtIdPedido";
            this.txtIdPedido.Size = new System.Drawing.Size(202, 26);
            this.txtIdPedido.TabIndex = 144;
            this.txtIdPedido.Text = "P0000";
            this.txtIdPedido.Click += new System.EventHandler(this.seleccionar_enter);
            this.txtIdPedido.TextChanged += new System.EventHandler(this.txtIdPedido_TextChanged);
            this.txtIdPedido.Leave += new System.EventHandler(this.txtIdPedido_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.BackColor = System.Drawing.Color.SlateGray;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(677, 205);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 27);
            this.btnBuscar.TabIndex = 145;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnVisualizarPedido
            // 
            this.btnVisualizarPedido.AutoSize = true;
            this.btnVisualizarPedido.BackColor = System.Drawing.Color.SlateGray;
            this.btnVisualizarPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVisualizarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizarPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnVisualizarPedido.ForeColor = System.Drawing.Color.White;
            this.btnVisualizarPedido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVisualizarPedido.Location = new System.Drawing.Point(528, 374);
            this.btnVisualizarPedido.Name = "btnVisualizarPedido";
            this.btnVisualizarPedido.Size = new System.Drawing.Size(164, 27);
            this.btnVisualizarPedido.TabIndex = 146;
            this.btnVisualizarPedido.Text = "Visualizar Pedido";
            this.btnVisualizarPedido.UseVisualStyleBackColor = false;
            this.btnVisualizarPedido.Visible = false;
            this.btnVisualizarPedido.Click += new System.EventHandler(this.btnVisualizarPedido_Click);
            // 
            // picPublicidad2
            // 
            this.picPublicidad2.BackColor = System.Drawing.Color.Transparent;
            this.picPublicidad2.Location = new System.Drawing.Point(42, 110);
            this.picPublicidad2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picPublicidad2.Name = "picPublicidad2";
            this.picPublicidad2.Size = new System.Drawing.Size(318, 342);
            this.picPublicidad2.TabIndex = 142;
            this.picPublicidad2.TabStop = false;
            // 
            // picEstado
            // 
            this.picEstado.BackColor = System.Drawing.Color.Transparent;
            this.picEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picEstado.Location = new System.Drawing.Point(445, 266);
            this.picEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picEstado.Name = "picEstado";
            this.picEstado.Size = new System.Drawing.Size(334, 78);
            this.picEstado.TabIndex = 141;
            this.picEstado.TabStop = false;
            // 
            // btnCerrarSistema
            // 
            this.btnCerrarSistema.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSistema.BackgroundImage = global::BunBunHub.Properties.Resources.CerrarBlanco;
            this.btnCerrarSistema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSistema.FlatAppearance.BorderSize = 0;
            this.btnCerrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSistema.Location = new System.Drawing.Point(776, 11);
            this.btnCerrarSistema.Name = "btnCerrarSistema";
            this.btnCerrarSistema.Size = new System.Drawing.Size(24, 24);
            this.btnCerrarSistema.TabIndex = 118;
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // lblBunBunHub
            // 
            this.lblBunBunHub.AutoSize = true;
            this.lblBunBunHub.BackColor = System.Drawing.Color.Transparent;
            this.lblBunBunHub.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBunBunHub.ForeColor = System.Drawing.Color.SeaShell;
            this.lblBunBunHub.Location = new System.Drawing.Point(49, 11);
            this.lblBunBunHub.Name = "lblBunBunHub";
            this.lblBunBunHub.Size = new System.Drawing.Size(113, 23);
            this.lblBunBunHub.TabIndex = 148;
            this.lblBunBunHub.Text = "BunBunHub";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImage = global::BunBunHub.Properties.Resources.LogoBeige;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogo.Location = new System.Drawing.Point(2, -1);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(56, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 147;
            this.picLogo.TabStop = false;
            // 
            // lblAdministrador
            // 
            this.lblAdministrador.AutoSize = true;
            this.lblAdministrador.BackColor = System.Drawing.Color.Transparent;
            this.lblAdministrador.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrador.ForeColor = System.Drawing.Color.SeaShell;
            this.lblAdministrador.Location = new System.Drawing.Point(449, 24);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(43, 15);
            this.lblAdministrador.TabIndex = 156;
            this.lblAdministrador.Text = "Cliente";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.SeaShell;
            this.lblNombreUsuario.Location = new System.Drawing.Point(450, 11);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblNombreUsuario.TabIndex = 155;
            this.lblNombreUsuario.Text = "Usuario";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.BackgroundImage = global::BunBunHub.Properties.Resources.btnCerrarSesionCliente;
            this.btnCerrarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Location = new System.Drawing.Point(688, 463);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(31, 31);
            this.btnCerrarSesion.TabIndex = 159;
            this.toolTipFunciones.SetToolTip(this.btnCerrarSesion, "Cerrar Sesión");
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // picCancelado
            // 
            this.picCancelado.BackColor = System.Drawing.Color.Transparent;
            this.picCancelado.Location = new System.Drawing.Point(552, 250);
            this.picCancelado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picCancelado.Name = "picCancelado";
            this.picCancelado.Size = new System.Drawing.Size(112, 103);
            this.picCancelado.TabIndex = 161;
            this.picCancelado.TabStop = false;
            // 
            // btnInformacionSistema
            // 
            this.btnInformacionSistema.BackColor = System.Drawing.Color.Transparent;
            this.btnInformacionSistema.BackgroundImage = global::BunBunHub.Properties.Resources.btnInformacionCliente;
            this.btnInformacionSistema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInformacionSistema.FlatAppearance.BorderSize = 0;
            this.btnInformacionSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformacionSistema.Location = new System.Drawing.Point(634, 463);
            this.btnInformacionSistema.Name = "btnInformacionSistema";
            this.btnInformacionSistema.Size = new System.Drawing.Size(31, 31);
            this.btnInformacionSistema.TabIndex = 162;
            this.toolTipFunciones.SetToolTip(this.btnInformacionSistema, "Información sobre el sistema");
            this.btnInformacionSistema.UseVisualStyleBackColor = false;
            this.btnInformacionSistema.Click += new System.EventHandler(this.btnInformacionSistema_Click);
            // 
            // btnPerfilCliente
            // 
            this.btnPerfilCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnPerfilCliente.BackgroundImage = global::BunBunHub.Properties.Resources.btnPerfilCliente;
            this.btnPerfilCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPerfilCliente.FlatAppearance.BorderSize = 0;
            this.btnPerfilCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerfilCliente.Location = new System.Drawing.Point(572, 463);
            this.btnPerfilCliente.Name = "btnPerfilCliente";
            this.btnPerfilCliente.Size = new System.Drawing.Size(31, 31);
            this.btnPerfilCliente.TabIndex = 163;
            this.toolTipFunciones.SetToolTip(this.btnPerfilCliente, "Datos del Cliente");
            this.btnPerfilCliente.UseVisualStyleBackColor = false;
            this.btnPerfilCliente.Click += new System.EventHandler(this.btnPerfilCliente_Click);
            // 
            // btnHistorialPedidos
            // 
            this.btnHistorialPedidos.BackColor = System.Drawing.Color.Transparent;
            this.btnHistorialPedidos.BackgroundImage = global::BunBunHub.Properties.Resources.btnHistorialPedidos;
            this.btnHistorialPedidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHistorialPedidos.FlatAppearance.BorderSize = 0;
            this.btnHistorialPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialPedidos.Location = new System.Drawing.Point(510, 463);
            this.btnHistorialPedidos.Name = "btnHistorialPedidos";
            this.btnHistorialPedidos.Size = new System.Drawing.Size(31, 31);
            this.btnHistorialPedidos.TabIndex = 164;
            this.btnHistorialPedidos.Text = " ";
            this.toolTipFunciones.SetToolTip(this.btnHistorialPedidos, "Historial de pedidos");
            this.btnHistorialPedidos.UseVisualStyleBackColor = false;
            this.btnHistorialPedidos.Click += new System.EventHandler(this.btnHistorialPedidos_Click);
            // 
            // picPerfil
            // 
            this.picPerfil.BackColor = System.Drawing.Color.Transparent;
            this.picPerfil.BackgroundImage = global::BunBunHub.Properties.Resources.UsuarioBeige;
            this.picPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picPerfil.Location = new System.Drawing.Point(416, 6);
            this.picPerfil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picPerfil.Name = "picPerfil";
            this.picPerfil.Size = new System.Drawing.Size(35, 32);
            this.picPerfil.TabIndex = 165;
            this.picPerfil.TabStop = false;
            // 
            // PanelCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BunBunHub.Properties.Resources.FondoPanelCliente1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(810, 518);
            this.Controls.Add(this.picPerfil);
            this.Controls.Add(this.btnHistorialPedidos);
            this.Controls.Add(this.btnPerfilCliente);
            this.Controls.Add(this.btnInformacionSistema);
            this.Controls.Add(this.picCancelado);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lblAdministrador);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.lblBunBunHub);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnVisualizarPedido);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtIdPedido);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.picPublicidad2);
            this.Controls.Add(this.picEstado);
            this.Controls.Add(this.lblPaneldeControl);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.btnCerrarSistema);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PanelCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PanelCliente";
            ((System.ComponentModel.ISupportInitialize)(this.picPublicidad2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancelado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrarSistema;
        private System.Windows.Forms.Label lblPaneldeControl;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.PictureBox picEstado;
        private System.Windows.Forms.PictureBox picPublicidad2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIdPedido;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnVisualizarPedido;
        private System.Windows.Forms.Label lblBunBunHub;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.PictureBox picCancelado;
        private System.Windows.Forms.Button btnInformacionSistema;
        private System.Windows.Forms.Button btnPerfilCliente;
        private System.Windows.Forms.Button btnHistorialPedidos;
        private System.Windows.Forms.PictureBox picPerfil;
        private System.Windows.Forms.ToolTip toolTipFunciones;
    }
}