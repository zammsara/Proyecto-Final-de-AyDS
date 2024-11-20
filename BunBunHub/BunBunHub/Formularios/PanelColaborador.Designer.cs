namespace BunBunHub.Formularios
{
    partial class PanelColaborador
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
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblPaneldeControl = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnCerrarSistema.TabIndex = 118;
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.BackgroundImage = global::BunBunHub.Properties.Resources.btnCerrarSesion;
            this.btnCerrarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.Location = new System.Drawing.Point(13, 583);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(168, 41);
            this.btnCerrarSesion.TabIndex = 119;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblPaneldeControl
            // 
            this.lblPaneldeControl.AutoSize = true;
            this.lblPaneldeControl.BackColor = System.Drawing.Color.Transparent;
            this.lblPaneldeControl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaneldeControl.ForeColor = System.Drawing.Color.SeaShell;
            this.lblPaneldeControl.Location = new System.Drawing.Point(347, 263);
            this.lblPaneldeControl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaneldeControl.Name = "lblPaneldeControl";
            this.lblPaneldeControl.Size = new System.Drawing.Size(311, 50);
            this.lblPaneldeControl.TabIndex = 121;
            this.lblPaneldeControl.Text = "Panel de Control";
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.ForeColor = System.Drawing.Color.SeaShell;
            this.lblBienvenido.Location = new System.Drawing.Point(334, 313);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(335, 20);
            this.lblBienvenido.TabIndex = 120;
            this.lblBienvenido.Text = "Bienvenido al Panel de Control de Colaboradores";
            // 
            // PanelColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BunBunHub.Properties.Resources.FondoTeal_Encabezado;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1080, 637);
            this.Controls.Add(this.lblPaneldeControl);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnCerrarSistema);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PanelColaborador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PanelColaborador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrarSistema;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblPaneldeControl;
        private System.Windows.Forms.Label lblBienvenido;
    }
}