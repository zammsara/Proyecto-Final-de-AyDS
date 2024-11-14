namespace BunBunHub
{
    partial class Acceso
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceso));
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblDatos = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.tbContrasena = new System.Windows.Forms.TextBox();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.picUsuario = new System.Windows.Forms.PictureBox();
            this.lblSistema = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblBienvenido.Location = new System.Drawing.Point(171, 102);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(214, 35);
            this.lblBienvenido.TabIndex = 11;
            this.lblBienvenido.Text = "¡Bienvenido!";
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatos.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDatos.Location = new System.Drawing.Point(100, 149);
            this.lblDatos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(361, 27);
            this.lblDatos.TabIndex = 13;
            this.lblDatos.Text = "Ingresa tus datos para iniciar";
            // 
            // tbUsuario
            // 
            this.tbUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.tbUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUsuario.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsuario.ForeColor = System.Drawing.Color.DarkGray;
            this.tbUsuario.Location = new System.Drawing.Point(105, 339);
            this.tbUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(333, 24);
            this.tbUsuario.TabIndex = 14;
            this.tbUsuario.Text = "Usuario";
            this.tbUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbUsuario.Click += new System.EventHandler(this.answer_Enter);
            this.tbUsuario.TextChanged += new System.EventHandler(this.tbUsuario_TextChanged);
            // 
            // tbContrasena
            // 
            this.tbContrasena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbContrasena.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.tbContrasena.ForeColor = System.Drawing.Color.DarkGray;
            this.tbContrasena.Location = new System.Drawing.Point(108, 381);
            this.tbContrasena.Margin = new System.Windows.Forms.Padding(4);
            this.tbContrasena.Name = "tbContrasena";
            this.tbContrasena.Size = new System.Drawing.Size(333, 24);
            this.tbContrasena.TabIndex = 15;
            this.tbContrasena.Text = "Contraseña";
            this.tbContrasena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbContrasena.Click += new System.EventHandler(this.answer_Enter);
            this.tbContrasena.TextChanged += new System.EventHandler(this.tbContrasena_TextChanged);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.AutoSize = true;
            this.btnIniciarSesion.BackColor = System.Drawing.Color.Blue;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.btnIniciarSesion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnIniciarSesion.Location = new System.Drawing.Point(200, 437);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(152, 44);
            this.btnIniciarSesion.TabIndex = 16;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // picUsuario
            // 
            this.picUsuario.Image = ((System.Drawing.Image)(resources.GetObject("picUsuario.Image")));
            this.picUsuario.Location = new System.Drawing.Point(221, 215);
            this.picUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.picUsuario.Name = "picUsuario";
            this.picUsuario.Size = new System.Drawing.Size(107, 82);
            this.picUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUsuario.TabIndex = 17;
            this.picUsuario.TabStop = false;
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSistema.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSistema.Location = new System.Drawing.Point(94, 39);
            this.lblSistema.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(121, 25);
            this.lblSistema.TabIndex = 19;
            this.lblSistema.Text = "BunBunHub";
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(4, 13);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(112, 73);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 18;
            this.picLogo.TabStop = false;
            // 
            // btnCerrarSistema
            // 
            this.btnCerrarSistema.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSistema.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCerrarSistema.BackgroundImage")));
            this.btnCerrarSistema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSistema.FlatAppearance.BorderSize = 0;
            this.btnCerrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSistema.Location = new System.Drawing.Point(526, 13);
            this.btnCerrarSistema.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrarSistema.Name = "btnCerrarSistema";
            this.btnCerrarSistema.Size = new System.Drawing.Size(45, 39);
            this.btnCerrarSistema.TabIndex = 21;
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // Acceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(584, 525);
            this.Controls.Add(this.btnCerrarSistema);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picUsuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.tbContrasena);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.lblDatos);
            this.Controls.Add(this.lblBienvenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Acceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso";
            this.Load += new System.EventHandler(this.Acceso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblDatos;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.TextBox tbContrasena;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.PictureBox picUsuario;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnCerrarSistema;
    }
}

