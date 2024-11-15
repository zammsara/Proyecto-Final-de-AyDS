namespace BunBunHub.Panel_de_Control
{
    partial class Administrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrador));
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.picUsuario = new System.Windows.Forms.PictureBox();
            this.picPedido = new System.Windows.Forms.PictureBox();
            this.picFinanzas = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblSistema = new System.Windows.Forms.Label();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.btnFinanzas = new System.Windows.Forms.Button();
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFinanzas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.AutoSize = true;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnCerrarSesion.Location = new System.Drawing.Point(392, 323);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(105, 29);
            this.btnCerrarSesion.TabIndex = 0;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblAdministrador
            // 
            this.lblAdministrador.AutoSize = true;
            this.lblAdministrador.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrador.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAdministrador.Location = new System.Drawing.Point(62, 111);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(389, 27);
            this.lblAdministrador.TabIndex = 13;
            this.lblAdministrador.Text = "Panel de Control - Administrador";
            this.lblAdministrador.Click += new System.EventHandler(this.lblAdministrador_Click);
            // 
            // picUsuario
            // 
            this.picUsuario.Image = ((System.Drawing.Image)(resources.GetObject("picUsuario.Image")));
            this.picUsuario.Location = new System.Drawing.Point(67, 155);
            this.picUsuario.Name = "picUsuario";
            this.picUsuario.Size = new System.Drawing.Size(112, 89);
            this.picUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUsuario.TabIndex = 16;
            this.picUsuario.TabStop = false;
            // 
            // picPedido
            // 
            this.picPedido.Image = ((System.Drawing.Image)(resources.GetObject("picPedido.Image")));
            this.picPedido.Location = new System.Drawing.Point(196, 155);
            this.picPedido.Name = "picPedido";
            this.picPedido.Size = new System.Drawing.Size(112, 89);
            this.picPedido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPedido.TabIndex = 17;
            this.picPedido.TabStop = false;
            this.picPedido.Click += new System.EventHandler(this.picPedido_Click);
            // 
            // picFinanzas
            // 
            this.picFinanzas.Image = ((System.Drawing.Image)(resources.GetObject("picFinanzas.Image")));
            this.picFinanzas.Location = new System.Drawing.Point(322, 155);
            this.picFinanzas.Name = "picFinanzas";
            this.picFinanzas.Size = new System.Drawing.Size(112, 89);
            this.picFinanzas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFinanzas.TabIndex = 18;
            this.picFinanzas.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(10, 11);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(82, 89);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 19;
            this.picLogo.TabStop = false;
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.Font = new System.Drawing.Font("Ink Free", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSistema.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSistema.Location = new System.Drawing.Point(98, 25);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(273, 60);
            this.lblSistema.TabIndex = 20;
            this.lblSistema.Text = "BunBunHub";
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.AutoSize = true;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnUsuarios.Location = new System.Drawing.Point(82, 250);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(76, 29);
            this.btnUsuarios.TabIndex = 21;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnPedidos
            // 
            this.btnPedidos.AutoSize = true;
            this.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidos.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedidos.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnPedidos.Location = new System.Drawing.Point(218, 250);
            this.btnPedidos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(70, 29);
            this.btnPedidos.TabIndex = 22;
            this.btnPedidos.Text = "Pedidos";
            this.btnPedidos.UseVisualStyleBackColor = true;
            // 
            // btnFinanzas
            // 
            this.btnFinanzas.AutoSize = true;
            this.btnFinanzas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinanzas.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinanzas.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFinanzas.Location = new System.Drawing.Point(344, 250);
            this.btnFinanzas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFinanzas.Name = "btnFinanzas";
            this.btnFinanzas.Size = new System.Drawing.Size(74, 29);
            this.btnFinanzas.TabIndex = 23;
            this.btnFinanzas.Text = "Finanzas";
            this.btnFinanzas.UseVisualStyleBackColor = true;
            this.btnFinanzas.Click += new System.EventHandler(this.btnFinanzas_Click);
            // 
            // btnCerrarSistema
            // 
            this.btnCerrarSistema.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSistema.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrarSistema.BackgroundImage")));
            this.btnCerrarSistema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSistema.FlatAppearance.BorderSize = 0;
            this.btnCerrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSistema.Location = new System.Drawing.Point(467, 11);
            this.btnCerrarSistema.Name = "btnCerrarSistema";
            this.btnCerrarSistema.Size = new System.Drawing.Size(34, 32);
            this.btnCerrarSistema.TabIndex = 24;
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 369);
            this.Controls.Add(this.btnCerrarSistema);
            this.Controls.Add(this.btnFinanzas);
            this.Controls.Add(this.btnPedidos);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picFinanzas);
            this.Controls.Add(this.picPedido);
            this.Controls.Add(this.picUsuario);
            this.Controls.Add(this.lblAdministrador);
            this.Controls.Add(this.btnCerrarSesion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Administrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Administrador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFinanzas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.PictureBox picUsuario;
        private System.Windows.Forms.PictureBox picPedido;
        private System.Windows.Forms.PictureBox picFinanzas;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnPedidos;
        private System.Windows.Forms.Button btnFinanzas;
        private System.Windows.Forms.Button btnCerrarSistema;
    }
}